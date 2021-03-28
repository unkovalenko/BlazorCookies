using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace BlazorCookies.Shared.Models
{
    public class ContactPersonCounterparty
    {
        public bool success { get; set; }
        public ContactPersonCounterpartyDatum[] data { get; set; }
        public object[] errors { get; set; }
        public object[] warnings { get; set; }
        public ContactPersonCounterpartyInfo info { get; set; }
        public object[] messageCodes { get; set; }
        public object[] errorCodes { get; set; }
        public object[] warningCodes { get; set; }
        public object[] infoCodes { get; set; }
    }

    public class ContactPersonCounterpartyInfo
    {
        public int totalCount { get; set; }
    }

    public class ContactPersonCounterpartyDatum
    {
        public string Description { get; set; }
        public string Phones { get; set; }
        public string Email { get; set; }
        public string Ref { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
    }


//     Request
    public class ContactPersonRequest:NPRequest
    {
        public ContactPersonRequest(IConfiguration configuration,string refperson):base(configuration) 
        {
            this.modelName = "Counterparty";
            this.calledMethod = "getCounterpartyContactPersons";
            methodProperties = new ContactPersonRequestMethodproperties();
            methodProperties.Ref = refperson;
            methodProperties.Page = "1";
        }
        public ContactPersonRequestMethodproperties methodProperties { get; set; }
    }

    public class ContactPersonRequestMethodproperties
    {
        public string Ref { get; set; }
        public string Page { get; set; }
    }

}
