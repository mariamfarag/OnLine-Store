#pragma checksum "E:\projects\OnlineStore\GUISevenCodeOnlineStore\Views\Shared\_CityPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "39f898e770a94c2f25d3848dd81874b2fd866533"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__CityPartial), @"mvc.1.0.view", @"/Views/Shared/_CityPartial.cshtml")]
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
#line 1 "E:\projects\OnlineStore\GUISevenCodeOnlineStore\Views\_ViewImports.cshtml"
using GUISevenCodeOnlineStore;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\projects\OnlineStore\GUISevenCodeOnlineStore\Views\_ViewImports.cshtml"
using GUISevenCodeOnlineStore.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"39f898e770a94c2f25d3848dd81874b2fd866533", @"/Views/Shared/_CityPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8ac30e602652b67aa169dd64a23d49293b000a3a", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Shared__CityPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<SelectListItem>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "E:\projects\OnlineStore\GUISevenCodeOnlineStore\Views\Shared\_CityPartial.cshtml"
Write(Html.DropDownList("State",Model,null,new{@class="dropdown form-control"}));

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<SelectListItem>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
