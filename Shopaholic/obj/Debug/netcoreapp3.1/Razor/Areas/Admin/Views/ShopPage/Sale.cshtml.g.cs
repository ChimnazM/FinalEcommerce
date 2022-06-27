#pragma checksum "C:\Users\HP\Downloads\ShopaholicApp-main\Shopwise\Areas\Admin\Views\ShopPage\Sale.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "827aef683f422974ac5a03799529510e8a49468a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_ShopPage_Sale), @"mvc.1.0.view", @"/Areas/Admin/Views/ShopPage/Sale.cshtml")]
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
#line 1 "C:\Users\HP\Downloads\ShopaholicApp-main\Shopwise\Areas\Admin\Views\_ViewImports.cshtml"
using Shopwise;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\HP\Downloads\ShopaholicApp-main\Shopwise\Areas\Admin\Views\_ViewImports.cshtml"
using Shopwise.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\HP\Downloads\ShopaholicApp-main\Shopwise\Areas\Admin\Views\_ViewImports.cshtml"
using Shopwise.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\HP\Downloads\ShopaholicApp-main\Shopwise\Areas\Admin\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"827aef683f422974ac5a03799529510e8a49468a", @"/Areas/Admin/Views/ShopPage/Sale.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0fb26234dc20d1d42e59806e89280e2c478d83a1", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Areas_Admin_Views_ShopPage_Sale : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<VmSale>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "admin", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "shoppage", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "saleitem", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-success btn-fw mt-2"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\HP\Downloads\ShopaholicApp-main\Shopwise\Areas\Admin\Views\ShopPage\Sale.cshtml"
  
    ViewData["Title"] = "Sale";
    Layout = "~/Areas/Admin/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""container"">
    <div class=""row"">
        <div class=""col-lg-12 grid-margin stretch-card"">
            <div class=""card"">
                <div class=""card-body"">
                    <h4 class=""card-title ml-2"">Sales</h4>
                    <div class=""table-responsive"">
                        <table class=""table table-striped"">
                            <thead>
                                <tr>
                                    <th>
                                        #
                                    </th>
                                    <th>
                                        InvoiceNo
                                    </th>
                                    <th>
                                        Client Name
                                    </th>
                                    <th>
                                        Shipping Country
                                    </th>
                                    <th>
                                ");
            WriteLiteral(@"        Tax
                                    </th>
                                    <th>
                                        Shipping
                                    </th>
                                    <th>
                                        TotalPrice
                                    </th>
                                    <th>
                                    </th>
                                </tr>
                            </thead>
                            <tbody>
");
#nullable restore
#line 43 "C:\Users\HP\Downloads\ShopaholicApp-main\Shopwise\Areas\Admin\Views\ShopPage\Sale.cshtml"
                                   int i = 1;

#line default
#line hidden
#nullable disable
#nullable restore
#line 44 "C:\Users\HP\Downloads\ShopaholicApp-main\Shopwise\Areas\Admin\Views\ShopPage\Sale.cshtml"
                                 foreach (var item in Model)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <tr>\n                                    <td>");
#nullable restore
#line 47 "C:\Users\HP\Downloads\ShopaholicApp-main\Shopwise\Areas\Admin\Views\ShopPage\Sale.cshtml"
                                   Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                                    <td>\n                                        ");
#nullable restore
#line 49 "C:\Users\HP\Downloads\ShopaholicApp-main\Shopwise\Areas\Admin\Views\ShopPage\Sale.cshtml"
                                   Write(item.InvoiceNo);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                                    </td>\n                                    <td>\n                                        ");
#nullable restore
#line 52 "C:\Users\HP\Downloads\ShopaholicApp-main\Shopwise\Areas\Admin\Views\ShopPage\Sale.cshtml"
                                   Write(item.CustomUserFullName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                                    </td>\n                                    <td>\n                                        ");
#nullable restore
#line 55 "C:\Users\HP\Downloads\ShopaholicApp-main\Shopwise\Areas\Admin\Views\ShopPage\Sale.cshtml"
                                   Write(item.ShippingCountry);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                                    </td>\n                                    <td>\n                                        $");
#nullable restore
#line 58 "C:\Users\HP\Downloads\ShopaholicApp-main\Shopwise\Areas\Admin\Views\ShopPage\Sale.cshtml"
                                    Write(item.Tax.ToString("0.00"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                                    </td>\n                                    <td>\n                                        $");
#nullable restore
#line 61 "C:\Users\HP\Downloads\ShopaholicApp-main\Shopwise\Areas\Admin\Views\ShopPage\Sale.cshtml"
                                    Write(item.ShippingPrice.ToString("0.00"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                                    </td>\n                                    <td>\n                                        $");
#nullable restore
#line 64 "C:\Users\HP\Downloads\ShopaholicApp-main\Shopwise\Areas\Admin\Views\ShopPage\Sale.cshtml"
                                    Write(item.TotalPrice.ToString("0.00"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                                    </td>\n\n                                    <td class=\"text-center\">\n                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "827aef683f422974ac5a03799529510e8a49468a10073", async() => {
                WriteLiteral("Sale Items");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-saleId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 68 "C:\Users\HP\Downloads\ShopaholicApp-main\Shopwise\Areas\Admin\Views\ShopPage\Sale.cshtml"
                                                                                                                  WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["saleId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-saleId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["saleId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n                                    </td>\n                                </tr>\n");
#nullable restore
#line 71 "C:\Users\HP\Downloads\ShopaholicApp-main\Shopwise\Areas\Admin\Views\ShopPage\Sale.cshtml"
                                    { i++; }
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </tbody>\n                        </table>\n                    </div>\n                </div>\n            </div>\n        </div>\n    </div>\n</div>\n\n\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<VmSale>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
