#pragma checksum "/Users/rubenhannon/OneDrive/Projects/Ruben/bron_02/Kassablad/Kassablad.Identity/Views/Diagnostics/Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a5c01cf61c0f9a25c83c1845589b4d55e0ce9270"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Diagnostics_Index), @"mvc.1.0.view", @"/Views/Diagnostics/Index.cshtml")]
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
#nullable restore
#line 1 "/Users/rubenhannon/OneDrive/Projects/Ruben/bron_02/Kassablad/Kassablad.Identity/Views/_ViewImports.cshtml"
using Kassablad.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a5c01cf61c0f9a25c83c1845589b4d55e0ce9270", @"/Views/Diagnostics/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1ef20c0d13e565a196273849cd96530a0763ae67", @"/Views/_ViewImports.cshtml")]
    public class Views_Diagnostics_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DiagnosticsViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n<h1>Authentication cookie</h1>\n\n<h3>Claims</h3>\n<dl>\n");
#nullable restore
#line 7 "/Users/rubenhannon/OneDrive/Projects/Ruben/bron_02/Kassablad/Kassablad.Identity/Views/Diagnostics/Index.cshtml"
     foreach (var claim in Model.AuthenticateResult.Principal.Claims)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <dt>");
#nullable restore
#line 9 "/Users/rubenhannon/OneDrive/Projects/Ruben/bron_02/Kassablad/Kassablad.Identity/Views/Diagnostics/Index.cshtml"
       Write(claim.Type);

#line default
#line hidden
#nullable disable
            WriteLiteral("</dt>\n        <dd>");
#nullable restore
#line 10 "/Users/rubenhannon/OneDrive/Projects/Ruben/bron_02/Kassablad/Kassablad.Identity/Views/Diagnostics/Index.cshtml"
       Write(claim.Value);

#line default
#line hidden
#nullable disable
            WriteLiteral("</dd>\n");
#nullable restore
#line 11 "/Users/rubenhannon/OneDrive/Projects/Ruben/bron_02/Kassablad/Kassablad.Identity/Views/Diagnostics/Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</dl>\n\n<h3>Properties</h3>\n<dl>\n");
#nullable restore
#line 16 "/Users/rubenhannon/OneDrive/Projects/Ruben/bron_02/Kassablad/Kassablad.Identity/Views/Diagnostics/Index.cshtml"
     foreach (var prop in Model.AuthenticateResult.Properties.Items)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <dt>");
#nullable restore
#line 18 "/Users/rubenhannon/OneDrive/Projects/Ruben/bron_02/Kassablad/Kassablad.Identity/Views/Diagnostics/Index.cshtml"
       Write(prop.Key);

#line default
#line hidden
#nullable disable
            WriteLiteral("</dt>\n        <dd>");
#nullable restore
#line 19 "/Users/rubenhannon/OneDrive/Projects/Ruben/bron_02/Kassablad/Kassablad.Identity/Views/Diagnostics/Index.cshtml"
       Write(prop.Value);

#line default
#line hidden
#nullable disable
            WriteLiteral("</dd>\n");
#nullable restore
#line 20 "/Users/rubenhannon/OneDrive/Projects/Ruben/bron_02/Kassablad/Kassablad.Identity/Views/Diagnostics/Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</dl>\n\n");
#nullable restore
#line 23 "/Users/rubenhannon/OneDrive/Projects/Ruben/bron_02/Kassablad/Kassablad.Identity/Views/Diagnostics/Index.cshtml"
 if (Model.Clients.Any())
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <h3>Clients</h3>\n    <ul>\n");
#nullable restore
#line 27 "/Users/rubenhannon/OneDrive/Projects/Ruben/bron_02/Kassablad/Kassablad.Identity/Views/Diagnostics/Index.cshtml"
         foreach (var client in Model.Clients)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <li>");
#nullable restore
#line 29 "/Users/rubenhannon/OneDrive/Projects/Ruben/bron_02/Kassablad/Kassablad.Identity/Views/Diagnostics/Index.cshtml"
           Write(client);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\n");
#nullable restore
#line 30 "/Users/rubenhannon/OneDrive/Projects/Ruben/bron_02/Kassablad/Kassablad.Identity/Views/Diagnostics/Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </ul>\n");
#nullable restore
#line 32 "/Users/rubenhannon/OneDrive/Projects/Ruben/bron_02/Kassablad/Kassablad.Identity/Views/Diagnostics/Index.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DiagnosticsViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
