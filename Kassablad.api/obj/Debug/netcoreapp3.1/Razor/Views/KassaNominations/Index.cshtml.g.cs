#pragma checksum "C:\Users\ruben\Code\kassablad\Kassablad.api\Views\KassaNominations\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e7d8cc429961be44de7d0865b2287f2b76cac00b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_KassaNominations_Index), @"mvc.1.0.view", @"/Views/KassaNominations/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e7d8cc429961be44de7d0865b2287f2b76cac00b", @"/Views/KassaNominations/Index.cshtml")]
    public class Views_KassaNominations_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Kassablad.api.Models.KassaNomination>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\ruben\Code\kassablad\Kassablad.api\Views\KassaNominations\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Index</h1>\r\n\r\n<p>\r\n    <a asp-action=\"Create\">Create New</a>\r\n</p>\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 16 "C:\Users\ruben\Code\kassablad\Kassablad.api\Views\KassaNominations\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Active));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 19 "C:\Users\ruben\Code\kassablad\Kassablad.api\Views\KassaNominations\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.DateAdded));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 22 "C:\Users\ruben\Code\kassablad\Kassablad.api\Views\KassaNominations\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.DateUpdated));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 25 "C:\Users\ruben\Code\kassablad\Kassablad.api\Views\KassaNominations\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.UpdatedBy));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 28 "C:\Users\ruben\Code\kassablad\Kassablad.api\Views\KassaNominations\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.CreatedBy));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 31 "C:\Users\ruben\Code\kassablad\Kassablad.api\Views\KassaNominations\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.KassaId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 34 "C:\Users\ruben\Code\kassablad\Kassablad.api\Views\KassaNominations\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.NominationId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 37 "C:\Users\ruben\Code\kassablad\Kassablad.api\Views\KassaNominations\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Amount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 43 "C:\Users\ruben\Code\kassablad\Kassablad.api\Views\KassaNominations\Index.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 46 "C:\Users\ruben\Code\kassablad\Kassablad.api\Views\KassaNominations\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Active));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 49 "C:\Users\ruben\Code\kassablad\Kassablad.api\Views\KassaNominations\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.DateAdded));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 52 "C:\Users\ruben\Code\kassablad\Kassablad.api\Views\KassaNominations\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.DateUpdated));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 55 "C:\Users\ruben\Code\kassablad\Kassablad.api\Views\KassaNominations\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.UpdatedBy));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 58 "C:\Users\ruben\Code\kassablad\Kassablad.api\Views\KassaNominations\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.CreatedBy));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 61 "C:\Users\ruben\Code\kassablad\Kassablad.api\Views\KassaNominations\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.KassaId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 64 "C:\Users\ruben\Code\kassablad\Kassablad.api\Views\KassaNominations\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.NominationId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 67 "C:\Users\ruben\Code\kassablad\Kassablad.api\Views\KassaNominations\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Amount));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                <a asp-action=\"Edit\"");
            BeginWriteAttribute("asp-route-id", " asp-route-id=\"", 1992, "\"", 2015, 1);
#nullable restore
#line 70 "C:\Users\ruben\Code\kassablad\Kassablad.api\Views\KassaNominations\Index.cshtml"
WriteAttributeValue("", 2007, item.Id, 2007, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Edit</a> |\r\n                <a asp-action=\"Details\"");
            BeginWriteAttribute("asp-route-id", " asp-route-id=\"", 2068, "\"", 2091, 1);
#nullable restore
#line 71 "C:\Users\ruben\Code\kassablad\Kassablad.api\Views\KassaNominations\Index.cshtml"
WriteAttributeValue("", 2083, item.Id, 2083, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Details</a> |\r\n                <a asp-action=\"Delete\"");
            BeginWriteAttribute("asp-route-id", " asp-route-id=\"", 2146, "\"", 2169, 1);
#nullable restore
#line 72 "C:\Users\ruben\Code\kassablad\Kassablad.api\Views\KassaNominations\Index.cshtml"
WriteAttributeValue("", 2161, item.Id, 2161, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Delete</a>\r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 75 "C:\Users\ruben\Code\kassablad\Kassablad.api\Views\KassaNominations\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Kassablad.api.Models.KassaNomination>> Html { get; private set; }
    }
}
#pragma warning restore 1591
