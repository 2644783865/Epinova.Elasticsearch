﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ASP
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Web;
    using System.Web.Helpers;
    using System.Web.Mvc;
    using System.Web.Mvc.Ajax;
    using System.Web.Mvc.Html;
    using System.Web.Routing;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.WebPages;
    using Epinova.ElasticSearch.Core.EPiServer.Extensions;
    using Epinova.ElasticSearch.Core.EPiServer.Models.ViewModels;
    using Epinova.ElasticSearch.Core.Models.Admin;
    using EPiServer;
    using EPiServer.Core;
    using EPiServer.Editor;
    using EPiServer.Security;
    using EPiServer.SpecializedProperties;
    using EPiServer.Web;
    using EPiServer.Web.Mvc.Html;
    using EPiServer.Web.Routing;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/ElasticSearchAdmin/Tracking/Index.cshtml")]
    public partial class _Views_ElasticSearchAdmin_Tracking_Index_cshtml : System.Web.Mvc.WebViewPage<TrackingViewModel>
    {
        public _Views_ElasticSearchAdmin_Tracking_Index_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

WriteLiteral("\r\n");

  
    Layout = "~/Views/ElasticSearchAdmin/_ElasticSearch.cshtml";

WriteLiteral("\r\n\r\n");

 if (Model == null)
{
    return;
}

WriteLiteral("\r\n");

DefineSection("Styles", () => {

WriteLiteral("\r\n    <style>\r\n        #tabContainer .field-actions {\r\n            width: 120px;\r" +
"\n            text-align: center;\r\n        }\r\n\r\n        .dgrid {\r\n            max" +
"-width: 600px;\r\n        }\r\n    </style>\r\n");

});

WriteLiteral("\r\n");

  
    string localizationPath = "/epinovaelasticsearch/tracking/";

WriteLiteral("\r\n\r\n<div");

WriteLiteral(" id=\"tabContainer\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" data-dojo-type=\"dijit/layout/TabContainer\"");

WriteLiteral(" doLayout=\"false\"");

WriteLiteral(">\r\n");

        
         foreach (TrackingLanguage lang in Model.Languages)
        {

WriteLiteral("            <div");

WriteLiteral(" data-dojo-type=\"dijit/layout/ContentPane\"");

WriteAttribute("title", Tuple.Create(" title=\"", 900), Tuple.Create("\"", 926)
, Tuple.Create(Tuple.Create("", 908), Tuple.Create<System.Object, System.Int32>(lang.LanguageName
, 908), false)
);

WriteLiteral(" data-dojo-props=\"");

                                                                                                   Write(lang.LanguageId == Model.CurrentLanguage ? "selected:true" : null);

WriteLiteral("\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"epi-padding-small\"");

WriteLiteral(">\r\n");

                    
                     if (lang.Indices.Count > 1)
                    {

WriteLiteral("                        <div");

WriteLiteral(" class=\"epi-groupedButtonContainer\"");

WriteLiteral(">\r\n                            <h2>");

                           Write(Html.TranslateWithPathRaw("index", localizationPath));

WriteLiteral("</h2>\r\n\r\n");

                            
                             foreach (var index in lang.Indices)
                            {
                                var indexName = $"{index.Key}-{lang.LanguageId}";
                                if (indexName == ViewBag.SelectedIndex)
                                {

WriteLiteral("                                    <span>");

                                     Write(index.Value);

WriteLiteral("</span>\r\n");

                                }
                                else
                                {

WriteLiteral("                                    <a");

WriteLiteral(" class=\"epi-visibleLink\"");

WriteAttribute("href", Tuple.Create(" href=\"", 1820), Tuple.Create("\"", 1872)
, Tuple.Create(Tuple.Create("", 1827), Tuple.Create("?index=", 1827), true)
, Tuple.Create(Tuple.Create("", 1834), Tuple.Create<System.Object, System.Int32>(indexName
, 1834), false)
, Tuple.Create(Tuple.Create("", 1844), Tuple.Create("&languageId=", 1844), true)
                  , Tuple.Create(Tuple.Create("", 1856), Tuple.Create<System.Object, System.Int32>(lang.LanguageId
, 1856), false)
);

WriteLiteral(">");

                                                                                                               Write(index.Value);

WriteLiteral("</a>\r\n");

                                }
                            }

WriteLiteral("                        </div>\r\n");

                    }

WriteLiteral("\r\n                    <h2>");

                   Write(Html.TranslateWithPath("searches", localizationPath));

WriteLiteral("</h2>\r\n                    <div");

WriteAttribute("id", Tuple.Create(" id=\"", 2123), Tuple.Create("\"", 2156)
, Tuple.Create(Tuple.Create("", 2128), Tuple.Create<System.Object, System.Int32>(lang.LanguageId
, 2128), false)
, Tuple.Create(Tuple.Create("", 2146), Tuple.Create("-wordsGrid", 2146), true)
);

WriteLiteral("></div>\r\n                    <h2>");

                   Write(Html.TranslateWithPath("searchesnohits", localizationPath));

WriteLiteral("</h2>\r\n                    <div");

WriteAttribute("id", Tuple.Create(" id=\"", 2280), Tuple.Create("\"", 2314)
, Tuple.Create(Tuple.Create("", 2285), Tuple.Create<System.Object, System.Int32>(lang.LanguageId
, 2285), false)
, Tuple.Create(Tuple.Create("", 2303), Tuple.Create("-nohitsGrid", 2303), true)
);

WriteLiteral("></div>\r\n\r\n");

                    
                     using (Html.BeginForm("Clear", "ElasticTracking"))
                    {

WriteLiteral("                        <input");

WriteLiteral(" type=\"hidden\"");

WriteLiteral(" name=\"LanguageID\"");

WriteAttribute("value", Tuple.Create(" value=\"", 2484), Tuple.Create("\"", 2508)
, Tuple.Create(Tuple.Create("", 2492), Tuple.Create<System.Object, System.Int32>(lang.LanguageId
, 2492), false)
);

WriteLiteral(" />\r\n");

WriteLiteral("                        <input");

WriteLiteral(" type=\"hidden\"");

WriteLiteral(" name=\"index\"");

WriteAttribute("value", Tuple.Create(" value=\"", 2571), Tuple.Create("\"", 2601)
, Tuple.Create(Tuple.Create("", 2579), Tuple.Create<System.Object, System.Int32>(ViewBag.SelectedIndex
, 2579), false)
);

WriteLiteral(" />\r\n");

WriteLiteral("                        <p>&nbsp;</p>\r\n");

WriteLiteral("                        <p>\r\n                            <button");

WriteLiteral(" data-dojo-type=\"dijit/form/Button\"");

WriteAttribute("onClick", Tuple.Create("\r\n                                    onClick=\"", 2745), Tuple.Create("\"", 2868)
, Tuple.Create(Tuple.Create("", 2792), Tuple.Create("return", 2792), true)
, Tuple.Create(Tuple.Create(" ", 2798), Tuple.Create("confirm(\'", 2799), true)
, Tuple.Create(Tuple.Create("", 2808), Tuple.Create<System.Object, System.Int32>(Html.TranslateWithPath("clearconfirm", localizationPath)
, 2808), false)
, Tuple.Create(Tuple.Create("", 2865), Tuple.Create("\');", 2865), true)
);

WriteLiteral("\r\n                                    type=\"submit\"");

WriteLiteral("\r\n                                    class=\"epi-primary\"");

WriteAttribute("disabled", Tuple.Create("\r\n                                    disabled=\"", 2977), Tuple.Create("\"", 3052)
, Tuple.Create(Tuple.Create("", 3025), Tuple.Create<System.Object, System.Int32>(lang.Searches.Count == 0
, 3025), false)
);

WriteLiteral(">\r\n");

WriteLiteral("                                ");

                           Write(Html.TranslateWithPath("clear", localizationPath));

WriteLiteral("\r\n                            </button>\r\n                        </p>\r\n");

                    }

WriteLiteral("                </div>\r\n            </div>\r\n");

        }

WriteLiteral(@"    </div>
</div>


<script>
    function htmlDecode(input) {
        var doc = new DOMParser().parseFromString(input, ""text/html"");
        return doc.documentElement.textContent;
    }

    require(
        [""dojo/_base/declare"", ""dgrid/Grid"", ""dijit/form/Button"", ""dojo/domReady!""],
        function (declare, Grid) {
");

            
             foreach (var lang in Model.Languages)
            {

WriteLiteral("                ");

WriteLiteral("\r\n                new Grid({\r\n                        \"class\": \"epi-grid-height--" +
"300 epi-grid--with-border\",\r\n                        columns: {\r\n               " +
"             word: \"");

                              Write(Html.Raw(Html.TranslateWithPath("searchword", localizationPath)));

WriteLiteral("\",\r\n                            count: \"");

                               Write(Html.Raw(Html.TranslateWithPath("count", localizationPath)));

WriteLiteral("\"\r\n                        }\r\n                    }, \"");

                    Write(lang.LanguageId);

WriteLiteral("-wordsGrid\")\r\n                    .renderArray([\r\n");

WriteLiteral("                        ");

                   Write(Html.Raw(String.Join(",", lang.Searches.Select(s => String.Format("{{ word: '{0}', count: {1} }}", s.Key, s.Value)))));

WriteLiteral("\r\n                    ]);\r\n                ");

WriteLiteral("\r\n");

            }

WriteLiteral("\r\n");

            
             foreach (var lang in Model.Languages)
            {

WriteLiteral("                ");

WriteLiteral("\r\n                new Grid({\r\n                        \"class\": \"epi-grid-height--" +
"300 epi-grid--with-border\",\r\n                        columns: {\r\n               " +
"             word: \"");

                              Write(Html.Raw(Html.TranslateWithPath("searchword", localizationPath)));

WriteLiteral("\",\r\n                            count: \"");

                               Write(Html.Raw(Html.TranslateWithPath("count", localizationPath)));

WriteLiteral("\"\r\n                        }\r\n                    }, \"");

                    Write(lang.LanguageId);

WriteLiteral("-nohitsGrid\")\r\n                    .renderArray([\r\n");

WriteLiteral("                        ");

                   Write(Html.Raw(String.Join(",", lang.SearchesWithoutHits.Select(s => String.Format("{{ word: '{0}', count: {1} }}", s.Key, s.Value)))));

WriteLiteral("\r\n                    ]);\r\n                ");

WriteLiteral("\r\n");

            }

WriteLiteral("        });\r\n</script>");

        }
    }
}
#pragma warning restore 1591
