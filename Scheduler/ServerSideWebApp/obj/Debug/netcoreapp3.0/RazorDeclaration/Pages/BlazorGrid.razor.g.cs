#pragma checksum "C:\Users\lfrigenti\source\repos\WFM02VS2019\Scheduler\ServerSideWebApp\Pages\BlazorGrid.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "828fef8ec3c505b32a0bad469b01e3efbe7ce6e7"
// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

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