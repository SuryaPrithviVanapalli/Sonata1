// <copyright file="AccountBase.cs" company="Zuora">
// Copyright (c) 2022 All Rights Reserved
// </copyright>

namespace ZuoraCPQ.Commons.Entities
{
    /// <summary>
    /// Account Entity Class
    /// </summary>
    public static class AccountBase
    {
        /// <summary>
        /// Entity Logical Name
        /// </summary>
        public const string LogicalName = "account";

        /// <summary>
        /// Entity Id
        /// </summary>
        public const string Id = "accountid";

        /// <summary>
        /// ZUORA Account Number
        /// </summary>
        public const string ZuoraAccountNumber = "zuora_zuoraaccountnumber";

        /// <summary>
        /// Account Number
        /// </summary>
        public const string AccountNumber = "accountnumber";

        /// <summary>
        /// Payment Terms Code
        /// </summary>
        public const string PaymentTermsCode = "paymenttermscode";

        /// <summary>
        /// Bill Cycle Day
        /// </summary>
        public const string BillCycleDay = "zuora_billcycleday";

        /// <summary>
        /// Invoice Template Id
        /// </summary>
        public const string InvoiceTemplateId = "zuora_invoicetemplateid";

        /// <summary>
        /// Credit Memo Template
        /// </summary>
        public const string CreditMemoTemplate = "zuora_creditmemotemplate";

        /// <summary>
        /// Debit Memo Template
        /// </summary>
        public const string DebitMemoTemplate = "zuora_debitmemotemplate";

        /// <summary>
        /// The Batch
        /// </summary>
        public const string Batch = "zuora_batch";

        /// <summary>
        /// Customer Service Rep
        /// </summary>
        public const string CustomerServiceRep = "zuora_customerservicerep";

        /// <summary>
        /// Invoice Delivery Preference
        /// </summary>
        public const string InvoiceDeliveryPreference = "zuora_invoicedeliverypreference";

        /// <summary>
        /// The Owner
        /// </summary>
        public const string Owner = "ownerid";

        /// <summary>
        /// The name
        /// </summary>
        public const string Name = "name";
    }
}
