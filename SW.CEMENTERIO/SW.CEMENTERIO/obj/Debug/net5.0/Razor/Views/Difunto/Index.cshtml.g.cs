#pragma checksum "D:\Archivos\UTP\VIII CICLO\INTEGRADOR I\GIT\Cementerio\SW.CEMENTERIO\SW.CEMENTERIO\Views\Difunto\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "37f67134d603738c9cb93ef4464a1d4a90088593"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Difunto_Index), @"mvc.1.0.view", @"/Views/Difunto/Index.cshtml")]
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
#line 1 "D:\Archivos\UTP\VIII CICLO\INTEGRADOR I\GIT\Cementerio\SW.CEMENTERIO\SW.CEMENTERIO\Views\_ViewImports.cshtml"
using SW.CEMENTERIO;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Archivos\UTP\VIII CICLO\INTEGRADOR I\GIT\Cementerio\SW.CEMENTERIO\SW.CEMENTERIO\Views\_ViewImports.cshtml"
using SW.CEMENTERIO.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"37f67134d603738c9cb93ef4464a1d4a90088593", @"/Views/Difunto/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6469408562fcdbd89c2a02aac387ea9fb4cacc21", @"/Views/_ViewImports.cshtml")]
    public class Views_Difunto_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("row g-3 needs-validation"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("formDifunto"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/Difunto.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\Archivos\UTP\VIII CICLO\INTEGRADOR I\GIT\Cementerio\SW.CEMENTERIO\SW.CEMENTERIO\Views\Difunto\Index.cshtml"
  
    ViewData["Title"] = "Difunto";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<!--start breadcrumb-->
<div class=""page-breadcrumb d-none d-sm-flex align-items-center mb-3"">
    <div class=""breadcrumb-title pe-3"">Lista de Difuntos</div>
    <div class=""ps-3"">
        <nav aria-label=""breadcrumb"">
            <ol class=""breadcrumb mb-0 p-0 align-items-center"">
                <li class=""breadcrumb-item active"" aria-current=""page"" id=""totalDifunto"">0</li>
            </ol>
        </nav>
    </div>
    <div class=""ms-auto"">
        <div class=""btn-group"">
            <button type=""button"" class=""btn btn-outline-primary"" onclick=""verDifunto()"">Nuevo <i class=""lni lni-plus""></i></button>
        </div>
    </div>
</div>
<!--end breadcrumb-->
<hr />
<div class=""card"">
    <div class=""card-body"">
        <div class=""table-responsive"">
            <table id=""tableDifunto"" class=""table table-striped table-bordered"" style=""width:100%"">
                <thead>
                    <tr>
                        <th>Ape. Paterno</th>
                        <th>Ape. Materno");
            WriteLiteral(@"</th>
                        <th>Nombres</th>
                        <th>Fec. Defunción</th>
                        <th>Pabellón</th>
                        <th>Nicho</th>
                        <th>Acciones</th>
                    </tr>
                </thead>
                <tbody></tbody>
            </table>
        </div>
    </div>
</div>


<div class=""modal fade"" id=""modalDifunto"" tabindex=""-1"" aria-hidden=""true"">
    <div class=""modal-dialog modal-dialog-centered"" id=""classModalDifunto"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title"" id=""lblModalDifunto""></h5>
                <button type=""button"" class=""btn-close"" data-bs-dismiss=""modal"" aria-label=""Close""></button>
            </div>
            <div class=""modal-body"">
                <input type=""text"" id=""idNichoDifunto"" hidden />
                <input type=""text"" id=""idDifunto"" hidden />
                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "37f67134d603738c9cb93ef4464a1d4a900885937227", async() => {
                WriteLiteral(@"
                    <div class=""col-md-12"">
                        <label class=""form-label"">Número de Documento</label>
                        <input type=""text"" class=""form-control soloNumeros"" id=""dniDifunto"" name=""dniDifunto"" required>
                        <div class=""invalid-feedback"">Es un campo obligatorio</div>
                    </div>
                    <div class=""col-md-6"">
                        <label class=""form-label"">Apellido Paterno</label>
                        <input type=""text"" class=""form-control"" id=""apePaterno"" name=""apePaterno"" required>
                        <div class=""invalid-feedback"">Es un campo obligatorio</div>
                    </div>
                    <div class=""col-md-6"">
                        <label class=""form-label"">Apellido Materno</label>
                        <input type=""text"" class=""form-control"" id=""apeMaterno"" name=""apeMaterno"" required>
                        <div class=""invalid-feedback"">Es un campo obligatorio</div>
        ");
                WriteLiteral(@"            </div>
                    <div class=""col-md-6"">
                        <label class=""form-label"">Nombres</label>
                        <input type=""text"" class=""form-control"" id=""nombreDifunto"" name=""nombreDifunto"" required>
                        <div class=""invalid-feedback"">Es un campo obligatorio</div>
                    </div>
                    <div class=""col-md-6"">
                        <label class=""form-label"">Fecha Defunción</label>
                        <input class=""result form-control"" type=""text"" id=""fecDefuncion"" placeholder=""dd/mm/yyyy"">
                        <div class=""invalid-feedback"">Es un campo obligatorio</div>
                    </div>
                    <div class=""col-md-6"">
                        <label class=""form-label"">Pabellón</label>
                        <select class=""form-select form-select-sm mb-3"" aria-label="".form-select-sm example"" id=""selectPabellon"" onchange=""cargarNicho(this.value)""></select>
                        <div c");
                WriteLiteral(@"lass=""invalid-feedback"">Es un campo obligatorio</div>
                    </div>
                    <div class=""col-md-6"">
                        <label class=""form-label"">Nicho</label>
                        <select class=""form-select form-select-sm mb-3"" aria-label="".form-select-sm example"" id=""selectNicho""></select>
                        <div class=""invalid-feedback"">Es un campo obligatorio</div>
                    </div>
                    <div class=""modal-footer"">
                        <button type=""button"" class=""btn btn-secondary"" data-bs-dismiss=""modal"">Cerrar</button>
                        <button type=""button"" class=""btn btn-primary"" onclick=""addDifunto()"" id=""btnAddDifunto"">Guardar</button>
                    </div>
                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            BeginWriteTagHelperAttribute();
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("novalidate", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "37f67134d603738c9cb93ef4464a1d4a9008859312211", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
