using System;
using System.Collections.Generic;
using System.Text;
using GridShared;
using BlazorCookies.Models;


    namespace BlazorCookies.Shared
    {
        public class ColumnCollections
        {
            public const string CompanyNameFilter = "CompanyNameFilter";

            public static Action<IGridColumnCollection<EXCHCHECK>> ExchcheckColumns = c =>
            {
                c.Add(o => o.EC_ID).Titled("ID").SetWidth(10);
                c.Add(o => o.EC_DATE, "OrderCustomDate").Titled(Constants.DATE)
                //.SetWidth(120).RenderComponentAs<TooltipCell>()
                ;
                c.Add(o => o.EC_REM).Titled(Constants.REM).SetWidth(250);


            };
        }
    }
