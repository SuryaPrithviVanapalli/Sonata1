// <copyright file="D365FieldConfigurationSettings.cs" company="Zuora">
// Copyright (c) 2022 All Rights Reserved
// </copyright>

namespace ZuoraCPQ.Commons.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Configuration settings
    /// </summary>
    public class D365FieldConfigurationSettings
    {
        /// <summary>
        /// Entity Logical Name
        /// </summary>
        public const string LogicalName = "zuora_fieldconfigurationsettings";

        /// <summary>
        /// Entity Id
        /// </summary>
        public const string Id = "zuora_fieldconfigurationsettingsid";

        /// <summary>
        /// D365 Entity Name
        /// </summary>
        public const string D365EntityName = "zuora_d365entityname";

        /// <summary>
        /// ZUORA API Method
        /// </summary>
        public const string ZuoraApiMethod = "zuora_zuoraapimethod";

        /// <summary>
        /// D365 Field Schema Name
        /// </summary>
        public const string D365FieldSchemaName = "zuora_d365fieldschemaname";

        /// <summary>
        /// ZUORA Field Name
        /// </summary>
        public const string ZuoraFieldName = "zuora_fieldname";

        /// <summary>
        /// D365 Field Type
        /// </summary>
        public const string D365FieldType = "zuora_d365fieldtype";

        /// <summary>
        /// D365 Look Up Field Mapping
        /// </summary>
        public const string D365LookUpFieldMapping = "zuora_d365lookupfieldmapping";
    }
}
