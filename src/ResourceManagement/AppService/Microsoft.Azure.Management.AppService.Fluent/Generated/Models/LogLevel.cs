// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
// 
// Code generated by Microsoft (R) AutoRest Code Generator 0.17.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Microsoft.Azure.Management.AppService.Fluent.Models
{

    /// <summary>
    /// Defines values for LogLevel.
    /// </summary>
    [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum LogLevel
    {
        [System.Runtime.Serialization.EnumMember(Value = "Off")]
        Off,
        [System.Runtime.Serialization.EnumMember(Value = "Verbose")]
        Verbose,
        [System.Runtime.Serialization.EnumMember(Value = "Information")]
        Information,
        [System.Runtime.Serialization.EnumMember(Value = "Warning")]
        Warning,
        [System.Runtime.Serialization.EnumMember(Value = "Error")]
        Error
    }
}