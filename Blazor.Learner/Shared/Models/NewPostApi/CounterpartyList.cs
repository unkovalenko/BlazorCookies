using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;


namespace BlazorCookies.Shared.Models
{

    //  result request
    public class CounterpartyList
    {
        public bool success { get; set; }
        public CounterpartyData[] data { get; set; }
        public object[] errors { get; set; }
        public object[] warnings { get; set; }
        public CounterpartyListInfo info { get; set; }
        public object[] messageCodes { get; set; }
        public object[] errorCodes { get; set; }
        public object[] warningCodes { get; set; }
        public object[] infoCodes { get; set; }
    }

    public class CounterpartyListInfo
    {
        public int totalCount { get; set; }
    }


    public class CounterpartyData
    {
        public string Description { get; set; }
        public string Ref { get; set; }
        public string City { get; set; }
        public object Counterparty { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string OwnershipFormRef { get; set; }
        public string OwnershipFormDescription { get; set; }
        public string EDRPOU { get; set; }
        public string CounterpartyType { get; set; }
    }

    //  request to API NP
    public class CountepartyListReqwest : NPRequest
    {
        public CountepartyListReqwest(IConfiguration configuration,string findbystring="") : base(configuration)
        {
            this.modelName = "Counterparty";
            this.calledMethod = "getCounterparties";
            methodProperties = new CounterPartyListReuestProperty();
            methodProperties.FindByString = findbystring;
             
    }
        public CounterPartyListReuestProperty methodProperties { get; set; }
    }

    public class CounterPartyListReuestProperty
    {
        public string CounterpartyProperty { get; set; } = "Recipient";
        public string Page { get; set; } = "1";
        public string FindByString { get; set; } = "";
    }
}
