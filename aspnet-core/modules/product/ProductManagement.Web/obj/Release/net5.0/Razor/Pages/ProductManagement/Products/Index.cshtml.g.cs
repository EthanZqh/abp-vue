#pragma checksum "E:\MicroserviceDemo\modules\product\src\ProductManagement.Web\Pages\ProductManagement\Products\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "be9e8fd873947a8d7fd3305045a51935e5e7a554"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Pages_ProductManagement_Products_Index), @"mvc.1.0.razor-page", @"/Pages/ProductManagement/Products/Index.cshtml")]
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
#line 2 "E:\MicroserviceDemo\modules\product\src\ProductManagement.Web\Pages\ProductManagement\Products\Index.cshtml"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "E:\MicroserviceDemo\modules\product\src\ProductManagement.Web\Pages\ProductManagement\Products\Index.cshtml"
using Microsoft.AspNetCore.Mvc.Localization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "E:\MicroserviceDemo\modules\product\src\ProductManagement.Web\Pages\ProductManagement\Products\Index.cshtml"
using ProductManagement;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "E:\MicroserviceDemo\modules\product\src\ProductManagement.Web\Pages\ProductManagement\Products\Index.cshtml"
using ProductManagement.Localization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "E:\MicroserviceDemo\modules\product\src\ProductManagement.Web\Pages\ProductManagement\Products\Index.cshtml"
using Volo.Abp.AspNetCore.Mvc.UI.Theming;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"be9e8fd873947a8d7fd3305045a51935e5e7a554", @"/Pages/ProductManagement/Products/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"25152d795852518cc499282e563bc297efeed2a9", @"/Pages/ProductManagement/_ViewImports.cshtml")]
    #nullable restore
    public class Pages_ProductManagement_Products_Index : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", "/Pages/ProductManagement/Products/index.js", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("icon", "plus", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("CreateNewProductButtonId"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("text-right"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("ProductsTable"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("nowrap"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Volo.Abp.AspNetCore.Mvc.UI.Bundling.TagHelpers.AbpScriptTagHelper __Volo_Abp_AspNetCore_Mvc_UI_Bundling_TagHelpers_AbpScriptTagHelper;
        private global::Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Card.AbpCardTagHelper __Volo_Abp_AspNetCore_Mvc_UI_Bootstrap_TagHelpers_Card_AbpCardTagHelper;
        private global::Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Card.AbpCardHeaderTagHelper __Volo_Abp_AspNetCore_Mvc_UI_Bootstrap_TagHelpers_Card_AbpCardHeaderTagHelper;
        private global::Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Grid.AbpRowTagHelper __Volo_Abp_AspNetCore_Mvc_UI_Bootstrap_TagHelpers_Grid_AbpRowTagHelper;
        private global::Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Grid.AbpColumnTagHelper __Volo_Abp_AspNetCore_Mvc_UI_Bootstrap_TagHelpers_Grid_AbpColumnTagHelper;
        private global::Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Button.AbpButtonTagHelper __Volo_Abp_AspNetCore_Mvc_UI_Bootstrap_TagHelpers_Button_AbpButtonTagHelper;
        private global::Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Card.AbpCardBodyTagHelper __Volo_Abp_AspNetCore_Mvc_UI_Bootstrap_TagHelpers_Card_AbpCardBodyTagHelper;
        private global::Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Table.AbpTableTagHelper __Volo_Abp_AspNetCore_Mvc_UI_Bootstrap_TagHelpers_Table_AbpTableTagHelper;
        private global::Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Table.AbpTableHeaderTagHelper __Volo_Abp_AspNetCore_Mvc_UI_Bootstrap_TagHelpers_Table_AbpTableHeaderTagHelper;
        private global::Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Table.AbpTableStyleTagHelper __Volo_Abp_AspNetCore_Mvc_UI_Bootstrap_TagHelpers_Table_AbpTableStyleTagHelper;
        private global::Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Table.AbpTableHeadScopeTagHelper __Volo_Abp_AspNetCore_Mvc_UI_Bootstrap_TagHelpers_Table_AbpTableHeadScopeTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 11 "E:\MicroserviceDemo\modules\product\src\ProductManagement.Web\Pages\ProductManagement\Products\Index.cshtml"
  
    ViewBag.PageTitle = "Products";
    Layout = ThemeManager.CurrentTheme.GetApplicationLayout();

#line default
#line hidden
#nullable disable
            WriteLiteral("\n");
            DefineSection("scripts", async() => {
                WriteLiteral("\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("abp-script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "be9e8fd873947a8d7fd3305045a51935e5e7a5548221", async() => {
                }
                );
                __Volo_Abp_AspNetCore_Mvc_UI_Bundling_TagHelpers_AbpScriptTagHelper = CreateTagHelper<global::Volo.Abp.AspNetCore.Mvc.UI.Bundling.TagHelpers.AbpScriptTagHelper>();
                __tagHelperExecutionContext.Add(__Volo_Abp_AspNetCore_Mvc_UI_Bundling_TagHelpers_AbpScriptTagHelper);
                __Volo_Abp_AspNetCore_Mvc_UI_Bundling_TagHelpers_AbpScriptTagHelper.Src = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\n");
            }
            );
            WriteLiteral("\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("abp-card", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "be9e8fd873947a8d7fd3305045a51935e5e7a5549509", async() => {
                WriteLiteral("\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("abp-card-header", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "be9e8fd873947a8d7fd3305045a51935e5e7a5549773", async() => {
                    WriteLiteral("\n        ");
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("abp-row", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "be9e8fd873947a8d7fd3305045a51935e5e7a55410056", async() => {
                        WriteLiteral("\n            ");
                        __tagHelperExecutionContext = __tagHelperScopeManager.Begin("abp-column", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "be9e8fd873947a8d7fd3305045a51935e5e7a55410344", async() => {
                            WriteLiteral("\n                <h2>");
#nullable restore
#line 24 "E:\MicroserviceDemo\modules\product\src\ProductManagement.Web\Pages\ProductManagement\Products\Index.cshtml"
               Write(L["Products"]);

#line default
#line hidden
#nullable disable
                            WriteLiteral("</h2>\n            ");
                        }
                        );
                        __Volo_Abp_AspNetCore_Mvc_UI_Bootstrap_TagHelpers_Grid_AbpColumnTagHelper = CreateTagHelper<global::Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Grid.AbpColumnTagHelper>();
                        __tagHelperExecutionContext.Add(__Volo_Abp_AspNetCore_Mvc_UI_Bootstrap_TagHelpers_Grid_AbpColumnTagHelper);
#nullable restore
#line 23 "E:\MicroserviceDemo\modules\product\src\ProductManagement.Web\Pages\ProductManagement\Products\Index.cshtml"
__Volo_Abp_AspNetCore_Mvc_UI_Bootstrap_TagHelpers_Grid_AbpColumnTagHelper.SizeMd = global::Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Grid.ColumnSize._6;

#line default
#line hidden
#nullable disable
                        __tagHelperExecutionContext.AddTagHelperAttribute("size-md", __Volo_Abp_AspNetCore_Mvc_UI_Bootstrap_TagHelpers_Grid_AbpColumnTagHelper.SizeMd, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                        await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                        if (!__tagHelperExecutionContext.Output.IsContentModified)
                        {
                            await __tagHelperExecutionContext.SetOutputContentAsync();
                        }
                        Write(__tagHelperExecutionContext.Output);
                        __tagHelperExecutionContext = __tagHelperScopeManager.End();
                        WriteLiteral("\n            ");
                        __tagHelperExecutionContext = __tagHelperScopeManager.Begin("abp-column", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "be9e8fd873947a8d7fd3305045a51935e5e7a55412456", async() => {
                            WriteLiteral("\n");
#nullable restore
#line 27 "E:\MicroserviceDemo\modules\product\src\ProductManagement.Web\Pages\ProductManagement\Products\Index.cshtml"
                 if (await Authorization.IsGrantedAsync(ProductManagementPermissions.Products.Create))
                {

#line default
#line hidden
#nullable disable
                            WriteLiteral("                    ");
                            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("abp-button", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "be9e8fd873947a8d7fd3305045a51935e5e7a55413120", async() => {
                            }
                            );
                            __Volo_Abp_AspNetCore_Mvc_UI_Bootstrap_TagHelpers_Button_AbpButtonTagHelper = CreateTagHelper<global::Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Button.AbpButtonTagHelper>();
                            __tagHelperExecutionContext.Add(__Volo_Abp_AspNetCore_Mvc_UI_Bootstrap_TagHelpers_Button_AbpButtonTagHelper);
                            __Volo_Abp_AspNetCore_Mvc_UI_Bootstrap_TagHelpers_Button_AbpButtonTagHelper.Icon = (string)__tagHelperAttribute_1.Value;
                            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                            BeginWriteTagHelperAttribute();
#nullable restore
#line 29 "E:\MicroserviceDemo\modules\product\src\ProductManagement.Web\Pages\ProductManagement\Products\Index.cshtml"
                                      WriteLiteral(L["CreateANewProduct"].Value);

#line default
#line hidden
#nullable disable
                            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                            __Volo_Abp_AspNetCore_Mvc_UI_Bootstrap_TagHelpers_Button_AbpButtonTagHelper.Text = __tagHelperStringValueBuffer;
                            __tagHelperExecutionContext.AddTagHelperAttribute("text", __Volo_Abp_AspNetCore_Mvc_UI_Bootstrap_TagHelpers_Button_AbpButtonTagHelper.Text, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 29 "E:\MicroserviceDemo\modules\product\src\ProductManagement.Web\Pages\ProductManagement\Products\Index.cshtml"
__Volo_Abp_AspNetCore_Mvc_UI_Bootstrap_TagHelpers_Button_AbpButtonTagHelper.ButtonType = global::Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Button.AbpButtonType.Primary;

#line default
#line hidden
#nullable disable
                            __tagHelperExecutionContext.AddTagHelperAttribute("button-type", __Volo_Abp_AspNetCore_Mvc_UI_Bootstrap_TagHelpers_Button_AbpButtonTagHelper.ButtonType, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                            if (!__tagHelperExecutionContext.Output.IsContentModified)
                            {
                                await __tagHelperExecutionContext.SetOutputContentAsync();
                            }
                            Write(__tagHelperExecutionContext.Output);
                            __tagHelperExecutionContext = __tagHelperScopeManager.End();
                            WriteLiteral("\n");
#nullable restore
#line 30 "E:\MicroserviceDemo\modules\product\src\ProductManagement.Web\Pages\ProductManagement\Products\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
                            WriteLiteral("            ");
                        }
                        );
                        __Volo_Abp_AspNetCore_Mvc_UI_Bootstrap_TagHelpers_Grid_AbpColumnTagHelper = CreateTagHelper<global::Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Grid.AbpColumnTagHelper>();
                        __tagHelperExecutionContext.Add(__Volo_Abp_AspNetCore_Mvc_UI_Bootstrap_TagHelpers_Grid_AbpColumnTagHelper);
#nullable restore
#line 26 "E:\MicroserviceDemo\modules\product\src\ProductManagement.Web\Pages\ProductManagement\Products\Index.cshtml"
__Volo_Abp_AspNetCore_Mvc_UI_Bootstrap_TagHelpers_Grid_AbpColumnTagHelper.SizeMd = global::Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Grid.ColumnSize._6;

#line default
#line hidden
#nullable disable
                        __tagHelperExecutionContext.AddTagHelperAttribute("size-md", __Volo_Abp_AspNetCore_Mvc_UI_Bootstrap_TagHelpers_Grid_AbpColumnTagHelper.SizeMd, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                        __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                        await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                        if (!__tagHelperExecutionContext.Output.IsContentModified)
                        {
                            await __tagHelperExecutionContext.SetOutputContentAsync();
                        }
                        Write(__tagHelperExecutionContext.Output);
                        __tagHelperExecutionContext = __tagHelperScopeManager.End();
                        WriteLiteral("\n        ");
                    }
                    );
                    __Volo_Abp_AspNetCore_Mvc_UI_Bootstrap_TagHelpers_Grid_AbpRowTagHelper = CreateTagHelper<global::Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Grid.AbpRowTagHelper>();
                    __tagHelperExecutionContext.Add(__Volo_Abp_AspNetCore_Mvc_UI_Bootstrap_TagHelpers_Grid_AbpRowTagHelper);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    WriteLiteral("\n    ");
                }
                );
                __Volo_Abp_AspNetCore_Mvc_UI_Bootstrap_TagHelpers_Card_AbpCardHeaderTagHelper = CreateTagHelper<global::Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Card.AbpCardHeaderTagHelper>();
                __tagHelperExecutionContext.Add(__Volo_Abp_AspNetCore_Mvc_UI_Bootstrap_TagHelpers_Card_AbpCardHeaderTagHelper);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("abp-card-body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "be9e8fd873947a8d7fd3305045a51935e5e7a55419650", async() => {
                    WriteLiteral("\n        ");
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("abp-table", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "be9e8fd873947a8d7fd3305045a51935e5e7a55419932", async() => {
                        WriteLiteral("\n            ");
                        __tagHelperExecutionContext = __tagHelperScopeManager.Begin("thead", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "be9e8fd873947a8d7fd3305045a51935e5e7a55420222", async() => {
                            WriteLiteral("\n                ");
                            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("tr", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "be9e8fd873947a8d7fd3305045a51935e5e7a55420520", async() => {
                                WriteLiteral("\n                    ");
                                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("th", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "be9e8fd873947a8d7fd3305045a51935e5e7a55420827", async() => {
#nullable restore
#line 38 "E:\MicroserviceDemo\modules\product\src\ProductManagement.Web\Pages\ProductManagement\Products\Index.cshtml"
                   Write(L["Actions"]);

#line default
#line hidden
#nullable disable
                                }
                                );
                                __Volo_Abp_AspNetCore_Mvc_UI_Bootstrap_TagHelpers_Table_AbpTableHeadScopeTagHelper = CreateTagHelper<global::Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Table.AbpTableHeadScopeTagHelper>();
                                __tagHelperExecutionContext.Add(__Volo_Abp_AspNetCore_Mvc_UI_Bootstrap_TagHelpers_Table_AbpTableHeadScopeTagHelper);
                                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                                if (!__tagHelperExecutionContext.Output.IsContentModified)
                                {
                                    await __tagHelperExecutionContext.SetOutputContentAsync();
                                }
                                Write(__tagHelperExecutionContext.Output);
                                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                                WriteLiteral("\n                    ");
                                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("th", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "be9e8fd873947a8d7fd3305045a51935e5e7a55422336", async() => {
#nullable restore
#line 39 "E:\MicroserviceDemo\modules\product\src\ProductManagement.Web\Pages\ProductManagement\Products\Index.cshtml"
                   Write(L["Code"]);

#line default
#line hidden
#nullable disable
                                }
                                );
                                __Volo_Abp_AspNetCore_Mvc_UI_Bootstrap_TagHelpers_Table_AbpTableHeadScopeTagHelper = CreateTagHelper<global::Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Table.AbpTableHeadScopeTagHelper>();
                                __tagHelperExecutionContext.Add(__Volo_Abp_AspNetCore_Mvc_UI_Bootstrap_TagHelpers_Table_AbpTableHeadScopeTagHelper);
                                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                                if (!__tagHelperExecutionContext.Output.IsContentModified)
                                {
                                    await __tagHelperExecutionContext.SetOutputContentAsync();
                                }
                                Write(__tagHelperExecutionContext.Output);
                                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                                WriteLiteral("\n                    ");
                                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("th", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "be9e8fd873947a8d7fd3305045a51935e5e7a55423842", async() => {
#nullable restore
#line 40 "E:\MicroserviceDemo\modules\product\src\ProductManagement.Web\Pages\ProductManagement\Products\Index.cshtml"
                   Write(L["Name"]);

#line default
#line hidden
#nullable disable
                                }
                                );
                                __Volo_Abp_AspNetCore_Mvc_UI_Bootstrap_TagHelpers_Table_AbpTableHeadScopeTagHelper = CreateTagHelper<global::Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Table.AbpTableHeadScopeTagHelper>();
                                __tagHelperExecutionContext.Add(__Volo_Abp_AspNetCore_Mvc_UI_Bootstrap_TagHelpers_Table_AbpTableHeadScopeTagHelper);
                                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                                if (!__tagHelperExecutionContext.Output.IsContentModified)
                                {
                                    await __tagHelperExecutionContext.SetOutputContentAsync();
                                }
                                Write(__tagHelperExecutionContext.Output);
                                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                                WriteLiteral("\n                    ");
                                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("th", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "be9e8fd873947a8d7fd3305045a51935e5e7a55425348", async() => {
#nullable restore
#line 41 "E:\MicroserviceDemo\modules\product\src\ProductManagement.Web\Pages\ProductManagement\Products\Index.cshtml"
                   Write(L["Price"]);

#line default
#line hidden
#nullable disable
                                }
                                );
                                __Volo_Abp_AspNetCore_Mvc_UI_Bootstrap_TagHelpers_Table_AbpTableHeadScopeTagHelper = CreateTagHelper<global::Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Table.AbpTableHeadScopeTagHelper>();
                                __tagHelperExecutionContext.Add(__Volo_Abp_AspNetCore_Mvc_UI_Bootstrap_TagHelpers_Table_AbpTableHeadScopeTagHelper);
                                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                                if (!__tagHelperExecutionContext.Output.IsContentModified)
                                {
                                    await __tagHelperExecutionContext.SetOutputContentAsync();
                                }
                                Write(__tagHelperExecutionContext.Output);
                                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                                WriteLiteral("\n                    ");
                                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("th", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "be9e8fd873947a8d7fd3305045a51935e5e7a55426855", async() => {
#nullable restore
#line 42 "E:\MicroserviceDemo\modules\product\src\ProductManagement.Web\Pages\ProductManagement\Products\Index.cshtml"
                   Write(L["StockCount"]);

#line default
#line hidden
#nullable disable
                                }
                                );
                                __Volo_Abp_AspNetCore_Mvc_UI_Bootstrap_TagHelpers_Table_AbpTableHeadScopeTagHelper = CreateTagHelper<global::Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Table.AbpTableHeadScopeTagHelper>();
                                __tagHelperExecutionContext.Add(__Volo_Abp_AspNetCore_Mvc_UI_Bootstrap_TagHelpers_Table_AbpTableHeadScopeTagHelper);
                                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                                if (!__tagHelperExecutionContext.Output.IsContentModified)
                                {
                                    await __tagHelperExecutionContext.SetOutputContentAsync();
                                }
                                Write(__tagHelperExecutionContext.Output);
                                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                                WriteLiteral("\n                ");
                            }
                            );
                            __Volo_Abp_AspNetCore_Mvc_UI_Bootstrap_TagHelpers_Table_AbpTableStyleTagHelper = CreateTagHelper<global::Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Table.AbpTableStyleTagHelper>();
                            __tagHelperExecutionContext.Add(__Volo_Abp_AspNetCore_Mvc_UI_Bootstrap_TagHelpers_Table_AbpTableStyleTagHelper);
                            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                            if (!__tagHelperExecutionContext.Output.IsContentModified)
                            {
                                await __tagHelperExecutionContext.SetOutputContentAsync();
                            }
                            Write(__tagHelperExecutionContext.Output);
                            __tagHelperExecutionContext = __tagHelperScopeManager.End();
                            WriteLiteral("\n            ");
                        }
                        );
                        __Volo_Abp_AspNetCore_Mvc_UI_Bootstrap_TagHelpers_Table_AbpTableHeaderTagHelper = CreateTagHelper<global::Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Table.AbpTableHeaderTagHelper>();
                        __tagHelperExecutionContext.Add(__Volo_Abp_AspNetCore_Mvc_UI_Bootstrap_TagHelpers_Table_AbpTableHeaderTagHelper);
                        await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                        if (!__tagHelperExecutionContext.Output.IsContentModified)
                        {
                            await __tagHelperExecutionContext.SetOutputContentAsync();
                        }
                        Write(__tagHelperExecutionContext.Output);
                        __tagHelperExecutionContext = __tagHelperScopeManager.End();
                        WriteLiteral("\n        ");
                    }
                    );
                    __Volo_Abp_AspNetCore_Mvc_UI_Bootstrap_TagHelpers_Table_AbpTableTagHelper = CreateTagHelper<global::Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Table.AbpTableTagHelper>();
                    __tagHelperExecutionContext.Add(__Volo_Abp_AspNetCore_Mvc_UI_Bootstrap_TagHelpers_Table_AbpTableTagHelper);
#nullable restore
#line 35 "E:\MicroserviceDemo\modules\product\src\ProductManagement.Web\Pages\ProductManagement\Products\Index.cshtml"
__Volo_Abp_AspNetCore_Mvc_UI_Bootstrap_TagHelpers_Table_AbpTableTagHelper.StripedRows = true;

#line default
#line hidden
#nullable disable
                    __tagHelperExecutionContext.AddTagHelperAttribute("striped-rows", __Volo_Abp_AspNetCore_Mvc_UI_Bootstrap_TagHelpers_Table_AbpTableTagHelper.StripedRows, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                    __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                    __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    WriteLiteral("\n    ");
                }
                );
                __Volo_Abp_AspNetCore_Mvc_UI_Bootstrap_TagHelpers_Card_AbpCardBodyTagHelper = CreateTagHelper<global::Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Card.AbpCardBodyTagHelper>();
                __tagHelperExecutionContext.Add(__Volo_Abp_AspNetCore_Mvc_UI_Bootstrap_TagHelpers_Card_AbpCardBodyTagHelper);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\n");
            }
            );
            __Volo_Abp_AspNetCore_Mvc_UI_Bootstrap_TagHelpers_Card_AbpCardTagHelper = CreateTagHelper<global::Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Card.AbpCardTagHelper>();
            __tagHelperExecutionContext.Add(__Volo_Abp_AspNetCore_Mvc_UI_Bootstrap_TagHelpers_Card_AbpCardTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IHtmlLocalizer<ProductManagementResource> L { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IAuthorizationService Authorization { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IThemeManager ThemeManager { get; private set; } = default!;
        #nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ProductManagement.Pages.ProductManagement.Products.IndexModel> Html { get; private set; } = default!;
        #nullable disable
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ProductManagement.Pages.ProductManagement.Products.IndexModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ProductManagement.Pages.ProductManagement.Products.IndexModel>)PageContext?.ViewData;
        public ProductManagement.Pages.ProductManagement.Products.IndexModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
