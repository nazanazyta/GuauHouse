#pragma checksum "G:\Repos\GuauHouse\GuauHouse\Views\Users\DatosUser.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cc13d3716bcc42b90f581c02769c00dd2f13d0aa"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Users_DatosUser), @"mvc.1.0.view", @"/Views/Users/DatosUser.cshtml")]
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
#line 1 "G:\Repos\GuauHouse\GuauHouse\Views\_ViewImports.cshtml"
using GuauHouse;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "G:\Repos\GuauHouse\GuauHouse\Views\_ViewImports.cshtml"
using GuauHouse.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "G:\Repos\GuauHouse\GuauHouse\Views\_ViewImports.cshtml"
using GuauHouse.Helpers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "G:\Repos\GuauHouse\GuauHouse\Views\_ViewImports.cshtml"
using System.Security.Claims;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cc13d3716bcc42b90f581c02769c00dd2f13d0aa", @"/Views/Users/DatosUser.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"33dfbb64b7a29e08de2a237c23eec46e551916dc", @"/Views/_ViewImports.cshtml")]
    public class Views_Users_DatosUser : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<User>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Users", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Perfil", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("background-color: mediumpurple"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("width: 12rem; height: 12rem"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("text-align: left"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("enctype", new global::Microsoft.AspNetCore.Html.HtmlString("multipart/form-data"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<h1 style=\"color: cornflowerblue\">Editar datos de ");
#nullable restore
#line 2 "G:\Repos\GuauHouse\GuauHouse\Views\Users\DatosUser.cshtml"
                                             Write(Model.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cc13d3716bcc42b90f581c02769c00dd2f13d0aa6765", async() => {
                WriteLiteral("Volver a perfil");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("<br />\r\n");
            WriteLiteral("<div class=\"container-fluid w-50 mt-5\">\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cc13d3716bcc42b90f581c02769c00dd2f13d0aa8387", async() => {
                WriteLiteral("\r\n        <input type=\"hidden\" name=\"idusuario\"");
                BeginWriteAttribute("value", " value=\"", 516, "\"", 540, 1);
#nullable restore
#line 8 "G:\Repos\GuauHouse\GuauHouse\Views\Users\DatosUser.cshtml"
WriteAttributeValue("", 524, Model.IdUsuario, 524, 16, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n        <input type=\"hidden\" name=\"imagen\"");
                BeginWriteAttribute("value", " value=\"", 588, "\"", 609, 1);
#nullable restore
#line 9 "G:\Repos\GuauHouse\GuauHouse\Views\Users\DatosUser.cshtml"
WriteAttributeValue("", 596, Model.Imagen, 596, 13, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n");
                WriteLiteral("        <table class=\"table\">\r\n            <tr class=\"row\">\r\n                <td class=\"col-5\">\r\n                    <label style=\"font-weight: bold\">Nombre</label><br />\r\n                    <label>");
#nullable restore
#line 19 "G:\Repos\GuauHouse\GuauHouse\Views\Users\DatosUser.cshtml"
                      Write(Model.Nombre);

#line default
#line hidden
#nullable disable
                WriteLiteral("</label>\r\n                </td>\r\n                <td class=\"col-5\">\r\n                    <input type=\"text\" name=\"nombre\"");
                BeginWriteAttribute("value", " value=\"", 1246, "\"", 1267, 1);
#nullable restore
#line 22 "G:\Repos\GuauHouse\GuauHouse\Views\Users\DatosUser.cshtml"
WriteAttributeValue("", 1254, Model.Nombre, 1254, 13, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@"
                           placeholder=""Nuevo nombre"" class=""form-control-sm"" /><br />
                </td>
            </tr>
            <tr class=""row"">
                <td class=""col-5"">
                    <label style=""font-weight: bold"">Apellidos</label><br />
                    <label>");
#nullable restore
#line 29 "G:\Repos\GuauHouse\GuauHouse\Views\Users\DatosUser.cshtml"
                      Write(Model.Apellidos);

#line default
#line hidden
#nullable disable
                WriteLiteral("</label>\r\n                </td>\r\n                <td class=\"col-5\">\r\n                    <input type=\"text\" name=\"apellidos\"");
                BeginWriteAttribute("value", " value=\"", 1711, "\"", 1735, 1);
#nullable restore
#line 32 "G:\Repos\GuauHouse\GuauHouse\Views\Users\DatosUser.cshtml"
WriteAttributeValue("", 1719, Model.Apellidos, 1719, 16, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"form-control-sm\" /><br />\r\n                </td>\r\n            </tr>\r\n            <tr class=\"row\">\r\n                <td class=\"col-5\">\r\n                    <label style=\"font-weight: bold\">DNI</label><br />\r\n                    <label>");
#nullable restore
#line 38 "G:\Repos\GuauHouse\GuauHouse\Views\Users\DatosUser.cshtml"
                      Write(Model.Dni);

#line default
#line hidden
#nullable disable
                WriteLiteral("</label>\r\n                </td>\r\n                <td class=\"col-5\">\r\n                    <input type=\"text\" name=\"dni\"");
                BeginWriteAttribute("value", " value=\"", 2106, "\"", 2124, 1);
#nullable restore
#line 41 "G:\Repos\GuauHouse\GuauHouse\Views\Users\DatosUser.cshtml"
WriteAttributeValue("", 2114, Model.Dni, 2114, 10, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"form-control-sm\" /><br />\r\n                </td>\r\n            </tr>\r\n            <tr class=\"row\">\r\n                <td class=\"col-5\">\r\n                    <label style=\"font-weight: bold\">Email</label><br />\r\n                    <label>");
#nullable restore
#line 47 "G:\Repos\GuauHouse\GuauHouse\Views\Users\DatosUser.cshtml"
                      Write(Model.Email);

#line default
#line hidden
#nullable disable
                WriteLiteral("</label>\r\n                </td>\r\n                <td class=\"col-5\">\r\n                    <input type=\"text\" name=\"email\"");
                BeginWriteAttribute("value", " value=\"", 2501, "\"", 2521, 1);
#nullable restore
#line 50 "G:\Repos\GuauHouse\GuauHouse\Views\Users\DatosUser.cshtml"
WriteAttributeValue("", 2509, Model.Email, 2509, 12, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"form-control-sm\" /><br />\r\n                </td>\r\n            </tr>\r\n            <tr class=\"row\">\r\n                <td class=\"col-5\">\r\n                    <label style=\"font-weight: bold\">Teléfono</label><br />\r\n                    <label>");
#nullable restore
#line 56 "G:\Repos\GuauHouse\GuauHouse\Views\Users\DatosUser.cshtml"
                      Write(Model.Telefono);

#line default
#line hidden
#nullable disable
                WriteLiteral("</label>\r\n                </td>\r\n                <td class=\"col-5\">\r\n                    <input type=\"text\" name=\"telefono\"");
                BeginWriteAttribute("value", " value=\"", 2907, "\"", 2930, 1);
#nullable restore
#line 59 "G:\Repos\GuauHouse\GuauHouse\Views\Users\DatosUser.cshtml"
WriteAttributeValue("", 2915, Model.Telefono, 2915, 15, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"form-control-sm\" /><br />\r\n                </td>\r\n            </tr>\r\n            <tr class=\"row\">\r\n                <td class=\"col-5\">\r\n                    <label style=\"font-weight: bold\">Imagen</label><br />\r\n");
#nullable restore
#line 65 "G:\Repos\GuauHouse\GuauHouse\Views\Users\DatosUser.cshtml"
                     if (Model.Imagen != null)
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "cc13d3716bcc42b90f581c02769c00dd2f13d0aa14861", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                AddHtmlAttributeValue("", 3254, "~/images/", 3254, 9, true);
#nullable restore
#line 67 "G:\Repos\GuauHouse\GuauHouse\Views\Users\DatosUser.cshtml"
AddHtmlAttributeValue("", 3263, Model.Imagen, 3263, 13, false);

#line default
#line hidden
#nullable disable
                EndAddHtmlAttributeValues(__tagHelperExecutionContext);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 68 "G:\Repos\GuauHouse\GuauHouse\Views\Users\DatosUser.cshtml"
                    }
                    else
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        <label>No hay foto</label>\r\n");
#nullable restore
#line 72 "G:\Repos\GuauHouse\GuauHouse\Views\Users\DatosUser.cshtml"
                    }

#line default
#line hidden
#nullable disable
                WriteLiteral("                </td>\r\n                <td class=\"col-5\">\r\n                    <input type=\"file\" name=\"fichero\" />\r\n                </td>\r\n            </tr>\r\n        </table>\r\n");
                WriteLiteral("        <button type=\"submit\" class=\"btn btn-success\">Editar datos</button>\r\n    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n\r\n");
            DefineSection("styles", async() => {
                WriteLiteral("\r\n    <style>\r\n        body {\r\n            background-size: cover !important;\r\n        }\r\n    </style>\r\n");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<User> Html { get; private set; }
    }
}
#pragma warning restore 1591
