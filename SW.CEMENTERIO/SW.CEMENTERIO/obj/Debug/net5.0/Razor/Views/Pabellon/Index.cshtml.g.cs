#pragma checksum "D:\Archivos\UTP\VIII CICLO\INTEGRADOR I\GIT\Cementerio\SW.CEMENTERIO\SW.CEMENTERIO\Views\Pabellon\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c0146152a960cf8a4fd9d41974c073e2d216a1a5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Pabellon_Index), @"mvc.1.0.view", @"/Views/Pabellon/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c0146152a960cf8a4fd9d41974c073e2d216a1a5", @"/Views/Pabellon/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6469408562fcdbd89c2a02aac387ea9fb4cacc21", @"/Views/_ViewImports.cshtml")]
    public class Views_Pabellon_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("dropdown-item"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/assets/Plantillas/PLANTILLA_PABELLON_NICHOS.xlsx"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("row g-3 needs-validation"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("formPabellon"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("row g-3"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("formNicho"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/pabellon.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\Archivos\UTP\VIII CICLO\INTEGRADOR I\GIT\Cementerio\SW.CEMENTERIO\SW.CEMENTERIO\Views\Pabellon\Index.cshtml"
  
    ViewData["Title"] = "Pabellon";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<!--start breadcrumb-->
<div class=""page-breadcrumb d-none d-sm-flex align-items-center mb-3"">
    <div class=""breadcrumb-title pe-3"">Lista de Pabellones</div>
    <div class=""ps-3"">
        <nav aria-label=""breadcrumb"">
            <ol class=""breadcrumb mb-0 p-0 align-items-center"">
                <li class=""breadcrumb-item active"" aria-current=""page"" id=""totalPabellon"">0</li>
            </ol>
        </nav>
    </div>
    <div class=""ms-auto"">
        <div class=""btn-group"">
            <button type=""button"" class=""btn btn-outline-primary"" onclick=""verPabellon()"">Nuevo <i class=""lni lni-plus""></i></button>
        </div>
        <div class=""btn-group"">
            <button type=""button"" class=""btn btn-outline-primary"">Carga Masiva</button>
            <button type=""button""
                    class=""btn btn-outline-primary split-bg-primary dropdown-toggle dropdown-toggle-split""
                    data-bs-toggle=""dropdown"">
                <span class=""visually-hidden"">Toggle Dropdown<");
            WriteLiteral("/span>\r\n            </button>\r\n            <div class=\"dropdown-menu dropdown-menu-right dropdown-menu-lg-end\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c0146152a960cf8a4fd9d41974c073e2d216a1a57789", async() => {
                WriteLiteral("Descargar Plantilla");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                <a class=""dropdown-item"" href=""javascript:void(0);"" data-bs-toggle=""modal"" data-bs-target=""#modalCargaMasiva"">Subir Archivo</a>
            </div>
        </div>
    </div>
</div>

<div class=""modal fade"" id=""modalCargaMasiva"" tabindex=""-1"" aria-hidden=""true"">
    <div class=""modal-dialog modal-dialog-centered"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title"">SUBIR ARCHIVO PARA CARGA MASIVA</h5>
                <button type=""button"" class=""btn-close"" data-bs-dismiss=""modal"" aria-label=""Close""></button>
            </div>
            <div class=""modal-body"">
                <input class=""form-control"" type=""file"" id=""pabellonFile"">
            </div>
            <div class=""modal-footer"">
                <button type=""button"" class=""btn btn-secondary"" data-bs-dismiss=""modal"">Cerrar</button>
                <button type=""button"" class=""btn btn-primary"" onclick=""CargaMasivaPabellon()"">Cargar</button>
         ");
            WriteLiteral(@"   </div>
        </div>
    </div>
</div>

<!--end breadcrumb-->
<hr />
<div class=""card"">
    <div class=""card-body"">
        <div class=""table-responsive"">
            <table id=""tablePabellon"" class=""table table-striped table-bordered"" style=""width:100%"">
                <thead>
                    <tr>
                        <th>Nombre</th>
                        <th>Tipo</th>
                        <th>Ubicación</th>
                        <th>Acciones</th>
                    </tr>
                </thead>
                <tbody></tbody>
            </table>
        </div>
    </div>
</div>


<div class=""modal fade"" id=""modalPabellon"" tabindex=""-1"" aria-hidden=""true"">
    <div class=""modal-dialog modal-dialog-centered"" id=""classModalPabellon"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title"" id=""lblModalPabellon""></h5>
                <button type=""button"" class=""btn-close"" data-bs-dismiss=""modal"" aria-");
            WriteLiteral("label=\"Close\"></button>\r\n            </div>\r\n            <div class=\"modal-body\">\r\n                <input type=\"text\" id=\"idPabellon\" hidden />\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c0146152a960cf8a4fd9d41974c073e2d216a1a511337", async() => {
                WriteLiteral(@"
                    <div class=""col-md-12"">
                        <label class=""form-label"">Nombre</label>
                        <input type=""text"" class=""form-control"" id=""nombrePabellon"" name=""nombrePabellon"" required>
                        <div class=""invalid-feedback"">Es un campo obligatorio</div>
                    </div>
                    <div class=""col-md-12"">
                        <div class=""form-check mb-3"">
                            <input type=""radio"" class=""form-check-input"" id=""rbnPabellon"" name=""rbPabellon"" valor=""1"" required>
                            <label class=""form-check-label"" for=""rbnPabellon"">Pabellón</label>
                        </div>
                        <div class=""form-check mb-3"">
                            <input type=""radio"" class=""form-check-input"" id=""rbnMausoleo"" name=""rbPabellon"" valor=""2"" required>
                            <label class=""form-check-label"" for=""rbnMausoleo"">Mausoleo</label>
                            <div class=""inva");
                WriteLiteral(@"lid-feedback"">Es un campo obligatorio</div>
                        </div>
                    </div>
                    <div class=""col-md-12"">
                        <label for=""formFile"" class=""form-label"">Croquis</label>
                        <input class=""form-control"" type=""file"" id=""filePabellon"">
                    </div>
                    <div class=""col-md-12"" id=""tablaAdicional"">
                        <div class=""page-breadcrumb d-none d-sm-flex align-items-center mb-3"">
                            <div class=""ms-auto"">
                                <div class=""btn-group"">
                                    <button type=""button"" class=""btn btn-outline-primary"" onclick=""verNicho()"">Nuevo Nicho <i class=""lni lni-plus""></i></button>
                                </div>
                            </div>
                        </div>
                        <hr />
                        <div class=""form-check"">
                            <table id=""tableNicho"" class=""t");
                WriteLiteral(@"able table-striped table-bordered"" style=""width:100%"">
                                <thead>
                                    <tr>
                                        <th>Código</th>
                                        <th>Estado</th>
                                        <th># Difuntos Total</th>
                                        <th># Difuntos Disponible</th>
                                        <th>Acciones</th>
                                    </tr>
                                </thead>
                                <tbody></tbody>
                            </table>
                        </div>
                    </div>
                    <div class=""modal-footer"">
                        <button type=""button"" class=""btn btn-secondary"" data-bs-dismiss=""modal"">Cerrar</button>
                        <button type=""button"" class=""btn btn-primary"" onclick=""addPabellon()"" id=""btnAddPabellon"">Guardar</button>
                    </div>
                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            BeginWriteTagHelperAttribute();
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("novalidate", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
            </div>
        </div>
    </div>
</div>

<div class=""modal fade"" id=""modalNicho"" tabindex=""-1"" aria-hidden=""true"">
    <div class=""modal-dialog modal-dialog-centered"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <input type=""hidden"" class=""form-control detalle"" id=""idNicho"" />
                <h5 class=""modal-title"" id=""lblmodalNicho""></h5>
                <button type=""button"" class=""btn-close"" data-bs-dismiss=""modal"" aria-label=""Close""></button>
            </div>
            <div class=""modal-body"">
                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c0146152a960cf8a4fd9d41974c073e2d216a1a517119", async() => {
                WriteLiteral(@"
                    <div class=""col-md-6"">
                        <label for=""codigoNicho"" class=""form-label"">Código</label>
                        <input type=""text"" class=""form-control detalle"" id=""codigoNicho"" name=""codigoNicho"" required />
                        <div class=""invalid-feedback"">Campo obligatorio</div>
                    </div>
                    <div class=""col-md-6"">
                        <label for=""codigoNicho"" class=""form-label""># Difuntos</label>
                        <input type=""text"" class=""form-control detalle soloNumero"" id=""numDifNicho"" name=""numDifNicho"" required/>
                        <div class=""invalid-feedback"">Campo obligatorio</div>
                    </div>
                    <div class=""col-12 text-right"">
                        <button class=""btn btn-primary"" type=""button"" onclick=""addNicho()"" id=""btnAddNicho""></button>
                    </div>
                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            BeginWriteTagHelperAttribute();
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("novalidate", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
            </div>
        </div>
    </div>
</div>

<div class=""modal fade"" id=""modalCroquis"" tabindex=""-1"" aria-hidden=""true"">
    <div class=""modal-dialog modal-dialog-centered modal-lg"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title"" id=""lblmodalCroquis""></h5>
                <button type=""button"" class=""btn-close"" data-bs-dismiss=""modal"" aria-label=""Close""></button>
            </div>
            <div class=""modal-body"">
                <div class=""col-12 col-lg-12 col-xl-12"">
                    <div class=""card overflow-hidden radius-10"">
                        <div class=""card-body"">
                            <div class=""d-flex align-items-start justify-content-between"">
                                <img id=""imgCroquis"" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>

");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c0146152a960cf8a4fd9d41974c073e2d216a1a520861", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
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
