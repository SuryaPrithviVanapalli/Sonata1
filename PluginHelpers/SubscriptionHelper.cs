// <copyright file="SubscriptionHelper.cs" company="Zuora">
// Copyright (c) 2022 All Rights Reserved
// </copyright>

namespace ZuoraCPQ.BusinessProcesses.PluginHelpers
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Subscription Helper
    /// </summary>
    public class SubscriptionHelper
    {
        /// <summary>
        /// Gets or sets the Quote Number
        /// </summary>
        public string QuoteNumber { get; set; }

        /// <summary>
        /// Gets or sets the Order Date
        /// </summary>
        public string OrderDate { get; set; }

        /// <summary>
        /// Gets or sets the Account Details
        /// </summary>
        public string AccountDetails { get; set; }

        /// <summary>
        /// Gets or sets the Contract Effective Trigger Date
        /// </summary>
        public string ContractEffectiveTriggerDate { get; set; }

        /// <summary>
        /// Gets or sets the Service Activation Trigger Date
        /// </summary>
        public string ServiceActivationTriggerDate { get; set; }

        /// <summary>
        /// Gets or sets the Customer Acceptance Trigger Date
        /// </summary> 
        public string CustomerAcceptanceTriggerDate { get; set; }

        /// <summary>
        /// Gets or sets the Initial Term
        /// </summary>
        public InitialTerm InitialTerm { get; set; }

        /// <summary>
        /// Gets or sets the Renewal Terms
        /// </summary>
        public RenewalTerms RenewalTerms { get; set; }

        /// <summary>
        /// Gets or sets the InVoice Separately
        /// </summary>
        public string InVoiceSeparately { get; set; }

        /// <summary>
        /// Gets or sets the Quote Type
        /// </summary>
        public string QuoteType { get; set; }

        /// <summary>
        /// Gets or sets the Auto Renew
        /// </summary>
        public string AutoRenew { get; set; }

        /// <summary>
        /// Gets or sets the Quote type
        /// </summary>
        public string Quotetype { get; set; }

        /// <summary>
        /// Gets or sets the Quote type
        /// </summary>
        private string terms = string.Empty;

        /// <summary>
        /// Get Subscription Details
        /// </summary>
        /// <param name="subscription">subscription Parameter</param>
        /// <param name="accountJson">account JSON</param>
        /// <param name="productJson">product JSON</param>
        /// <returns>string return</returns>
        public string GetSubscriptionDetails(SubscriptionHelper subscription, string accountJson, string productJson)
        {
            if (this.InitialTerm.TermType == "EVERGREEN")
            {
                this.terms = "\"terms\": {\"initialTerm\": {\"startDate\": \"" + this.ContractEffectiveTriggerDate + "\",\"termType\": \"" + this.InitialTerm.TermType + "\"}}";
            }
            else
            {
                this.terms = "\"terms\": {\"autoRenew\": " + this.AutoRenew + ",\"initialTerm\": {\"startDate\": \"" + this.ContractEffectiveTriggerDate + "\",\"period\": " + this.InitialTerm.Period + "," +
                            "\"periodType\": \"" + this.InitialTerm.PeriodType + "\",\"termType\": \"" + this.InitialTerm.TermType + "\"},\"renewalSetting\": \"" + this.RenewalTerms.RenewalSetting + "\"," +
                            "\"renewalTerms\": [{\"period\": " + this.RenewalTerms.Period + ",\"periodType\": \"" + this.RenewalTerms.PeriodType + "\"}]}";
            }

            string subscriptionJson = "{\"orderDate\": \"" + DateTime.Now.ToString("yyyy-MM-dd") + "\",\"subscriptions\": [{\"orderActions\": " +
                                 "[{\"type\": \"CreateSubscription\",\"triggerDates\": [{\"name\": \"ContractEffective\",\"triggerDate\": \"" + this.ContractEffectiveTriggerDate + "\"}," +
                                 "{\"name\": \"ServiceActivation\",\"triggerDate\": \"\"},{\"name\": \"CustomerAcceptance\",\"triggerDate\": \"\"}]," +
                                 "\"createSubscription\": {\"invoiceSeparately\":" + this.InVoiceSeparately + "," + this.terms + ",\"subscribeToRatePlans\": [" +
                                 "" + productJson.Remove(productJson.Length - 1) + "]}}]}],\"processingOptions\": {\"runBilling\": false,\"collectPayment\": false}," + accountJson + "}";
            return subscriptionJson;
        }
    }

    /// <summary>
    /// Initial Term
    /// </summary>
    public class InitialTerm
    {
        /// <summary>
        /// Gets or sets the Start Date
        /// </summary>
        public string StartDate { get; set; }

        /// <summary>
        /// Gets or sets the Period Type
        /// </summary>
        public string PeriodType { get; set; }

        /// <summary>
        /// Gets or sets the Period
        /// </summary>
        public int Period { get; set; }

        /// <summary>
        /// Gets or sets the TermType
        /// </summary>
        public string TermType { get; set; }
    }

    /// <summary>
    /// Renewal Terms
    /// </summary>
    public class RenewalTerms
    {
        /// <summary>
        /// Gets or sets the Period
        /// </summary>
        public int Period { get; set; }

        /// <summary>
        /// Gets or sets the Period Type
        /// </summary>
        public string PeriodType { get; set; }

        /// <summary>
        /// Gets or sets the Renewal Setting
        /// </summary>
        public string RenewalSetting { get; set; }
    }

    /// <summary>
    /// Rate Plans
    /// </summary>
    public class RatePlans
    {
        /// <summary>
        /// Gets or sets the Product Rate Plan Id
        /// </summary>
        public string ProductRatePlanId { get; set; }
    }

    /// <summary>
    /// Product Class
    /// </summary>
    public class ProductClass
    {
        /// <summary>
        /// Gets or sets the Rate Plan Charge Id
        /// </summary>
        public string RatePlanChargeId { get; set; }

        /// <summary>
        /// Gets or sets the Rate Plan Id
        /// </summary>
        public string RatePlanId { get; set; }

        /// <summary>
        /// Gets or sets the Price
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the Quantity
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the Charge Model
        /// </summary>
        public string ChargeModel { get; set; }

        /// <summary>
        /// Gets or sets the Charge Type
        /// </summary>
        public string ChargeType { get; set; }

        /// <summary>
        /// Gets or sets the Charge Number
        /// </summary>
        public string ChargeNumber { get; set; }

        /// <summary>
        /// Gets or sets the Billing Details
        /// </summary>
        public BillingDetails BillingDetails { get; set; }

        /// <summary>
        /// Return Charge Model Type
        /// </summary>
        /// <param name="_chargeModel">charge Model</param>
        /// <param name="_chargeType">charge Type</param>
        /// <returns>string return</returns>
        public string ReturnChrgeModelType(string _chargeModel, string _chargeType)
        {
            string _chargeModelTeype = string.Empty;
            if (_chargeModel == "Flat Fee Pricing" && _chargeType == "One Time")
            {
                _chargeModelTeype = "oneTimeFlatFee";
            }
            else if (_chargeModel == "Per Unit Pricing" && _chargeType == "One Time")
            {
                _chargeModelTeype = "oneTimePerUnit";
            }
            else if (_chargeModel == "Flat Fee Pricing" && _chargeType == "Recurring")
            {
                _chargeModelTeype = "recurringFlatFee";
            }
            else if (_chargeModel == "Per Unit Pricing" && _chargeType == "Recurring")
            {
                _chargeModelTeype = "recurringPerUnit";
            }
            else
            {
                _chargeModelTeype = "Not available";
            }

            return _chargeModelTeype;
        }

        /// <summary>
        /// Get Product Details
        /// </summary>
        /// <param name="productBundleList">product Bundle List</param>
        /// <param name="productList">product List</param>
        /// <returns>string return</returns>
        public string GetProductDetails(List<string> productBundleList, List<ProductClass> productList)
        {
            string productRatePlanText = string.Empty;
            foreach (var productBundle in productBundleList)
            {
                productRatePlanText += "{\"productRatePlanId\": \"" + productBundle + "\",\"chargeOverrides\":[";
                foreach (var product in productList)
                {
                    if (productBundle == product.RatePlanId)
                    {
                        string triggerConditionJson = string.Empty;
                        if (product.BillingDetails.TriggerCondition == "SpecificDate")
                        {
                            triggerConditionJson = ",\"startDate\":{\"triggerEvent\":\"" + product.BillingDetails.TriggerCondition + "\",\"specificTriggerDate\":\"" + product.BillingDetails.SpecificTriggerDate + "\"}";
                        }
                        else if (product.BillingDetails.TriggerCondition == "ContractEffective" || product.BillingDetails.TriggerCondition == "ServiceActivation" || product.BillingDetails.TriggerCondition == "CustomerAcceptance")
                        {
                            triggerConditionJson = ",\"startDate\":{\"triggerEvent\":\"" + product.BillingDetails.TriggerCondition + "\"}";
                        }
                        else
                        {
                            triggerConditionJson = string.Empty;
                        }

                        string specificBillingPeriodjson = string.Empty;
                        if (product.BillingDetails.BillingPeriod == "Specific_Months" || product.BillingDetails.BillingPeriod == "Specific_Weeks")
                        {
                            specificBillingPeriodjson = ",\"specificBillingPeriod\":\"" + product.BillingDetails.SpecificBillingPeriod + "\"";
                        }

                        string weeklyBillCycleDayJson = string.Empty;
                        if (product.BillingDetails.BillCycleType == "SpecificDayofWeek")
                        {
                            weeklyBillCycleDayJson = ",\"weeklyBillCycleDay\":\"" + product.BillingDetails.WeeklyBillCycleDay + "\"";
                        }

                        string billCycleTypeJson = string.Empty;
                        if (product.BillingDetails.BillCycleType == "SpecificDayofMonth")
                        {
                            billCycleTypeJson = ",\"billCycleDay\":\"" + product.BillingDetails.BillCycleDay + "\"";
                        }

                        string fixedPeriodJson = string.Empty;
                        if (product.BillingDetails.EndDateCondition == "Fixed_Period")
                        {
                            fixedPeriodJson = ",\"upToPeriods\":\"" + product.BillingDetails.UpToPeriods + "\"," +
                                    "\"upToPeriodsType\":\"" + product.BillingDetails.UpToPeriodsType + "\"";
                        }
                        else if (product.BillingDetails.EndDateCondition == "Specific_End_Date")
                        {
                            fixedPeriodJson = ",\"specificEndDate\":\"" + product.BillingDetails.SpecificEndDate + "\"";
                        }
                        else
                        {
                            fixedPeriodJson = string.Empty;
                        }

                        string JsonBillingdetails = string.Empty;
                        string endDate = string.Empty;
                        productRatePlanText += " {\"productRatePlanChargeId\":\"" + product.RatePlanChargeId + "\",\"chargeNumber\":\"" + product.ChargeNumber + "\"" + triggerConditionJson;
                        string chargeModelType = this.ReturnChrgeModelType(product.ChargeModel, product.ChargeType);
                        if (chargeModelType == "oneTimeFlatFee")
                        {
                            JsonBillingdetails = ",\"billing\": {}";
                            endDate = ",\"endDate\":{}";
                            productRatePlanText += JsonBillingdetails + endDate + ",\"pricing\":{\"oneTimeFlatFee\":{\"listPrice\":\"" + product.Price + "\"}}";
                        }
                        else if (chargeModelType == "oneTimePerUnit")
                        {
                            JsonBillingdetails = ",\"billing\": {}";
                            endDate = ",\"endDate\":{}";
                            productRatePlanText += JsonBillingdetails + endDate + ",\"pricing\":{\"oneTimePerUnit\":{\"listPrice\":\"" + product.Price + "\",\"quantity\":\"" + product.Quantity + "\"}}";
                        }
                        else if (chargeModelType == "recurringFlatFee")
                        {
                            JsonBillingdetails = ",\"billing\": {" +
                                     "\"billCycleType\":\"" + product.BillingDetails.BillCycleType + "\"," +
                                     "\"billingPeriod\":\"" + product.BillingDetails.BillingPeriod + "\"," +
                                     "\"billingPeriodAlignment\":\"" + product.BillingDetails.BillingPeriodAlignment + "\"," +
                                     "\"billingTiming\":\"" + product.BillingDetails.BillingTiming + "\"" + specificBillingPeriodjson + weeklyBillCycleDayJson + billCycleTypeJson +
                                    "}";
                            if (string.IsNullOrEmpty(product.BillingDetails.EndDateCondition))
                            {
                                endDate = string.Empty;
                            }
                            else
                            {
                                endDate = ",\"endDate\":{" +
                                "\"endDateCondition\":\"" + product.BillingDetails.EndDateCondition + "\"" + fixedPeriodJson + "}";
                            }

                            productRatePlanText += JsonBillingdetails + endDate + ",\"pricing\":{\"oneTimePerUnit\":{\"listPrice\":\"" + product.Price + "\"}}";
                        }
                        else if (chargeModelType == "recurringPerUnit")
                        {
                            JsonBillingdetails = ",\"billing\": {" +
                                    "\"billCycleType\":\"" + product.BillingDetails.BillCycleType + "\"," +
                                    "\"billingPeriod\":\"" + product.BillingDetails.BillingPeriod + "\"," +
                                    "\"billingPeriodAlignment\":\"" + product.BillingDetails.BillingPeriodAlignment + "\"," +
                                    "\"billingTiming\":\"" + product.BillingDetails.BillingTiming + "\"" + specificBillingPeriodjson + weeklyBillCycleDayJson + billCycleTypeJson +
                                   "}";
                            if (string.IsNullOrEmpty(product.BillingDetails.EndDateCondition))
                            {
                                endDate = string.Empty;
                            }
                            else
                            {
                                endDate = ",\"endDate\":{" +
                                "\"endDateCondition\":\"" + product.BillingDetails.EndDateCondition + "\"" + fixedPeriodJson + "}";
                            }

                            productRatePlanText += JsonBillingdetails + endDate + ",\"pricing\":{\"oneTimePerUnit\":{\"listPrice\":\"" + product.Price + "\",\"quantity\":\"" + product.Quantity + "\"}}";
                        }

                        productRatePlanText += "},";
                    }
                }

                productRatePlanText += "]},";
            }

            productRatePlanText = productRatePlanText.Replace("},]", "}]");
            return productRatePlanText;
        }
    }

    /// <summary>
    /// Billing Details Class
    /// </summary>
    public class BillingDetails
    {
        /// <summary>
        /// Gets or sets the Bill Cycle Day
        /// </summary>
        public string BillCycleDay { get; set; }

        /// <summary>
        /// Gets or sets the Bill Cycle Type
        /// </summary>
        public string BillCycleType { get; set; }

        /// <summary>
        /// Gets or sets the Billing Period
        /// </summary>
        public string BillingPeriod { get; set; }

        /// <summary>
        /// Gets or sets the Billing Period Alignment
        /// </summary>
        public string BillingPeriodAlignment { get; set; }

        /// <summary>
        /// Gets or sets the Billing Timing
        /// </summary>
        public string BillingTiming { get; set; }

        /// <summary>
        /// Gets or sets the Specific Billing Period
        /// </summary>
        public string SpecificBillingPeriod { get; set; }

        /// <summary>
        /// Gets or sets the Weekly Bill Cycle Day
        /// </summary>
        public string WeeklyBillCycleDay { get; set; }

        /// <summary>
        /// Gets or sets the End Date Condition
        /// </summary>
        public string EndDateCondition { get; set; }

        /// <summary>
        /// Gets or sets the UpTo Periods
        /// </summary>
        public int UpToPeriods { get; set; }

        /// <summary>
        /// Gets or sets the UpTo Periods Type
        /// </summary>
        public string UpToPeriodsType { get; set; }

        /// <summary>
        /// Gets or sets the Specific End Date
        /// </summary>
        public string SpecificEndDate { get; set; }

        /// <summary>
        /// Gets or sets the Trigger Condition
        /// </summary>
        public string TriggerCondition { get; set; }

        /// <summary>
        /// Gets or sets the Specific Trigger Date
        /// </summary>
        public string SpecificTriggerDate { get; set; }
    }

    /// <summary>
    /// Amendment History Class
    /// </summary>
    public class AmendmentHistory
    {
        /// <summary>
        /// Gets or sets the Subscription Number
        /// </summary>
        public string SubscriptionNumber { get; set; }

        /// <summary>
        /// Gets or sets the Contract Effective Trigger Date
        /// </summary>
        public string ContractEffectiveTriggerDate { get; set; }

        /// <summary>
        /// Gets or sets the Service Activation trigger Date
        /// </summary>
        public string ServiceActivationtriggerDate { get; set; }

        /// <summary>
        /// Gets or sets the Customer Acceptance trigger Date
        /// </summary>
        public string CustomerAcceptancetriggerDate { get; set; }
    }

    /// <summary>
    /// Cancellation Policy Details Class
    /// </summary>
    public class CancellationPolicyDetails : AmendmentHistory
    {
        /// <summary>
        /// Gets or sets the Cancellation Policy
        /// </summary>
        public string CancellationPolicy { get; set; }

        /// <summary>
        /// Gets or sets the Cancellation Effective Date
        /// </summary>
        public string CancellationEffectiveDate { get; set; }

        /// <summary>
        /// Get Cancellation Policy
        /// </summary>
        /// <param name="accountNumber">account Number</param>
        /// <returns>string return</returns>
        public string GetCancellationPolicy(string accountNumber)
        {
            return "{\"orderDate\": \"" + DateTime.Now.ToString("yyyy-MM-dd") + "\",\"existingAccountNumber\": \"" + accountNumber + "\",\"subscriptions\":[" +
                    "{\"subscriptionNumber\": \"" + this.SubscriptionNumber + "\",\"orderActions\":[{\"type\": \"CancelSubscription\"," +
                    "\"triggerDates\": [{\"name\": \"ContractEffective\",\"triggerDate\": \"" + this.ContractEffectiveTriggerDate + "\"},{\"name\": \"ServiceActivation\"," +
                    "\"triggerDate\": \"" + this.ServiceActivationtriggerDate + "\"},{\"name\": \"CustomerAcceptance\",\"triggerDate\": \"" + this.CustomerAcceptancetriggerDate + "\"}]," +
                    "\"cancelSubscription\": {\"cancellationPolicy\": \"" + this.CancellationPolicy + "\",\"cancellationEffectiveDate\": \"" + this.CancellationEffectiveDate + "\"" +
                    "}}]}],\"processingOptions\":{\"runBilling\": false,\"collectPayment\": false}}";
        }
    }

    /// <summary>
    /// Product Class
    /// </summary>
    public class RenewSubscription : AmendmentHistory
    {
        /// <summary>
        /// Get Renewal Details
        /// </summary>
        /// <param name="accountNumber">account Number</param>
        /// <returns>string return</returns>
        public string GetRenewalDetails(string accountNumber)
        {
            return "{\"orderDate\": \"" + DateTime.Now.ToString("yyyy-MM-dd") + "\",\"existingAccountNumber\": \"" + accountNumber + "\",\"subscriptions\":[{\"subscriptionNumber\": \"" + this.SubscriptionNumber + "\"," +
                    "\"orderActions\": [{\"type\": \"RenewSubscription\",\"triggerDates\": [{\"name\": \"ContractEffective\",\"triggerDate\": \"" + this.ContractEffectiveTriggerDate + "\"},{" +
                    "\"name\": \"ServiceActivation\",\"triggerDate\": \"" + this.ServiceActivationtriggerDate + "\"},{\"name\": \"CustomerAcceptance\",\"triggerDate\": \"" + this.CustomerAcceptancetriggerDate + "\"}]}]}]," +
                    "\"processingOptions\": {\"runBilling\": false,\"collectPayment\": false}}";
        }
    }

    /// <summary>
    /// Product Class
    /// </summary>
    public class SuspendSubscription : AmendmentHistory
    {
        /// <summary>
        /// Gets or sets the Suspend Policy
        /// </summary>
        public string SuspendPolicy { get; set; }

        /// <summary>
        /// Gets or sets the Suspend Specific Date
        /// </summary>
        public string SuspendSpecificDate { get; set; }

        /// <summary>
        /// Gets or sets the Suspend Periods
        /// </summary>
        public string SuspendPeriods { get; set; }

        /// <summary>
        /// Gets or sets the SuspendPeriods Type
        /// </summary>
        public string SuspendPeriodsType { get; set; }

        /// <summary>
        /// Get Suspend Details
        /// </summary>
        /// <param name="accountNumber">account Number</param>
        /// <returns>string return</returns>
        public string GetSupendDetails(string accountNumber)
        {
            return "{\"orderDate\": \"" + DateTime.Now.ToString("yyyy-MM-dd") + "\",\"existingAccountNumber\": \"" + accountNumber + "\",\"subscriptions\": [{" +
                   "\"subscriptionNumber\": \"" + this.SubscriptionNumber + "\",\"orderActions\":[{\"type\": \"Suspend\",\"suspend\": {" +
                   "\"suspendPolicy\": \"" + this.SuspendPolicy + "\",\"suspendSpecificDate\": \"" + this.SuspendSpecificDate + "\",\"suspendPeriods\":" + this.SuspendPeriods + "" +
                   ",\"suspendPeriodsType\":\"" + this.SuspendPeriodsType + "\"},\"triggerDates\": [{\"name\": \"ContractEffective\"," +
                   "\"triggerDate\": \"" + this.ContractEffectiveTriggerDate + "\"},{\"name\": \"ServiceActivation\",\"triggerDate\": \"" + this.ServiceActivationtriggerDate + "\"}," +
                   "{\"name\": \"CustomerAcceptance\",\"triggerDate\": \"" + this.CustomerAcceptancetriggerDate + "\"}]}]}],\"processingOptions\": {" +
                   "\"runBilling\": false,\"collectPayment\": false}}";
        }
    }

    /// <summary>
    /// Terms And Condition Subscription Class
    /// </summary>
    public class TermsAndConditionSubscription : AmendmentHistory
    {
        /// <summary>
        /// Gets or sets the Auto Renew
        /// </summary>
        public string AutoRenew { get; set; }

        /// <summary>
        /// Gets or sets the Renewal Setting
        /// </summary>
        public string RenewalSetting { get; set; }

        /// <summary>
        /// Gets or sets the Initial Term
        /// </summary>
        public InitialTerm InitialTerm { get; set; }

        /// <summary>
        /// Gets or sets the Renewal Term
        /// </summary>
        public RenewalTerms RenewalTerm { get; set; }

        /// <summary>
        /// Get Terms And Condition
        /// </summary>
        /// <param name="accountNumber">account Number</param>
        /// <returns>string return</returns>
        public string GetTermsAndCondition(string accountNumber)
        {
            return "{\"orderDate\": \"" + DateTime.Now.ToString("yyyy-MM-dd") + "\",\"subscriptions\": [{\"orderActions\": [{" +
                    "\"type\": \"TermsAndConditions\",\"termsAndConditions\": {\"autoRenew\": " + this.AutoRenew + "," +
                    "\"lastTerm\": {\"period\": " + this.InitialTerm.Period + ",\"periodType\": \"" + this.InitialTerm.PeriodType + "\",\"startDate\": \"" + this.InitialTerm.StartDate + "\"," +
                    "\"termType\": \"" + this.InitialTerm.TermType + "\"},\"renewalSetting\": \"" + this.RenewalSetting + "\"," +
                    "\"renewalTerms\":[{\"period\": " + this.RenewalTerm.Period + ",\"periodType\": \"" + this.RenewalTerm.PeriodType + "\"}]}}],\"subscriptionNumber\":" +
                    "\"" + this.SubscriptionNumber + "\"}],\"existingAccountNumber\": \"" + accountNumber + "\"}";
        }
    }

    /// <summary>
    /// Remove Product From Subscription Class
    /// </summary>
    public class RemoveProductFromSubscription : AmendmentHistory
    {
        /// <summary>
        /// Gets or sets the Product
        /// </summary>
        public ProductClass Product { get; set; }

        /// <summary>
        /// Gets or sets the Products
        /// </summary>
        public List<ProductClass> Products { get; set; }

        /// <summary>
        /// Remove Product
        /// </summary>
        /// <param name="accountNumber">account Number</param>
        /// <returns>string parameter</returns>
        public string RemoveProduct(string accountNumber)
        {
            string jsonForRatePlanId = string.Empty;
            string jsonForRemoveProduct = string.Empty;
            foreach (var product in Products)
            {
                jsonForRatePlanId += "{\"ratePlanId\": \"" + product.RatePlanId + "\"},";
            }

            jsonForRemoveProduct = "{\"orderDate\": \"$Today\",\"existingAccountNumber\": \"" + accountNumber + "\",\"subscriptions\": [" +
                                  "{\"subscriptionNumber\": \"" + this.SubscriptionNumber + "\",\"orderActions\": [{\"type\": \"RemoveProduct\"," +
                                  "\"triggerDates\": [{\"name\": \"ContractEffective\",\"triggerDate\": \"" + this.ContractEffectiveTriggerDate + "\"},{\"name\": \"ServiceActivation\"," +
                                  "\"triggerDate\": \"" + this.ServiceActivationtriggerDate + "\"},{\"name\": \"CustomerAcceptance\",\"triggerDate\": \"" + this.CustomerAcceptancetriggerDate + "\"}],\"removeProduct\":" +
                                  "" + jsonForRatePlanId.Remove(jsonForRemoveProduct.Length - 1) + "}]}],\"processingOptions\": {\"runBilling\": false,\"collectPayment\": false}}";
            return jsonForRemoveProduct;
        }
    }
}
