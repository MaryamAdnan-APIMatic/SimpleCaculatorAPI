// <copyright file="OperationEnum.cs" company="APIMatic">
// Copyright (c) APIMatic. All rights reserved.
// </copyright>
namespace UNIREST.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using UNIREST;
    using UNIREST.Utilities;

    /// <summary>
    /// OperationEnum.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum OperationEnum
    {
        /// <summary>
        /// Multiply.
        /// </summary>
        [EnumMember(Value = "Multiply")]
        Multiply,

        /// <summary>
        /// Divide.
        /// </summary>
        [EnumMember(Value = "Divide")]
        Divide,

        /// <summary>
        /// Sum.
        /// </summary>
        [EnumMember(Value = "Sum")]
        Sum,

        /// <summary>
        /// Subtract.
        /// </summary>
        [EnumMember(Value = "subtract")]
        Subtract,
    }
}