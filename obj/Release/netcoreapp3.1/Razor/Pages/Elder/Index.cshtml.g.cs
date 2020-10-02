#pragma checksum "C:\CodeRepos\AnFuCareHomeApp\AFCHIntranet\AFCHIntranet\Pages\Elder\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "13a3dce2eb8350f8e0048153a204ff6a830928e2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AFCHIntranet.Pages.Elder.Pages_Elder_Index), @"mvc.1.0.razor-page", @"/Pages/Elder/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"13a3dce2eb8350f8e0048153a204ff6a830928e2", @"/Pages/Elder/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"43053cce1082e111acdcfdb6b85f03c0ff074ab1", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Elder_Index : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
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
<!--显示 体验 或 正式-->
<div class=""layui-form-item"">
    <label class=""layui-form-label"">分类显示</label>
    <div class=""layui-input-block"">
        <div class=""layui-btn-group"">
            <button class=""layui-btn layui-btn-sm"" onclick=""Elder_LiveAtListJson('Index')"">所有入住</button>
            <button class=""layui-btn layui-btn-sm"" onclick=""Elder_ExperienceListJson('Index')"">体验入住</button>
            <button class=""layui-btn layui-btn-sm"" onclick=""Elder_ContractListJson('Index')"">正式入住</button>
        </div>
    </div>
    <div class=""layui-input-block"">
        <div class=""layui-btn-group"">
            <button class=""layui-btn layui-btn-sm"" onclick=""Elder_ExperienceListJson_Expire('Index')"">体验到期</button>
            <button class=""layui-btn layui-btn-sm"" onclick=""Elder_ContractListJson_Expire('Index')"">正式到期</button>
        </div>
    </div>
</div>

<!--姓名搜索-->
<div class=""layui-form-item"">
    <label class=""layui-form-label"">姓名</label>
    <div class=""layui-input-inline"">
        <input typ");
            WriteLiteral(@"e=""text"" class=""layui-input"" id=""nameInput"" name=""elderName"" />
    </div>
    <div class=""layui-inline input-in-btn"">
        <button class=""layui-btn layui-btn-primary"" onclick=""Elder_SearchNameListJson('Index')""><i class=""layui-icon layui-icon-search""></i></button>
    </div>
</div>

");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("div", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "13a3dce2eb8350f8e0048153a204ff6a830928e25272", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper);
#nullable restore
#line 35 "C:\CodeRepos\AnFuCareHomeApp\AFCHIntranet\AFCHIntranet\Pages\Elder\Index.cshtml"
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
        <a class=""layui-btn layui-btn-xs"" href=""/Elder/Details?id={{d.id}}&returnPage=Index"">详细</a>
    </script>

    <!--layui table-->
    <script>
        Page_Elder_Index();
    </script>

");
            }
            );
            WriteLiteral(" <!--Scripts section 结尾-->\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AFCHIntranet.Pages.Elder.IndexModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<AFCHIntranet.Pages.Elder.IndexModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<AFCHIntranet.Pages.Elder.IndexModel>)PageContext?.ViewData;
        public AFCHIntranet.Pages.Elder.IndexModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
