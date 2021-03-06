#pragma checksum "C:\Users\NeslihanAlcglu\source\repos\ShopApp\ShopApp.WebUI\Views\Admin\CategoryList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f95450a9b9c1a935c741885edd6d85091a6f4857"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_CategoryList), @"mvc.1.0.view", @"/Views/Admin/CategoryList.cshtml")]
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
#line 1 "C:\Users\NeslihanAlcglu\source\repos\ShopApp\ShopApp.WebUI\Views\_ViewImports.cshtml"
using ShopApp.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\NeslihanAlcglu\source\repos\ShopApp\ShopApp.WebUI\Views\_ViewImports.cshtml"
using ShopApp.WebUI.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f95450a9b9c1a935c741885edd6d85091a6f4857", @"/Views/Admin/CategoryList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6ca7dd7215f156ae1ed0d79360326521626c385c", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_CategoryList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CategoryListModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("/admin/deletecategory"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("display:inline;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\NeslihanAlcglu\source\repos\ShopApp\ShopApp.WebUI\Views\Admin\CategoryList.cshtml"
   ViewData["Title"] = "CategoryList"; 

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<h1>Admin Categories</h1>\n<hr />\n\n");
#nullable restore
#line 7 "C:\Users\NeslihanAlcglu\source\repos\ShopApp\ShopApp.WebUI\Views\Admin\CategoryList.cshtml"
 if (Model.Categories.Count() > 0)
{


#line default
#line hidden
#nullable disable
            WriteLiteral("<table class=\"table table-bordered\">\n    <thead>\n        <tr>\n            <td style=\"width:30px;\">Id</td>\n            <td style=\"width:100px;\">Name</td>\n            <td style=\"width:150px;\"></td>\n        </tr>\n    </thead>\n    <tbody>\n");
#nullable restore
#line 19 "C:\Users\NeslihanAlcglu\source\repos\ShopApp\ShopApp.WebUI\Views\Admin\CategoryList.cshtml"
         foreach (var item in Model.Categories)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("<tr>\n    <td>");
#nullable restore
#line 22 "C:\Users\NeslihanAlcglu\source\repos\ShopApp\ShopApp.WebUI\Views\Admin\CategoryList.cshtml"
   Write(item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n    <td>");
#nullable restore
#line 23 "C:\Users\NeslihanAlcglu\source\repos\ShopApp\ShopApp.WebUI\Views\Admin\CategoryList.cshtml"
   Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n    <td>\n        <a class=\"btn btn-primary btn-sm mr-2\"");
            BeginWriteAttribute("href", " href=\"", 538, "\"", 573, 2);
            WriteAttributeValue("", 545, "/admin/editcategory/", 545, 20, true);
#nullable restore
#line 25 "C:\Users\NeslihanAlcglu\source\repos\ShopApp\ShopApp.WebUI\Views\Admin\CategoryList.cshtml"
WriteAttributeValue("", 565, item.Id, 565, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Edit</a>\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f95450a9b9c1a935c741885edd6d85091a6f48576305", async() => {
                WriteLiteral("\n            <input type=\"hidden\" name=\"categoryId\"");
                BeginWriteAttribute("value", " value=\"", 718, "\"", 734, 1);
#nullable restore
#line 27 "C:\Users\NeslihanAlcglu\source\repos\ShopApp\ShopApp.WebUI\Views\Admin\CategoryList.cshtml"
WriteAttributeValue("", 726, item.Id, 726, 8, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\n            <button type=\"submit\" class=\"btn btn-danger btn-sm\">Delete</button>\n        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n    </td>\n</tr>");
#nullable restore
#line 31 "C:\Users\NeslihanAlcglu\source\repos\ShopApp\ShopApp.WebUI\Views\Admin\CategoryList.cshtml"
     }

#line default
#line hidden
#nullable disable
            WriteLiteral("\n    </tbody>\n\n</table> ");
#nullable restore
#line 35 "C:\Users\NeslihanAlcglu\source\repos\ShopApp\ShopApp.WebUI\Views\Admin\CategoryList.cshtml"
         }
            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"alert alert-warning\">\n    <h4>No Products</h4>\n</div>");
#nullable restore
#line 40 "C:\Users\NeslihanAlcglu\source\repos\ShopApp\ShopApp.WebUI\Views\Admin\CategoryList.cshtml"
      }

#line default
#line hidden
#nullable disable
            WriteLiteral("\n\n\n\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CategoryListModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
