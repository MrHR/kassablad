#pragma checksum "C:\Users\ruben\Code\kassablad\Kassablad.api\Views\KassaTemplate\Edit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e93cd4045d9050dc83366ca6744fb97abc6c7694"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_KassaTemplate_Edit), @"mvc.1.0.view", @"/Views/KassaTemplate/Edit.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e93cd4045d9050dc83366ca6744fb97abc6c7694", @"/Views/KassaTemplate/Edit.cshtml")]
    public class Views_KassaTemplate_Edit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Kassablad.api.Models.KassaTemplate>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\ruben\Code\kassablad\Kassablad.api\Views\KassaTemplate\Edit.cshtml"
  
    ViewData["Title"] = "Edit";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h1>Edit</h1>

<h4>KassaTemplate</h4>
<hr />
<div class=""row"">
    <div class=""col-md-4"">
        <form asp-action=""Edit"">
            <div asp-validation-summary=""ModelOnly"" class=""text-danger""></div>
            <input type=""hidden"" asp-for=""Id"" />
            <div class=""form-group form-check"">
                <label class=""form-check-label"">
                    <input class=""form-check-input"" asp-for=""Active"" /> ");
#nullable restore
#line 18 "C:\Users\ruben\Code\kassablad\Kassablad.api\Views\KassaTemplate\Edit.cshtml"
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
                <label asp-for=""Nominations"" class=""control-label""></label>
                <input asp-for=""Nominations"" class=""form-control"" />
                <span asp-validation-for=""Nominations"" class=""text-danger""></span>
            </div>
            <div class=""form-group"">
                <input type=""submit"" value=""Save"" class=""btn btn-primary"" />
            </div>
        </form>
    </div>
</div>

<div>
    <a asp-action=""Index"">Back to List</a>
</div>

");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n");
#nullable restore
#line 58 "C:\Users\ruben\Code\kassablad\Kassablad.api\Views\KassaTemplate\Edit.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Kassablad.api.Models.KassaTemplate> Html { get; private set; }
    }
}
#pragma warning restore 1591
