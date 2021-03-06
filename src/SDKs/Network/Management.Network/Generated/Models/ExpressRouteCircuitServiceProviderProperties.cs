// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Microsoft.Azure.Management.Network.Models
{
    using Microsoft.Azure;
    using Microsoft.Azure.Management;
    using Microsoft.Azure.Management.Network;
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// Contains ServiceProviderProperties in an ExpressRouteCircuit.
    /// </summary>
    public partial class ExpressRouteCircuitServiceProviderProperties
    {
        /// <summary>
        /// Initializes a new instance of the
        /// ExpressRouteCircuitServiceProviderProperties class.
        /// </summary>
        public ExpressRouteCircuitServiceProviderProperties()
        {
          CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// ExpressRouteCircuitServiceProviderProperties class.
        /// </summary>
        /// <param name="serviceProviderName">The serviceProviderName.</param>
        /// <param name="peeringLocation">The peering location.</param>
        /// <param name="bandwidthInMbps">The BandwidthInMbps.</param>
        public ExpressRouteCircuitServiceProviderProperties(string serviceProviderName = default(string), string peeringLocation = default(string), int? bandwidthInMbps = default(int?))
        {
            ServiceProviderName = serviceProviderName;
            PeeringLocation = peeringLocation;
            BandwidthInMbps = bandwidthInMbps;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets the serviceProviderName.
        /// </summary>
        [JsonProperty(PropertyName = "serviceProviderName")]
        public string ServiceProviderName { get; set; }

        /// <summary>
        /// Gets or sets the peering location.
        /// </summary>
        [JsonProperty(PropertyName = "peeringLocation")]
        public string PeeringLocation { get; set; }

        /// <summary>
        /// Gets or sets the BandwidthInMbps.
        /// </summary>
        [JsonProperty(PropertyName = "bandwidthInMbps")]
        public int? BandwidthInMbps { get; set; }

    }
}
