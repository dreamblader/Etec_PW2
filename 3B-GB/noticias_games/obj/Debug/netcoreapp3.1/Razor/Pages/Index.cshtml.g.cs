#pragma checksum "C:\Users\Gm3\source\repos\3B-GB\noticias_games\Pages\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "326764354974549cf822a1811b21f90da5e9b0a1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(proj01.Pages.Pages_Index), @"mvc.1.0.razor-page", @"/Pages/Index.cshtml")]
namespace proj01.Pages
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
#line 1 "C:\Users\Gm3\source\repos\3B-GB\noticias_games\Pages\_ViewImports.cshtml"
using proj01;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"326764354974549cf822a1811b21f90da5e9b0a1", @"/Pages/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"260a7327f258f440720e67db3c8503d569bfaf20", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Index : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\Gm3\source\repos\3B-GB\noticias_games\Pages\Index.cshtml"
  
    ViewData["Title"] = "Home page";
    ViewData["Connections"] = "500 gamers";
    int index = 0;
    string active;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"text-center\">\r\n    <h1>\r\n        Bem-vindo ao ");
#nullable restore
#line 12 "C:\Users\Gm3\source\repos\3B-GB\noticias_games\Pages\Index.cshtml"
                Write(Model.nome);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        <br />\r\n        Confira nossas novidades\r\n    </h1>\r\n\r\n    <div id=\"carouselExampleIndicators\" class=\"carousel slide\" data-ride=\"carousel\">\r\n        <ol class=\"carousel-indicators\">\r\n");
#nullable restore
#line 19 "C:\Users\Gm3\source\repos\3B-GB\noticias_games\Pages\Index.cshtml"
             for (int i = 0; i < Model.listaNoticias.Count; i++)
            {
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 21 "C:\Users\Gm3\source\repos\3B-GB\noticias_games\Pages\Index.cshtml"
                 if(i==0)
                {
                    active = "active";
                }
                else
                {
                    active = "";
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                <li data-target=\"#carouselExampleIndicators\" data-slide-to=");
#nullable restore
#line 30 "C:\Users\Gm3\source\repos\3B-GB\noticias_games\Pages\Index.cshtml"
                                                                      Write(i);

#line default
#line hidden
#nullable disable
            BeginWriteAttribute("class", " class=", 779, "", 793, 1);
#nullable restore
#line 30 "C:\Users\Gm3\source\repos\3B-GB\noticias_games\Pages\Index.cshtml"
WriteAttributeValue("", 786, active, 786, 7, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("></li>\r\n");
#nullable restore
#line 31 "C:\Users\Gm3\source\repos\3B-GB\noticias_games\Pages\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </ol>\r\n        <div class=\"carousel-inner\">\r\n");
#nullable restore
#line 34 "C:\Users\Gm3\source\repos\3B-GB\noticias_games\Pages\Index.cshtml"
             foreach (Noticia item in Model.listaNoticias)
            {
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 36 "C:\Users\Gm3\source\repos\3B-GB\noticias_games\Pages\Index.cshtml"
                 if (index == 0)
                {
                    active = "active";
                }
                else
                {
                    active = "";
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div");
            BeginWriteAttribute("class", " class=\"", 1172, "\"", 1201, 2);
            WriteAttributeValue("", 1180, "carousel-item", 1180, 13, true);
#nullable restore
#line 45 "C:\Users\Gm3\source\repos\3B-GB\noticias_games\Pages\Index.cshtml"
WriteAttributeValue(" ", 1193, active, 1194, 7, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                    <img class=\"img-fluid w-70\"");
            BeginWriteAttribute("src", " src=", 1252, "", 1269, 1);
#nullable restore
#line 46 "C:\Users\Gm3\source\repos\3B-GB\noticias_games\Pages\Index.cshtml"
WriteAttributeValue("", 1257, item.imagem, 1257, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 1269, "\"", 1287, 2);
            WriteAttributeValue("", 1275, "slide", 1275, 5, true);
#nullable restore
#line 46 "C:\Users\Gm3\source\repos\3B-GB\noticias_games\Pages\Index.cshtml"
WriteAttributeValue(" ", 1280, index, 1281, 6, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                </div>\r\n");
#nullable restore
#line 48 "C:\Users\Gm3\source\repos\3B-GB\noticias_games\Pages\Index.cshtml"

                index++;
            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        </div>
        <a class=""carousel-control-prev"" href=""#carouselExampleIndicators"" role=""button"" data-slide=""prev"">
            <span class=""carousel-control-prev-icon"" aria-hidden=""true""></span>
            <span class=""sr-only"">Previous</span>
        </a>
        <a class=""carousel-control-next"" href=""#carouselExampleIndicators"" role=""button"" data-slide=""next"">
            <span class=""carousel-control-next-icon"" aria-hidden=""true""></span>
            <span class=""sr-only"">Next</span>
        </a>
    </div>


</div>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IndexModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<IndexModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<IndexModel>)PageContext?.ViewData;
        public IndexModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
