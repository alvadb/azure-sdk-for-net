// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// </auto-generated>

namespace Microsoft.Azure.Management.StorSimple.Fluent
{
    using Microsoft.Azure;
    using Microsoft.Azure.Management;
    using Microsoft.Azure.Management.StorSimple;
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;
    using Models;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// HardwareComponentGroupsOperations operations.
    /// </summary>
    public partial interface IHardwareComponentGroupsOperations
    {
        /// <summary>
        /// Lists the hardware component groups at device-level.
        /// </summary>
        /// <param name='deviceName'>
        /// The device name
        /// </param>
        /// <param name='resourceGroupName'>
        /// The resource group name
        /// </param>
        /// <param name='managerName'>
        /// The manager name
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="Microsoft.Rest.Azure.CloudException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<AzureOperationResponse<IEnumerable<HardwareComponentGroup>>> ListByDeviceWithHttpMessagesAsync(string deviceName, string resourceGroupName, string managerName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Changes the power state of the controller.
        /// </summary>
        /// <param name='deviceName'>
        /// The device name
        /// </param>
        /// <param name='hardwareComponentGroupName'>
        /// The hardware component group name.
        /// </param>
        /// <param name='parameters'>
        /// The controller power state change request.
        /// </param>
        /// <param name='resourceGroupName'>
        /// The resource group name
        /// </param>
        /// <param name='managerName'>
        /// The manager name
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="Microsoft.Rest.Azure.CloudException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<AzureOperationResponse> ChangeControllerPowerStateWithHttpMessagesAsync(string deviceName, string hardwareComponentGroupName, ControllerPowerStateChangeRequestInner parameters, string resourceGroupName, string managerName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Changes the power state of the controller.
        /// </summary>
        /// <param name='deviceName'>
        /// The device name
        /// </param>
        /// <param name='hardwareComponentGroupName'>
        /// The hardware component group name.
        /// </param>
        /// <param name='parameters'>
        /// The controller power state change request.
        /// </param>
        /// <param name='resourceGroupName'>
        /// The resource group name
        /// </param>
        /// <param name='managerName'>
        /// The manager name
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="Microsoft.Rest.Azure.CloudException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<AzureOperationResponse> BeginChangeControllerPowerStateWithHttpMessagesAsync(string deviceName, string hardwareComponentGroupName, ControllerPowerStateChangeRequestInner parameters, string resourceGroupName, string managerName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
    }
}