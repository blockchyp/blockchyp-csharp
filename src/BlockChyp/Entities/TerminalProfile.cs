// Copyright 2019-2022 BlockChyp, Inc. All rights reserved. Use of this code is
// governed by a license that can be found in the LICENSE file.
//
// This file was generated automatically by the BlockChyp SDK Generator. Changes
// to this file will be lost every time the code is regenerated.

using Newtonsoft.Json;

namespace BlockChyp.Entities
{
    /// <summary>
    /// Details about a merchant board platform configuration.
    /// </summary>
    public class TerminalProfile : BaseEntity
    {
        /// <summary>
        /// Primary identifier for a given terminal.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// The terminal's local IP address.
        /// </summary>
        [JsonProperty(PropertyName = "ipAddress")]
        public string IpAddress { get; set; }

        /// <summary>
        /// The name assigned to the terminal during activation.
        /// </summary>
        [JsonProperty(PropertyName = "terminalName")]
        public string TerminalName { get; set; }

        /// <summary>
        /// The terminal type.
        /// </summary>
        [JsonProperty(PropertyName = "terminalType")]
        public string TerminalType { get; set; }

        /// <summary>
        /// The terminal type display string.
        /// </summary>
        [JsonProperty(PropertyName = "terminalTypeDisplayString")]
        public string TerminalTypeDisplayString { get; set; }

        /// <summary>
        /// The current firmware version deployed on the terminal.
        /// </summary>
        [JsonProperty(PropertyName = "blockChypFirmwareVersion")]
        public string BlockChypFirmwareVersion { get; set; }

        /// <summary>
        /// Whether or not the terminal is configured for cloud relay.
        /// </summary>
        [JsonProperty(PropertyName = "cloudBased")]
        public bool CloudBased { get; set; }

        /// <summary>
        /// The terminal's elliptic curve public key.
        /// </summary>
        [JsonProperty(PropertyName = "publicKey")]
        public string PublicKey { get; set; }

        /// <summary>
        /// The manufacturer's serial number.
        /// </summary>
        [JsonProperty(PropertyName = "serialNumber")]
        public string SerialNumber { get; set; }

        /// <summary>
        /// Whether or not the terminal is currently online
        /// </summary>
        [JsonProperty(PropertyName = "online")]
        public bool Online { get; set; }

        /// <summary>
        /// The date and time the terminal was first brought online.
        /// </summary>
        [JsonProperty(PropertyName = "since")]
        public string Since { get; set; }

        /// <summary>
        /// The total memory on the terminal.
        /// </summary>
        [JsonProperty(PropertyName = "totalMemory")]
        public int TotalMemory { get; set; }

        /// <summary>
        /// The storage on the terminal.
        /// </summary>
        [JsonProperty(PropertyName = "totalStorage")]
        public int TotalStorage { get; set; }

        /// <summary>
        /// The available (unused) memory on the terminal.
        /// </summary>
        [JsonProperty(PropertyName = "availableMemory")]
        public int AvailableMemory { get; set; }

        /// <summary>
        /// The available (unused) storage on the terminal.
        /// </summary>
        [JsonProperty(PropertyName = "availableStorage")]
        public int AvailableStorage { get; set; }

        /// <summary>
        /// The memory currently in use on the terminal.
        /// </summary>
        [JsonProperty(PropertyName = "usedMemory")]
        public int UsedMemory { get; set; }

        /// <summary>
        /// The storage currently in use on the terminal.
        /// </summary>
        [JsonProperty(PropertyName = "usedStorage")]
        public int UsedStorage { get; set; }

        /// <summary>
        /// The branding asset currently displayed on the terminal.
        /// </summary>
        [JsonProperty(PropertyName = "brandingPreview")]
        public string BrandingPreview { get; set; }

        /// <summary>
        /// The id of the terminal group to which the terminal belongs, if any.
        /// </summary>
        [JsonProperty(PropertyName = "groupId")]
        public string GroupId { get; set; }

        /// <summary>
        /// The name of the terminal group to which the terminal belongs, if any.
        /// </summary>
        [JsonProperty(PropertyName = "groupName")]
        public string GroupName { get; set; }
    }
}
