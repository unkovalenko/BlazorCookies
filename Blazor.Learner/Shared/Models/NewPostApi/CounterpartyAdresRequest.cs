using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;


namespace BlazorCookies.Shared.Models
{
    public class CounterpartyAdresRequest : NPRequest
    {
        public CounterpartyAdresRequest(IConfiguration configuration, string aref) : base(configuration)
        {
            this.modelName = "Counterparty";
            this.calledMethod = "getCounterpartyAddresses";
            methodProperties = new Methodproperties();
            methodProperties.CounterpartyProperty = "Recipient";
            methodProperties.Ref = aref;
        }
        public Methodproperties methodProperties { get; set; }
    }

    public class Methodproperties
    {
        public string Ref { get; set; }
        public string CounterpartyProperty { get; set; }
       
    }


    public class CounterpartyAdres
    {
        public bool success { get; set; }
        public CounterpartyAdresData[] data { get; set; }
        public object[] errors { get; set; }
        public object[] warnings { get; set; }
        public CounterpartyAdresInfo info { get; set; }
        public object[] messageCodes { get; set; }
        public object[] errorCodes { get; set; }
        public object[] warningCodes { get; set; }
        public object[] infoCodes { get; set; }
    }

    public class CounterpartyAdresInfo
    {
        public int totalCount { get; set; }
    }

    public class CounterpartyAdresData
    {
        public string Ref { get; set; }
        public string Description { get; set; }
        public string CityRef { get; set; }
        public string CityDescription { get; set; }
        public string StreetRef { get; set; }
        public string StreetDescription { get; set; }
        public string BuildingRef { get; set; }
        public string BuildingDescription { get; set; }
        public string Note { get; set; }
        public string AddressName { get; set; }
    }

}
