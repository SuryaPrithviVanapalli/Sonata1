using FakeXrmEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xrm.Sdk;
using System;
using ZuoraCPQ.Plugins;

namespace PluginTest
{
    [TestClass]
    public class OnPostCreateofQuoteTest
    {
        XrmFakedContext fakedContext;
        IOrganizationService fakedService;
        XrmFakedTracingService fakedTracingService;
      //  Entity enTarget;
       // Entity PreImage;
        Entity Quote;
        Entity Opportunity;
        Entity Quoteline;
        public Guid Id { get; private set; }
        public string LogicalName { get; private set; }

        [TestInitialize]
        public void TestInit()
        {

            fakedContext = new XrmFakedContext();
            fakedService = fakedContext.GetOrganizationService();
            fakedTracingService = fakedContext.GetFakeTracingService();
            Opportunity = new Entity { Id = Guid.NewGuid(), LogicalName = "opportunity" };
            Quote = new Entity { Id = Guid.NewGuid(), LogicalName = "quote" };
            Quoteline = new Entity { Id = Guid.NewGuid(), LogicalName = "quotedetail" };
            Quote.Attributes["zuora_quotetype"] = 429550001;
            Quote.Attributes["opportunityid"] = Opportunity.ToEntityReference();
            Quote.Attributes["revisionnumber"] = "123456";
            Quoteline.Attributes["isproductoverridden"] = 0;
            Quoteline.Attributes["productid"] = "";
            Quoteline.Attributes["uomid"] = "";
            Quoteline.Attributes["ispriceoverridden"] = 0;
            Quoteline.Attributes["priceperunit"] = 1;
            Quoteline.Attributes["volumediscountamount"] = 125;
            Quoteline.Attributes["quantity"] = 1;
            Quoteline.Attributes["baseamount"] = 1;
            Quoteline.Attributes["manualdiscountamount"] = 1;
            Quoteline.Attributes["tax"] = null;
            Quoteline.Attributes["extendedamount"] = 1;
            Quoteline.Attributes["quoteid"] = Quote.ToEntityReference();
            Quoteline.Attributes["zuora_number"] = "123";
        }

        [TestMethod]
        public void When_user_clicks_on_send_quote_to_zuora()
        {
            var fakecontext = new XrmFakedContext();
            var quote = new Entity();
            {
                Id = Guid.NewGuid();
                LogicalName = "quote";
            }
            var result = fakedService.Create(Quoteline);
            // Assert

            Assert.AreNotEqual(result, null);

        }
    }
}
