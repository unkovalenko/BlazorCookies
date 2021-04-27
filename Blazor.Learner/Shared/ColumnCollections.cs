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
                c.Add(o => o.EC_ID).SetPrimaryKey(true).Titled("ID").SetWidth(10).Max(true);
                c.Add(o => o.EC_DATE, "OrderCustomDate").Titled(Constants.DATE).Min(true)
                //.SetWidth(120).RenderComponentAs<TooltipCell>()
                ;
                c.Add(o => o.EC_REM).Titled(Constants.REM).SetWidth(250);
               // c.Add(o => o.EC_ID).Encoded(false).Sanitized(false)
               //  .RenderValueAs(o => $"<div class='btn-group'><button type = 'button' class='btn btn-primary' @onclick='ButtonClick' >Apple</button> <button type = 'button' class='btn btn-primary'>Samsung</button>  <button type = 'button' class='btn btn-primary'>Sony</button></div>");


            };
        }
    }
