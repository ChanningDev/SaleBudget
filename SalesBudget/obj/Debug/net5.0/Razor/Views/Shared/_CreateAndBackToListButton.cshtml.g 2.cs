#pragma checksum "/Users/channingm/Documents/GitHub/SalesBudget/SalesBudget/Views/Shared/_CreateAndBackToListButton.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ed0ab4abaf57d788c0ef04b611ed67b462c723b9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__CreateAndBackToListButton), @"mvc.1.0.view", @"/Views/Shared/_CreateAndBackToListButton.cshtml")]
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
#line 1 "/Users/channingm/Documents/GitHub/SalesBudget/SalesBudget/Views/_ViewImports.cshtml"
using SalesBudget;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/channingm/Documents/GitHub/SalesBudget/SalesBudget/Views/_ViewImports.cshtml"
using SalesBudget.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ed0ab4abaf57d788c0ef04b611ed67b462c723b9", @"/Views/Shared/_CreateAndBackToListButton.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"73f257aa5d9daac7fe450f1aa91ccc8aad82dcec", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Shared__CreateAndBackToListButton : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<div class=\"row\">\n    <div class=\"col\">\n        <button type=\"submit\" class=\"btn btn-primary form-control\"><i class=\"fas fa-save\"></i> Create new</button>\n    </div>\n");
            WriteLiteral("    <div class=\"col\">\n        <a class=\"btn btn-danger\" onClick=\"window.close()\"><i class=\"fas fa-times\"></i> Close without saving</a>\n    </div>\n</div>");
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