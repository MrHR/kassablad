#pragma checksum "C:\Users\ruben\code\kassablad\kassablad.api\Views\KassaNominations\Create.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7c2aa4b84ab472b25d471503463c1c2ccda0812b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_KassaNominations_Create), @"mvc.1.0.view", @"/Views/KassaNominations/Create.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7c2aa4b84ab472b25d471503463c1c2ccda0812b", @"/Views/KassaNominations/Create.cshtml")]
    public class Views_KassaNominations_Create : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Kassablad.api.Models.KassaNomination>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\ruben\code\kassablad\kassablad.api\Views\KassaNominations\Create.cshtml"
  
    ViewData["Title"] = "Create";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h1>Create</h1>

<h4>KassaNomination</h4>
<hr />
<div class=""row"">
    <div class=""col-md-4"">
        <form asp-action=""Create"">
            <div asp-validation-summary=""ModelOnly"" class=""text-danger""></div>
            <div class=""form-group form-check"">
                <label class=""form-check-label"">
                    <input class=""form-check-input"" asp-for=""Active"" /> ");
#nullable restore
#line 17 "C:\Users\ruben\code\kassablad\kassablad.api\Views\KassaNominations\Create.cshtml"
                                                                   Write(Html.DisplayNameFor(model => model.Active));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                </label>
            </div>
            <div class=""form-group"">
                <label asp-for=""DateAdded"" class=""control-label""></label>
                <input asp-for=""DateAdded"" class=""form-control"" />
                <span asp-validation-for=""DateAdded"" class=""text-danger""></span>
            </div>
            <div class=""form-group"">
                <label asp-for=""DateUpdated"" class=""control-label""></label>
                <input asp-for=""DateUpdated"" class=""form-control"" />
                <span asp-validation-for=""DateUpdated"" class=""text-danger""></span>
            </div>
            <div class=""form-group"">
                <label asp-for=""UpdatedBy"" class=""control-label""></label>
                <input asp-for=""UpdatedBy"" class=""form-control"" />
                <span asp-validation-for=""UpdatedBy"" class=""text-danger""></span>
            </div>
            <div class=""form-group"">
                <label asp-for=""CreatedBy"" class=""control-label""></label>
        ");
            WriteLiteral(@"        <input asp-for=""CreatedBy"" class=""form-control"" />
                <span asp-validation-for=""CreatedBy"" class=""text-danger""></span>
            </div>
            <div class=""form-group"">
                <label asp-for=""KassaId"" class=""control-label""></label>
                <input asp-for=""KassaId"" class=""form-control"" />
                <span asp-validation-for=""KassaId"" class=""text-danger""></span>
            </div>
            <div class=""form-group"">
                <label asp-for=""NominationId"" class=""control-label""></label>
                <input asp-for=""NominationId"" class=""form-control"" />
                <span asp-validation-for=""NominationId"" class=""text-danger""></span>
            </div>
            <div class=""form-group"">
                <label asp-for=""Amount"" class=""control-label""></label>
                <input asp-for=""Amount"" class=""form-control"" />
                <span asp-validation-for=""Amount"" class=""text-danger""></span>
            </div>
            <div cl");
            WriteLiteral("ass=\"form-group\">\r\n                <input type=\"submit\" value=\"Create\" class=\"btn btn-primary\" />\r\n            </div>\r\n        </form>\r\n    </div>\r\n</div>\r\n\r\n<div>\r\n    <a asp-action=\"Index\">Back to List</a>\r\n</div>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n");
#nullable restore
#line 67 "C:\Users\ruben\code\kassablad\kassablad.api\Views\KassaNominations\Create.cshtml"
      await Html.RenderPartialAsync("_ValidationScriptsPartial");

#line default
#line hidden
#nullable disable
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Kassablad.api.Models.KassaNomination> Html { get; private set; }
    }
}
#pragma warning restore 1591
