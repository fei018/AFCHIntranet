#pragma checksum "C:\CodeRepos\AnFuCareHomeApp\AFCHIntranet\AFCHIntranet\Pages\Staff\Download.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fc1ecafcae3e2d441607d03ea4b68c0eacb21ccf"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AFCHIntranet.Pages.Staff.Pages_Staff_Download), @"mvc.1.0.razor-page", @"/Pages/Staff/Download.cshtml")]
namespace AFCHIntranet.Pages.Staff
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fc1ecafcae3e2d441607d03ea4b68c0eacb21ccf", @"/Pages/Staff/Download.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"43053cce1082e111acdcfdb6b85f03c0ff074ab1", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Staff_Download : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("layui-btn layui-btn-primary layui-btn-sm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page-handler", "ExcelWorking", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("enctype", new global::Microsoft.AspNetCore.Html.HtmlString("multipart/form-data"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page-handler", "UploadExcel", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\CodeRepos\AnFuCareHomeApp\AFCHIntranet\AFCHIntranet\Pages\Staff\Download.cshtml"
  
    var error = ViewData["Error"];

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<fieldset class=\"layui-elem-field layui-field-box\">\r\n    <legend>下载 员工资料</legend>\r\n\r\n    <div class=\" layui-inline\">\r\n        <label class=\"layui-form-label\">下载Excel</label>\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fc1ecafcae3e2d441607d03ea4b68c0eacb21ccf5856", async() => {
                WriteLiteral("在职人员");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.PageHandler = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </div>\r\n\r\n</fieldset>\r\n\r\n");
#nullable restore
#line 18 "C:\CodeRepos\AnFuCareHomeApp\AFCHIntranet\AFCHIntranet\Pages\Staff\Download.cshtml"
 if (User.IsInRole(LoginUserRole.Administrator))
{


#line default
#line hidden
#nullable disable
            WriteLiteral("    <fieldset class=\"layui-elem-field layui-field-box\">\r\n        <legend>上传 员工资料</legend>\r\n\r\n        <p>非系统管理员勿用</p>\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fc1ecafcae3e2d441607d03ea4b68c0eacb21ccf7520", async() => {
                WriteLiteral("\r\n");
                WriteLiteral(@"            <div class="" layui-inline"">
                <label class=""layui-form-label"">上传Excel</label>
                <input type=""file"" accept=""application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"" name=""uploadExcel"" />
            </div>
            <div>
                <input type=""submit"" class=""layui-btn layui-btn-primary"" value=""提交"" />
            </div>
        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.PageHandler = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </fieldset>\r\n");
#nullable restore
#line 39 "C:\CodeRepos\AnFuCareHomeApp\AFCHIntranet\AFCHIntranet\Pages\Staff\Download.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 42 "C:\CodeRepos\AnFuCareHomeApp\AFCHIntranet\AFCHIntranet\Pages\Staff\Download.cshtml"
 if (error != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <script>\r\n\r\n            alert(\'");
#nullable restore
#line 46 "C:\CodeRepos\AnFuCareHomeApp\AFCHIntranet\AFCHIntranet\Pages\Staff\Download.cshtml"
              Write(Html.Raw(error));

#line default
#line hidden
#nullable disable
            WriteLiteral("\');\r\n    </script>\r\n");
#nullable restore
#line 48 "C:\CodeRepos\AnFuCareHomeApp\AFCHIntranet\AFCHIntranet\Pages\Staff\Download.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AFCHIntranet.Pages.Staff.DownloadModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<AFCHIntranet.Pages.Staff.DownloadModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<AFCHIntranet.Pages.Staff.DownloadModel>)PageContext?.ViewData;
        public AFCHIntranet.Pages.Staff.DownloadModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
