#pragma checksum "C:\Users\HP\source\repos\ENTITY FRAMEWORK CORE\RealEstates\RealEstates.Web\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "28db6bb8c288a6ace8a0536dd441e9632c6f8170"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "C:\Users\HP\source\repos\ENTITY FRAMEWORK CORE\RealEstates\RealEstates.Web\Views\_ViewImports.cshtml"
using RealEstates.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\HP\source\repos\ENTITY FRAMEWORK CORE\RealEstates\RealEstates.Web\Views\_ViewImports.cshtml"
using RealEstates.Web.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\HP\source\repos\ENTITY FRAMEWORK CORE\RealEstates\RealEstates.Web\Views\Home\Index.cshtml"
using RealEstates.Services.Models.Districts;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"28db6bb8c288a6ace8a0536dd441e9632c6f8170", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7099df06b65689c071b0cc00bdc726bdffc352d0", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<DistrictViewDto>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"{
    ViewData[""Title""] = ""Home Page"";
}

<div class=""text-center"">
    <h1>Welcome to Real Estates BG!</h1>
    <p>Learn about <a href=""https://docs.microsoft.com/aspnet/core"">building Web apps with ASP.NET Core</a>.</p>
</div>
<div>
    <table class=""table table-striped table-hover"">
        <tr>
            <th>District</th>
            <th>Avrg. Price</th>
            <th>Min Price</th>
            <th>Max Price</th>
            <th>Properties</th>
        </tr>
");
#nullable restore
#line 20 "C:\Users\HP\source\repos\ENTITY FRAMEWORK CORE\RealEstates\RealEstates.Web\Views\Home\Index.cshtml"
         foreach (DistrictViewDto district in this.Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <th>");
#nullable restore
#line 23 "C:\Users\HP\source\repos\ENTITY FRAMEWORK CORE\RealEstates\RealEstates.Web\Views\Home\Index.cshtml"
               Write(district.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                <th>");
#nullable restore
#line 24 "C:\Users\HP\source\repos\ENTITY FRAMEWORK CORE\RealEstates\RealEstates.Web\Views\Home\Index.cshtml"
               Write(district.AveragePrice);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                <th>");
#nullable restore
#line 25 "C:\Users\HP\source\repos\ENTITY FRAMEWORK CORE\RealEstates\RealEstates.Web\Views\Home\Index.cshtml"
               Write(district.MinPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                <th>");
#nullable restore
#line 26 "C:\Users\HP\source\repos\ENTITY FRAMEWORK CORE\RealEstates\RealEstates.Web\Views\Home\Index.cshtml"
               Write(district.MaxPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                <th>");
#nullable restore
#line 27 "C:\Users\HP\source\repos\ENTITY FRAMEWORK CORE\RealEstates\RealEstates.Web\Views\Home\Index.cshtml"
               Write(district.PropertiesCount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n            </tr>\r\n");
#nullable restore
#line 29 "C:\Users\HP\source\repos\ENTITY FRAMEWORK CORE\RealEstates\RealEstates.Web\Views\Home\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </table>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<DistrictViewDto>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
