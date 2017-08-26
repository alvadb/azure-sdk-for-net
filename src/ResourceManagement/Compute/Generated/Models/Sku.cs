// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator 1.0.1.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Microsoft.Azure.Management.Compute.Fluent.Models
{
    using Microsoft.Azure;
    using Microsoft.Azure.Management;
    using Microsoft.Azure.Management.Compute;
    using Microsoft.Azure.Management.Compute.Fluent;
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// Describes a virtual machine scale set sku.
    /// </summary>
    public partial class Sku
    {
        /// <summary>
        /// Initializes a new instance of the Sku class.
        /// </summary>
        public Sku()
        {
          CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the Sku class.
        /// </summary>
        /// <param name="name">The sku name.</param>
        /// <param name="tier">The sku tier.</param>
        /// <param name="capacity">The sku capacity.</param>
        public Sku(string name = default(string), string tier = default(string), long? capacity = default(long?))
        {
            Name = name;
            Tier = tier;
            Capacity = capacity;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets the sku name.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the sku tier.
        /// </summary>
        [JsonProperty(PropertyName = "tier")]
        public string Tier { get; set; }

        /// <summary>
        /// Gets or sets the sku capacity.
        /// </summary>
        [JsonProperty(PropertyName = "capacity")]
        public long? Capacity { get; set; }

    }
}