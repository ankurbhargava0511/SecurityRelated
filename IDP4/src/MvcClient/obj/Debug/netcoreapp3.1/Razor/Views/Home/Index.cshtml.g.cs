#pragma checksum "D:\Development\SecurityRelated\IDP4\src\MvcClient\Views\Home\Index.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "c4a5e6985cd0187de499ab9d5e861c724bc76832082ad977dc1850c4e4a62a03"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using global::System;
    using global::System.Collections.Generic;
    using global::System.Linq;
    using global::System.Threading.Tasks;
    using global::Microsoft.AspNetCore.Mvc;
    using global::Microsoft.AspNetCore.Mvc.Rendering;
    using global::Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\Development\SecurityRelated\IDP4\src\MvcClient\Views\_ViewImports.cshtml"
using MvcClient;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Development\SecurityRelated\IDP4\src\MvcClient\Views\_ViewImports.cshtml"
using MvcClient.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "D:\Development\SecurityRelated\IDP4\src\MvcClient\Views\Home\Index.cshtml"
using Microsoft.AspNetCore.Authentication;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"c4a5e6985cd0187de499ab9d5e861c724bc76832082ad977dc1850c4e4a62a03", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"b37cbe757f85f168c8055b539452d72b0651622ff8aa83e7ec83aefd7662503f", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<h2>Claims</h2>\r\n\r\n<dl>\r\n");
#nullable restore
#line 6 "D:\Development\SecurityRelated\IDP4\src\MvcClient\Views\Home\Index.cshtml"
     foreach (var claim in User.Claims)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <dt>");
#nullable restore
#line 8 "D:\Development\SecurityRelated\IDP4\src\MvcClient\Views\Home\Index.cshtml"
       Write(claim.Type);

#line default
#line hidden
#nullable disable
            WriteLiteral("</dt>\r\n        <dd>");
#nullable restore
#line 9 "D:\Development\SecurityRelated\IDP4\src\MvcClient\Views\Home\Index.cshtml"
       Write(claim.Value);

#line default
#line hidden
#nullable disable
            WriteLiteral("</dd>\r\n");
#nullable restore
#line 10 "D:\Development\SecurityRelated\IDP4\src\MvcClient\Views\Home\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</dl>\r\n\r\n<h2>Properties</h2>\r\n\r\n<dl>\r\n");
#nullable restore
#line 16 "D:\Development\SecurityRelated\IDP4\src\MvcClient\Views\Home\Index.cshtml"
     foreach (var prop in (await Context.AuthenticateAsync()).Properties.Items)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <dt>");
#nullable restore
#line 18 "D:\Development\SecurityRelated\IDP4\src\MvcClient\Views\Home\Index.cshtml"
       Write(prop.Key);

#line default
#line hidden
#nullable disable
            WriteLiteral("</dt>\r\n        <dd>");
#nullable restore
#line 19 "D:\Development\SecurityRelated\IDP4\src\MvcClient\Views\Home\Index.cshtml"
       Write(prop.Value);

#line default
#line hidden
#nullable disable
            WriteLiteral("</dd>\r\n");
#nullable restore
#line 20 "D:\Development\SecurityRelated\IDP4\src\MvcClient\Views\Home\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</dl>");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
