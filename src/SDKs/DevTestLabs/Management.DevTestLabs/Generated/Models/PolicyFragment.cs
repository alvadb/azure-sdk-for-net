// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
// 
// Code generated by Microsoft (R) AutoRest Code Generator 0.16.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Microsoft.Azure.Management.DevTestLabs.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Rest.Azure;

    /// <summary>
    /// A Policy.
    /// </summary>
    [JsonTransformation]
    public partial class PolicyFragment : Resource
    {
        /// <summary>
        /// Initializes a new instance of the PolicyFragment class.
        /// </summary>
        public PolicyFragment() { }

        /// <summary>
        /// Initializes a new instance of the PolicyFragment class.
        /// </summary>
        public PolicyFragment(string id = default(string), string name = default(string), string type = default(string), string location = default(string), IDictionary<string, string> tags = default(IDictionary<string, string>), string description = default(string), string status = default(string), string factName = default(string), string factData = default(string), string threshold = default(string), string evaluatorType = default(string), string provisioningState = default(string), string uniqueIdentifier = default(string))
            : base(id, name, type, location, tags)
        {
            Description = description;
            Status = status;
            FactName = factName;
            FactData = factData;
            Threshold = threshold;
            EvaluatorType = evaluatorType;
            ProvisioningState = provisioningState;
            UniqueIdentifier = uniqueIdentifier;
        }

        /// <summary>
        /// The description of the policy.
        /// </summary>
        [JsonProperty(PropertyName = "properties.description")]
        public string Description { get; set; }

        /// <summary>
        /// The status of the policy. Possible values include: 'Enabled',
        /// 'Disabled'
        /// </summary>
        [JsonProperty(PropertyName = "properties.status")]
        public string Status { get; set; }

        /// <summary>
        /// The fact name of the policy (e.g. LabVmCount, LabVmSize,
        /// MaxVmsAllowedPerLab, etc. Possible values include:
        /// 'UserOwnedLabVmCount', 'UserOwnedLabPremiumVmCount',
        /// 'LabVmCount', 'LabPremiumVmCount', 'LabVmSize', 'GalleryImage',
        /// 'UserOwnedLabVmCountInSubnet', 'LabTargetCost'
        /// </summary>
        [JsonProperty(PropertyName = "properties.factName")]
        public string FactName { get; set; }

        /// <summary>
        /// The fact data of the policy.
        /// </summary>
        [JsonProperty(PropertyName = "properties.factData")]
        public string FactData { get; set; }

        /// <summary>
        /// The threshold of the policy (i.e. a number for MaxValuePolicy, and
        /// a JSON array of values for AllowedValuesPolicy).
        /// </summary>
        [JsonProperty(PropertyName = "properties.threshold")]
        public string Threshold { get; set; }

        /// <summary>
        /// The evaluator type of the policy (i.e. AllowedValuesPolicy,
        /// MaxValuePolicy). Possible values include: 'AllowedValuesPolicy',
        /// 'MaxValuePolicy'
        /// </summary>
        [JsonProperty(PropertyName = "properties.evaluatorType")]
        public string EvaluatorType { get; set; }

        /// <summary>
        /// The provisioning status of the resource.
        /// </summary>
        [JsonProperty(PropertyName = "properties.provisioningState")]
        public string ProvisioningState { get; set; }

        /// <summary>
        /// The unique immutable identifier of a resource (Guid).
        /// </summary>
        [JsonProperty(PropertyName = "properties.uniqueIdentifier")]
        public string UniqueIdentifier { get; set; }

    }
}
