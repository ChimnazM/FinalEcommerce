#pragma checksum "C:\Users\HP\Downloads\ShopaholicApp-main\Shopwise\Views\Faq\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4063451fc3a90997c810339c75bc23ce50aa153a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Faq_Index), @"mvc.1.0.view", @"/Views/Faq/Index.cshtml")]
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
#line 1 "C:\Users\HP\Downloads\ShopaholicApp-main\Shopwise\Views\_ViewImports.cshtml"
using Shopwise;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\HP\Downloads\ShopaholicApp-main\Shopwise\Views\_ViewImports.cshtml"
using Shopwise.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\HP\Downloads\ShopaholicApp-main\Shopwise\Views\_ViewImports.cshtml"
using Shopwise.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\HP\Downloads\ShopaholicApp-main\Shopwise\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4063451fc3a90997c810339c75bc23ce50aa153a", @"/Views/Faq/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0fb26234dc20d1d42e59806e89280e2c478d83a1", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Faq_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<VmFaq>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "C:\Users\HP\Downloads\ShopaholicApp-main\Shopwise\Views\Faq\Index.cshtml"
  
    ViewData["Title"] = "Faq";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<!--Bread Crumb-->
<section class=""bread-crumb"">
    <div class=""container-fluid"">
        <div class=""container"">
            <div class=""row g-0 align-items-center"">
                <div class=""col-md-6"">
                    <div class=""page-title"">
                        <h1>Frequently Asked Question</h1>
                    </div>
                </div>
                <div class=""col-md-6 g-0"">
                    <ol class=""breadcrumb justify-content-md-end"">
                        <li class=""breadcrumb-item"">
                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4063451fc3a90997c810339c75bc23ce50aa153a4820", async() => {
                WriteLiteral("Home");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                        </li>
                        <li class=""breadcrumb-item active"">Faq</li>
                    </ol>
                </div>
            </div>
        </div>
    </div>
</section>

<!--Faqs-->
<section class=""faqs"">
    <div class=""container"">
        <div class=""row g-0"">

            <div class=""col-12 col-md-6 faq-first"">
                <div class=""faq-header"">
                    <h1>");
#nullable restore
#line 36 "C:\Users\HP\Downloads\ShopaholicApp-main\Shopwise\Views\Faq\Index.cshtml"
                    Write(Model.Universals.Where(s=>s.Section == "General").FirstOrDefault().Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\n                </div>\n                <div class=\"accordion accordion-flush\" id=\"accordionFlushExample\">\n");
#nullable restore
#line 39 "C:\Users\HP\Downloads\ShopaholicApp-main\Shopwise\Views\Faq\Index.cshtml"
                       int i = 1; 

#line default
#line hidden
#nullable disable
            WriteLiteral("\n");
#nullable restore
#line 41 "C:\Users\HP\Downloads\ShopaholicApp-main\Shopwise\Views\Faq\Index.cshtml"
                     foreach (var item in Model.Faqs.Where(g => g.IsGeneral == true))
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div class=\"accordion-item\">\n                            <h2 class=\"accordion-header\" id=\"flush-headingOne\">\n                                <button");
            BeginWriteAttribute("class", " class=\"", 1574, "\"", 1627, 2);
            WriteAttributeValue("", 1582, "accordion-button", 1582, 16, true);
#nullable restore
#line 45 "C:\Users\HP\Downloads\ShopaholicApp-main\Shopwise\Views\Faq\Index.cshtml"
WriteAttributeValue(" ", 1598, i != 1 ? "collapsed" : "", 1599, 28, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" type=\"button\" data-bs-toggle=\"collapse\" data-bs-target=\"#flush-collapse");
#nullable restore
#line 45 "C:\Users\HP\Downloads\ShopaholicApp-main\Shopwise\Views\Faq\Index.cshtml"
                                                                                                                                                                 Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" aria-expanded=\"false\" aria-controls=\"flush-collapseOne\">\n                                    ");
#nullable restore
#line 46 "C:\Users\HP\Downloads\ShopaholicApp-main\Shopwise\Views\Faq\Index.cshtml"
                               Write(item.Question);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                                </button>\n                            </h2>\n                            <div");
            BeginWriteAttribute("id", " id=\"", 1922, "\"", 1945, 2);
            WriteAttributeValue("", 1927, "flush-collapse", 1927, 14, true);
#nullable restore
#line 49 "C:\Users\HP\Downloads\ShopaholicApp-main\Shopwise\Views\Faq\Index.cshtml"
WriteAttributeValue("", 1941, i, 1941, 4, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("class", " class=\"", 1946, "\"", 2005, 3);
            WriteAttributeValue("", 1954, "accordion-collapse", 1954, 18, true);
            WriteAttributeValue(" ", 1972, "collapse", 1973, 9, true);
#nullable restore
#line 49 "C:\Users\HP\Downloads\ShopaholicApp-main\Shopwise\Views\Faq\Index.cshtml"
WriteAttributeValue(" ", 1981, i == 1 ? "show" : "", 1982, 23, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" aria-labelledby=\"flush-headingOne\" data-bs-parent=\"#accordionFlushExample\">\n                                <div class=\"accordion-body\">");
#nullable restore
#line 50 "C:\Users\HP\Downloads\ShopaholicApp-main\Shopwise\Views\Faq\Index.cshtml"
                                                       Write(Html.Raw(item.Answer));

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\n                            </div>\n                        </div>\n");
#nullable restore
#line 53 "C:\Users\HP\Downloads\ShopaholicApp-main\Shopwise\Views\Faq\Index.cshtml"

                        i++;
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                </div>\n            </div>\n\n            <div class=\"col-12 col-md-6 faq-second\">\n                <div class=\"faq-header\">\n                    <h1>");
#nullable restore
#line 62 "C:\Users\HP\Downloads\ShopaholicApp-main\Shopwise\Views\Faq\Index.cshtml"
                    Write(Model.Universals.Where(s => s.Section == "Other").FirstOrDefault().Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\n                </div>\n                <div class=\"accordion accordion-flush\" id=\"accordionFlushExample\">\n");
#nullable restore
#line 65 "C:\Users\HP\Downloads\ShopaholicApp-main\Shopwise\Views\Faq\Index.cshtml"
                      
                        int j = i + 1;
                        int n = j;
                    

#line default
#line hidden
#nullable disable
            WriteLiteral("\n");
#nullable restore
#line 70 "C:\Users\HP\Downloads\ShopaholicApp-main\Shopwise\Views\Faq\Index.cshtml"
                     foreach (var item in Model.Faqs.Where(g => g.IsGeneral == false))
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div class=\"accordion-item\">\n                            <h2 class=\"accordion-header\" id=\"flush-headingTwo\">\n                                <button");
            BeginWriteAttribute("class", " class=\"", 3040, "\"", 3087, 2);
            WriteAttributeValue("", 3048, "accordion-button", 3048, 16, true);
#nullable restore
#line 74 "C:\Users\HP\Downloads\ShopaholicApp-main\Shopwise\Views\Faq\Index.cshtml"
WriteAttributeValue(" ", 3064, j!=n?"collapsed":"", 3065, 22, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" type=\"button\" data-bs-toggle=\"collapse\" data-bs-target=\"#flush-collapse");
#nullable restore
#line 74 "C:\Users\HP\Downloads\ShopaholicApp-main\Shopwise\Views\Faq\Index.cshtml"
                                                                                                                                                           Write(j);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" aria-expanded=\"false\" aria-controls=\"flush-collapseTwo\">\n                                    ");
#nullable restore
#line 75 "C:\Users\HP\Downloads\ShopaholicApp-main\Shopwise\Views\Faq\Index.cshtml"
                               Write(item.Question);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                                </button>\n                            </h2>\n                            <div");
            BeginWriteAttribute("id", " id=\"", 3382, "\"", 3405, 2);
            WriteAttributeValue("", 3387, "flush-collapse", 3387, 14, true);
#nullable restore
#line 78 "C:\Users\HP\Downloads\ShopaholicApp-main\Shopwise\Views\Faq\Index.cshtml"
WriteAttributeValue("", 3401, j, 3401, 4, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("class", " class=\"", 3406, "\"", 3459, 3);
            WriteAttributeValue("", 3414, "accordion-collapse", 3414, 18, true);
            WriteAttributeValue(" ", 3432, "collapse", 3433, 9, true);
#nullable restore
#line 78 "C:\Users\HP\Downloads\ShopaholicApp-main\Shopwise\Views\Faq\Index.cshtml"
WriteAttributeValue(" ", 3441, j==n?"show":"", 3442, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" aria-labelledby=\"flush-headingTwo\" data-bs-parent=\"#accordionFlushExample\">\n                                <div class=\"accordion-body\">");
#nullable restore
#line 79 "C:\Users\HP\Downloads\ShopaholicApp-main\Shopwise\Views\Faq\Index.cshtml"
                                                       Write(Html.Raw(item.Answer));

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\n                            </div>\n                        </div>\n");
#nullable restore
#line 82 "C:\Users\HP\Downloads\ShopaholicApp-main\Shopwise\Views\Faq\Index.cshtml"

                        j++;
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                </div>\n            </div>\n\n        </div>\n    </div>\n</section>\n\n\n\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<VmFaq> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
