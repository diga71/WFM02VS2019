#pragma checksum "C:\Users\lfrigenti\source\repos\WFM02VS2019\Scheduler\ServerSideWebApp\Pages\BlazorGrid.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "828fef8ec3c505b32a0bad469b01e3efbe7ce6e7"
// <auto-generated/>
#pragma warning disable 1591
namespace ServerSideWebApp.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\lfrigenti\source\repos\WFM02VS2019\Scheduler\ServerSideWebApp\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\lfrigenti\source\repos\WFM02VS2019\Scheduler\ServerSideWebApp\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\lfrigenti\source\repos\WFM02VS2019\Scheduler\ServerSideWebApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\lfrigenti\source\repos\WFM02VS2019\Scheduler\ServerSideWebApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\lfrigenti\source\repos\WFM02VS2019\Scheduler\ServerSideWebApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\lfrigenti\source\repos\WFM02VS2019\Scheduler\ServerSideWebApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\lfrigenti\source\repos\WFM02VS2019\Scheduler\ServerSideWebApp\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\lfrigenti\source\repos\WFM02VS2019\Scheduler\ServerSideWebApp\_Imports.razor"
using ServerSideWebApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\lfrigenti\source\repos\WFM02VS2019\Scheduler\ServerSideWebApp\_Imports.razor"
using ServerSideWebApp.Shared;

#line default
#line hidden
#nullable disable
    public class BlazorGrid<T> : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "table");
            __builder.AddMarkupContent(1, "\r\n    ");
            __builder.OpenElement(2, "thead");
            __builder.AddMarkupContent(3, "\r\n        ");
            __builder.OpenElement(4, "tr");
            __builder.AddAttribute(5, "class", "jsgrid-grid-header");
            __builder.AddContent(6, 
#nullable restore
#line 5 "C:\Users\lfrigenti\source\repos\WFM02VS2019\Scheduler\ServerSideWebApp\Pages\BlazorGrid.razor"
                                        GridHeader

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(7, "\r\n    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(8, "\r\n    ");
            __builder.OpenElement(9, "tbody");
            __builder.AddMarkupContent(10, "\r\n");
#nullable restore
#line 8 "C:\Users\lfrigenti\source\repos\WFM02VS2019\Scheduler\ServerSideWebApp\Pages\BlazorGrid.razor"
         foreach (var item in ItemList)
        {

#line default
#line hidden
#nullable disable
            __builder.AddContent(11, "            ");
            __builder.OpenElement(12, "tr");
            __builder.AddAttribute(13, "class", "jsgrid-row-item");
            __builder.AddContent(14, 
#nullable restore
#line 10 "C:\Users\lfrigenti\source\repos\WFM02VS2019\Scheduler\ServerSideWebApp\Pages\BlazorGrid.razor"
                                         GridRow(item)

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(15, "\r\n");
#nullable restore
#line 11 "C:\Users\lfrigenti\source\repos\WFM02VS2019\Scheduler\ServerSideWebApp\Pages\BlazorGrid.razor"
        }

#line default
#line hidden
#nullable disable
            __builder.AddContent(16, "    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(17, "\r\n");
            __builder.CloseElement();
            __builder.AddMarkupContent(18, "\r\n");
            __builder.OpenElement(19, "div");
            __builder.AddAttribute(20, "class", "pagination");
            __builder.AddMarkupContent(21, "\r\n\r\n    ");
            __builder.OpenElement(22, "button");
            __builder.AddAttribute(23, "class", "btn pagebutton btn-info");
            __builder.AddAttribute(24, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 16 "C:\Users\lfrigenti\source\repos\WFM02VS2019\Scheduler\ServerSideWebApp\Pages\BlazorGrid.razor"
                                                      (() => SetPagerSize("back"))

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(25, "«");
            __builder.CloseElement();
            __builder.AddMarkupContent(26, "\r\n    ");
            __builder.OpenElement(27, "button");
            __builder.AddAttribute(28, "class", "btn pagebutton btn-secondary");
            __builder.AddAttribute(29, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 17 "C:\Users\lfrigenti\source\repos\WFM02VS2019\Scheduler\ServerSideWebApp\Pages\BlazorGrid.razor"
                                                           (() => NavigateToPage("previous"))

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(30, "Prev");
            __builder.CloseElement();
            __builder.AddMarkupContent(31, "\r\n\r\n");
#nullable restore
#line 19 "C:\Users\lfrigenti\source\repos\WFM02VS2019\Scheduler\ServerSideWebApp\Pages\BlazorGrid.razor"
     for (int i = startPage; i <= endPage; i++)
    {
        var currentPage = i;

#line default
#line hidden
#nullable disable
            __builder.AddContent(32, "        ");
            __builder.OpenElement(33, "button");
            __builder.AddAttribute(34, "class", "btn" + " pagebutton" + " " + (
#nullable restore
#line 22 "C:\Users\lfrigenti\source\repos\WFM02VS2019\Scheduler\ServerSideWebApp\Pages\BlazorGrid.razor"
                                        currentPage==curPage?"currentpage":""

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(35, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 22 "C:\Users\lfrigenti\source\repos\WFM02VS2019\Scheduler\ServerSideWebApp\Pages\BlazorGrid.razor"
                                                                                          (async () => UpdateList(currentPage))

#line default
#line hidden
#nullable disable
            ));
            __builder.AddMarkupContent(36, "\r\n            ");
            __builder.AddContent(37, 
#nullable restore
#line 23 "C:\Users\lfrigenti\source\repos\WFM02VS2019\Scheduler\ServerSideWebApp\Pages\BlazorGrid.razor"
             currentPage

#line default
#line hidden
#nullable disable
            );
            __builder.AddMarkupContent(38, "\r\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(39, "\r\n");
#nullable restore
#line 25 "C:\Users\lfrigenti\source\repos\WFM02VS2019\Scheduler\ServerSideWebApp\Pages\BlazorGrid.razor"
    }

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(40, "\r\n    ");
            __builder.OpenElement(41, "button");
            __builder.AddAttribute(42, "class", "btn pagebutton btn-secondary");
            __builder.AddAttribute(43, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 27 "C:\Users\lfrigenti\source\repos\WFM02VS2019\Scheduler\ServerSideWebApp\Pages\BlazorGrid.razor"
                                                           (() => NavigateToPage("next"))

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(44, "Next");
            __builder.CloseElement();
            __builder.AddMarkupContent(45, "\r\n    ");
            __builder.OpenElement(46, "button");
            __builder.AddAttribute(47, "class", "btn pagebutton btn-info");
            __builder.AddAttribute(48, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 28 "C:\Users\lfrigenti\source\repos\WFM02VS2019\Scheduler\ServerSideWebApp\Pages\BlazorGrid.razor"
                                                      (() => SetPagerSize("forward"))

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(49, "»");
            __builder.CloseElement();
            __builder.AddMarkupContent(50, "\r\n\r\n    ");
            __builder.OpenElement(51, "span");
            __builder.AddAttribute(52, "class", "pagebutton btn btn-link disabled");
            __builder.AddContent(53, "Page ");
            __builder.AddContent(54, 
#nullable restore
#line 30 "C:\Users\lfrigenti\source\repos\WFM02VS2019\Scheduler\ServerSideWebApp\Pages\BlazorGrid.razor"
                                                         curPage

#line default
#line hidden
#nullable disable
            );
            __builder.AddContent(55, " of ");
            __builder.AddContent(56, 
#nullable restore
#line 30 "C:\Users\lfrigenti\source\repos\WFM02VS2019\Scheduler\ServerSideWebApp\Pages\BlazorGrid.razor"
                                                                     totalPages

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(57, "\r\n\r\n");
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 34 "C:\Users\lfrigenti\source\repos\WFM02VS2019\Scheduler\ServerSideWebApp\Pages\BlazorGrid.razor"
       

    int totalPages;
    int curPage;
    int pagerSize;
    int startPage;
    int endPage;

    [Parameter]
    public RenderFragment GridHeader { get; set; }
    [Parameter]
    public RenderFragment<T> GridRow { get; set; }
    [Parameter]
    public IEnumerable<T> Items { get; set; }
    [Parameter]
    public int PageSize { get; set; }

    IEnumerable<T> ItemList { get; set; }

    protected override async Task OnInitializedAsync()
    {
        pagerSize = 3;
        curPage = 1;

        ItemList = Items.Skip((curPage - 1) * PageSize).Take(PageSize);
        totalPages = (int)Math.Ceiling(Items.Count() / (decimal)PageSize);

        SetPagerSize("forward");
    }

    public void UpdateList(int currentPage)
    {
        ItemList = Items.Skip((currentPage - 1) * PageSize).Take(PageSize);
        curPage = currentPage;
        this.StateHasChanged();
    }

    public void SetPagerSize(string direction)
    {
        if (direction == "forward" && endPage < totalPages)
        {
            startPage = endPage + 1;
            if (endPage + pagerSize < totalPages)
            {
                endPage = startPage + pagerSize - 1;
            }
            else
            {
                endPage = totalPages;
            }
            this.StateHasChanged();
        }
        else if (direction == "back" && startPage > 1)
        {
            endPage = startPage - 1;
            startPage = startPage - pagerSize;
        }
    }

    public void NavigateToPage(string direction)
    {
        if (direction == "next")
        {
            if (curPage < totalPages)
            {
                if (curPage == endPage)
                {
                    SetPagerSize("forward");
                }
                curPage += 1;
            }
        }
        else if (direction == "previous")
        {
            if (curPage > 1)
            {
                if (curPage == startPage)
                {
                    SetPagerSize("back");
                }
                curPage -= 1;
            }
        }
        UpdateList(curPage);
    }

#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591