#pragma checksum "C:\CodeRepos\AnFuCareHomeApp\AFCHIntranet\AFCHIntranet\Pages\Elder\IndexDelete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5f742dc40be24815cd6dd458e72bf0000a9d39fb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AFCHIntranet.Pages.Elder.Pages_Elder_IndexDelete), @"mvc.1.0.razor-page", @"/Pages/Elder/IndexDelete.cshtml")]
namespace AFCHIntranet.Pages.Elder
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
#line 1 "C:\CodeRepos\AnFuCareHomeApp\AFCHIntranet\AFCHIntranet\Pages\_ViewImports.cshtml"
using AFCHIntranet;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\CodeRepos\AnFuCareHomeApp\AFCHIntranet\AFCHIntranet\Pages\_ViewImports.cshtml"
using AFCHIntranet.Models.Elder;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\CodeRepos\AnFuCareHomeApp\AFCHIntranet\AFCHIntranet\Pages\_ViewImports.cshtml"
using AFCHIntranet.Models.Account;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\CodeRepos\AnFuCareHomeApp\AFCHIntranet\AFCHIntranet\Pages\_ViewImports.cshtml"
using AFCHIntranet.Models.Staff;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5f742dc40be24815cd6dd458e72bf0000a9d39fb", @"/Pages/Elder/IndexDelete.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"43053cce1082e111acdcfdb6b85f03c0ff074ab1", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Elder_IndexDelete : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("layui-bg-red"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<!--姓名搜索查询-->
<div class=""layui-form-item"">
    <label class=""layui-form-label"">姓名</label>
    <div class=""layui-input-inline"">
        <input type=""text"" class=""layui-input"" id=""nameInput"" name=""elderName"" />
    </div>
    <div class=""layui-input-inline"">
        <button class=""layui-btn layui-btn-primary"" onclick=""Elder_SearchNameListJson('IndexDelete')"">搜索</button>
    </div>
</div>

");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("div", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5f742dc40be24815cd6dd458e72bf0000a9d39fb4321", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper);
#nullable restore
#line 17 "C:\CodeRepos\AnFuCareHomeApp\AFCHIntranet\AFCHIntranet\Pages\Elder\IndexDelete.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper.ValidationSummary = global::Microsoft.AspNetCore.Mvc.Rendering.ValidationSummary.All;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-validation-summary", __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper.ValidationSummary, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n<!-- layui_table1 -->\r\n<div class=\"layui-row\">\r\n    <table class=\"layui-hide\" id=\"table1\" lay-filter=\"table1\"></table>\r\n</div>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <!--表格行操作模板-->
    <script type=""text/html"" id=""caoZuoTpl"">
        <a class=""layui-btn layui-btn-xs"" href=""/Elder/Details?id={{d.id}}&returnPage=IndexDelete"">详细</a>
        <a class=""layui-btn layui-btn-danger layui-btn-xs"" href=""/Elder/IndexDelete?handler=ToDelete&id={{d.id}}"" onclick=""javascript:return confirm('确定删除? 不可恢复!')"">删除</a>
    </script>

    <!--layui table-->
    <script>
        Page_Elder_IndexDelete();
    </script>

");
            }
            );
            WriteLiteral(" <!--Scripts section 结尾-->");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AFCHIntranet.Pages.Elder.IndexDeleteModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<AFCHIntranet.Pages.Elder.IndexDeleteModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<AFCHIntranet.Pages.Elder.IndexDeleteModel>)PageContext?.ViewData;
        public AFCHIntranet.Pages.Elder.IndexDeleteModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591