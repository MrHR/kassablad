#pragma checksum "C:\Users\ruben\code\kassablad\kassablad.api\Views\KassaTemplate\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c242d8c233874354fb0bfa59918e08f39bc986d9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_KassaTemplate_Index), @"mvc.1.0.view", @"/Views/KassaTemplate/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c242d8c233874354fb0bfa59918e08f39bc986d9", @"/Views/KassaTemplate/Index.cshtml")]
    public class Views_KassaTemplate_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Kassablad.api.Models.KassaTemplate>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\ruben\code\kassablad\kassablad.api\Views\KassaTemplate\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Index</h1>\r\n\r\n<p>\r\n    <a asp-action=\"Create\">Create New</a>\r\n</p>\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 16 "C:\Users\ruben\code\kassablad\kassablad.api\Views\KassaTemplate\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Active));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 19 "C:\Users\ruben\code\kassablad\kassablad.api\Views\KassaTemplate\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.DateAdded));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 22 "C:\Users\ruben\code\kassablad\kassablad.api\Views\KassaTemplate\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.DateUpdated));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 25 "C:\Users\ruben\code\kassablad\kassablad.api\Views\KassaTemplate\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.UpdatedBy));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 28 "C:\Users\ruben\code\kassablad\kassablad.api\Views\KassaTemplate\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.CreatedBy));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 31 "C:\Users\ruben\code\kassablad\kassablad.api\Views\KassaTemplate\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Nominations));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 37 "C:\Users\ruben\code\kassablad\kassablad.api\Views\KassaTemplate\Index.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 40 "C:\Users\ruben\code\kassablad\kassablad.api\Views\KassaTemplate\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Active));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 43 "C:\Users\ruben\code\kassablad\kassablad.api\Views\KassaTemplate\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.DateAdded));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 46 "C:\Users\ruben\code\kassablad\kassablad.api\Views\KassaTemplate\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.DateUpdated));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 49 "C:\Users\ruben\code\kassablad\kassablad.api\Views\KassaTemplate\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.UpdatedBy));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 52 "C:\Users\ruben\code\kassablad\kassablad.api\Views\KassaTemplate\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.CreatedBy));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 55 "C:\Users\ruben\code\kassablad\kassablad.api\Views\KassaTemplate\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Nominations));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                <a asp-action=\"Edit\"");
            BeginWriteAttribute("asp-route-id", " asp-route-id=\"", 1596, "\"", 1619, 1);
#nullable restore
#line 58 "C:\Users\ruben\code\kassablad\kassablad.api\Views\KassaTemplate\Index.cshtml"
WriteAttributeValue("", 1611, item.Id, 1611, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Edit</a> |\r\n                <a asp-action=\"Details\"");
            BeginWriteAttribute("asp-route-id", " asp-route-id=\"", 1672, "\"", 1695, 1);
#nullable restore
#line 59 "C:\Users\ruben\code\kassablad\kassablad.api\Views\KassaTemplate\Index.cshtml"
WriteAttributeValue("", 1687, item.Id, 1687, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Details</a> |\r\n                <a asp-action=\"Delete\"");
            BeginWriteAttribute("asp-route-id", " asp-route-id=\"", 1750, "\"", 1773, 1);
#nullable restore
#line 60 "C:\Users\ruben\code\kassablad\kassablad.api\Views\KassaTemplate\Index.cshtml"
WriteAttributeValue("", 1765, item.Id, 1765, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Delete</a>\r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 63 "C:\Users\ruben\code\kassablad\kassablad.api\Views\KassaTemplate\Index.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Kassablad.api.Models.KassaTemplate>> Html { get; private set; }
    }
}
#pragma warning restore 1591