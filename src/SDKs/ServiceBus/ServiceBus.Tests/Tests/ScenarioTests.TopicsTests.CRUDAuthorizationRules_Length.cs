﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.


namespace ServiceBus.Tests.ScenarioTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using Microsoft.Azure.Management.ServiceBus;
    using Microsoft.Azure.Management.ServiceBus.Models;
    using Microsoft.Azure.Test.HttpRecorder;
    using Microsoft.Rest.Azure;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using TestHelper;
    using Xunit;
    public partial class ScenarioTests 
    {
        [Fact]
        public void TopicsCreateGetUpdateDeleteAuthorizationRules_Length()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                InitializeClients(context);

                var location = this.ResourceManagementClient.GetLocationFromProvider();

                var resourceGroup = this.ResourceManagementClient.TryGetResourceGroup(location);
                if (string.IsNullOrWhiteSpace(resourceGroup))
                {
                    resourceGroup = TestUtilities.GenerateName(ServiceBusManagementHelper.ResourceGroupPrefix);
                    this.ResourceManagementClient.TryRegisterResourceGroup(location, resourceGroup);
                }

                // Create a namespace
                var namespaceName = TestUtilities.GenerateName(ServiceBusManagementHelper.NamespacePrefix);

                var createNamespaceResponse = this.ServiceBusManagementClient.Namespaces.CreateOrUpdate(resourceGroup, namespaceName,
                    new SBNamespace()
                    {
                        Location = location,
                        Sku = new SBSku
                        {
                            Name = SkuName.Standard,
                            Tier = SkuTier.Standard
                        }
                    });

                Assert.NotNull(createNamespaceResponse);
                Assert.Equal(createNamespaceResponse.Name, namespaceName);

                TestUtilities.Wait(TimeSpan.FromSeconds(5));
                 
                // Get the created namespace
                var getNamespaceResponse = ServiceBusManagementClient.Namespaces.Get(resourceGroup, namespaceName);
                if (string.Compare(getNamespaceResponse.ProvisioningState, "Succeeded", true) != 0)
                    TestUtilities.Wait(TimeSpan.FromSeconds(5));

                getNamespaceResponse = ServiceBusManagementClient.Namespaces.Get(resourceGroup, namespaceName);
                Assert.NotNull(getNamespaceResponse);
                Assert.Equal("Succeeded", getNamespaceResponse.ProvisioningState, StringComparer.CurrentCultureIgnoreCase);
                Assert.Equal(location, getNamespaceResponse.Location, StringComparer.CurrentCultureIgnoreCase);

                // Create Topic
                var topicName = ServiceBusManagementHelper.TopicPrefix + "thisisthenamewithmorethan53charschecktoverifytheremovlaof50charsnamelenghtlimit";
                
                var createTopicResponse = this.ServiceBusManagementClient.Topics.CreateOrUpdate(resourceGroup, namespaceName, topicName,
                new SBTopic() {  EnablePartitioning = true });
                Assert.NotNull(createTopicResponse);
                Assert.Equal(createTopicResponse.Name, topicName);
                
                // Get the created Topic
                var getTopicResponse = ServiceBusManagementClient.Topics.Get(resourceGroup, namespaceName, topicName);
                Assert.NotNull(getTopicResponse);
                Assert.Equal(EntityStatus.Active, createTopicResponse.Status);
                Assert.Equal(getTopicResponse.Name, topicName);                

                // Create a topic AuthorizationRule
                var authorizationRuleName = ServiceBusManagementHelper.AuthorizationRulesPrefix + "thisisthenamewithmorethan53charschecktoverifytheremovlaof50charsnamelenghtlimit";
                string createPrimaryKey = HttpMockServer.GetVariable("CreatePrimaryKey", ServiceBusManagementHelper.GenerateRandomKey());
                var createAutorizationRuleParameter = new SBAuthorizationRule()
                {
                    Rights = new List<AccessRights?>() { AccessRights.Listen, AccessRights.Send }
                };

                var jsonStr = ServiceBusManagementHelper.ConvertObjectToJSon(createAutorizationRuleParameter);
                var createTopicAuthorizationRuleResponse = ServiceBusManagementClient.Topics.CreateOrUpdateAuthorizationRule(resourceGroup, namespaceName,topicName,
                    authorizationRuleName, createAutorizationRuleParameter);
                Assert.NotNull(createTopicAuthorizationRuleResponse);
                Assert.True(createTopicAuthorizationRuleResponse.Rights.Count == createAutorizationRuleParameter.Rights.Count);
                foreach (var right in createAutorizationRuleParameter.Rights)
                {
                    Assert.True(createTopicAuthorizationRuleResponse.Rights.Any(r => r == right));
                }

                // Get created Topics AuthorizationRules
                var getTopicsAuthorizationRulesResponse = ServiceBusManagementClient.Topics.GetAuthorizationRule(resourceGroup, namespaceName, topicName, authorizationRuleName);
                Assert.NotNull(getTopicsAuthorizationRulesResponse);
                Assert.True(getTopicsAuthorizationRulesResponse.Rights.Count == createAutorizationRuleParameter.Rights.Count);
                foreach (var right in createAutorizationRuleParameter.Rights)
                {
                    Assert.True(getTopicsAuthorizationRulesResponse.Rights.Any(r => r == right));
                }

                // Get all Topics AuthorizationRules
                var getAllNamespaceAuthorizationRulesResponse = ServiceBusManagementClient.Topics.ListAuthorizationRules(resourceGroup, namespaceName, topicName);
                Assert.NotNull(getAllNamespaceAuthorizationRulesResponse);
                Assert.Equal(getAllNamespaceAuthorizationRulesResponse.Count(), 1);
                Assert.True(getAllNamespaceAuthorizationRulesResponse.Any(ns => ns.Name == authorizationRuleName));                

                // Update topics authorizationRule
                string updatePrimaryKey = HttpMockServer.GetVariable("UpdatePrimaryKey", ServiceBusManagementHelper.GenerateRandomKey());
                SBAuthorizationRule updateTopicsAuthorizationRuleParameter = new SBAuthorizationRule();
                updateTopicsAuthorizationRuleParameter.Rights = new List<AccessRights?>() { AccessRights.Listen };

                var updateTopicAuthorizationRuleResponse = ServiceBusManagementClient.Topics.CreateOrUpdateAuthorizationRule(resourceGroup,
                    namespaceName,topicName, authorizationRuleName, updateTopicsAuthorizationRuleParameter);

                Assert.NotNull(updateTopicAuthorizationRuleResponse);
                Assert.Equal(authorizationRuleName, updateTopicAuthorizationRuleResponse.Name);
                Assert.True(updateTopicAuthorizationRuleResponse.Rights.Count == updateTopicsAuthorizationRuleParameter.Rights.Count);
                foreach (var right in updateTopicsAuthorizationRuleParameter.Rights)
                {
                    Assert.True(updateTopicAuthorizationRuleResponse.Rights.Any(r => r.Equals(right)));
                }

                // Get the updated Topics AuthorizationRule
                var getTopicAuthorizationRuleResponse = ServiceBusManagementClient.Topics.GetAuthorizationRule(resourceGroup, namespaceName,topicName,
                    authorizationRuleName);
                Assert.NotNull(getTopicAuthorizationRuleResponse);
                Assert.Equal(authorizationRuleName, getTopicAuthorizationRuleResponse.Name);
                Assert.True(getTopicAuthorizationRuleResponse.Rights.Count == updateTopicsAuthorizationRuleParameter.Rights.Count);
                foreach (var right in updateTopicsAuthorizationRuleParameter.Rights)
                {
                    Assert.True(getTopicAuthorizationRuleResponse.Rights.Any(r => r.Equals(right)));
                }

                // Get the connectionString to the Topics for a Authorization rule created
                var listKeysTopicsResponse = ServiceBusManagementClient.Topics.ListKeys(resourceGroup, namespaceName, topicName, authorizationRuleName);
                Assert.NotNull(listKeysTopicsResponse);
                Assert.NotNull(listKeysTopicsResponse.PrimaryConnectionString);
                Assert.NotNull(listKeysTopicsResponse.SecondaryConnectionString);
                
                // Regenerate Keys for the create Authorization rules
                var regenerateKeysTopicsParameters = new RegenerateAccessKeyParameters();
                regenerateKeysTopicsParameters.KeyType = KeyType.PrimaryKey;
                
                var regenerateKeysTopicsResposnse = ServiceBusManagementClient.Topics.RegenerateKeys(resourceGroup, namespaceName, topicName, authorizationRuleName, regenerateKeysTopicsParameters);
                Assert.NotEqual(listKeysTopicsResponse.PrimaryKey, regenerateKeysTopicsResposnse.PrimaryKey);
                Assert.NotNull(regenerateKeysTopicsResposnse.PrimaryConnectionString);
                Assert.NotNull(regenerateKeysTopicsResposnse.SecondaryConnectionString);
                Assert.NotNull(regenerateKeysTopicsResposnse.SecondaryKey);

                regenerateKeysTopicsParameters.KeyType = KeyType.SecondaryKey;
                regenerateKeysTopicsResposnse = ServiceBusManagementClient.Topics.RegenerateKeys(resourceGroup, namespaceName, topicName, authorizationRuleName, regenerateKeysTopicsParameters);
                Assert.NotEqual(listKeysTopicsResponse.SecondaryKey, regenerateKeysTopicsResposnse.SecondaryKey);
                Assert.NotNull(regenerateKeysTopicsResposnse.PrimaryConnectionString);
                Assert.NotNull(regenerateKeysTopicsResposnse.SecondaryConnectionString);
                Assert.NotNull(regenerateKeysTopicsResposnse.PrimaryKey);                

                // Delete Topic authorizationRule
                ServiceBusManagementClient.Topics.DeleteAuthorizationRule(resourceGroup, namespaceName, topicName, authorizationRuleName);

                TestUtilities.Wait(TimeSpan.FromSeconds(5));
                
                // Delete Topic
                ServiceBusManagementClient.Topics.Delete(resourceGroup, namespaceName, topicName);
                
                // Delete namespace
                ServiceBusManagementClient.Namespaces.Delete(resourceGroup, namespaceName);
                
            }
        }
    }
}
