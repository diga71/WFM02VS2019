#pragma checksum "C:\Users\lfrigenti\source\repos\WFM02VS2019\Scheduler\ServerSideWebApp\Pages\BlazorGrid.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ae94901c4e23e7583c408dfeb7b8e64f47b56da4"
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
#nullable restore
#line 1 "C:\Users\lfrigenti\source\repos\WFM02VS2019\Scheduler\ServerSideWebApp\Pages\BlazorGrid.razor"
using Domain.UnitOfWork;

#line default
#line hidden
#nullable disable
    public class BlazorGrid<T> : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "table");
            __builder.AddAttribute(1, "class", "table");
            __builder.AddMarkupContent(2, "\r\n        ");
            __builder.OpenElement(3, "thead");
            __builder.AddMarkupContent(4, "\r\n            ");
            __builder.OpenElement(5, "tr");
            __builder.AddAttribute(6, "class", "jsgrid-grid-header");
            __builder.AddContent(7, 
#nullable restore
#line 6 "C:\Users\lfrigenti\source\repos\WFM02VS2019\Scheduler\ServerSideWebApp\Pages\BlazorGrid.razor"
                                            GridHeader

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(8, "\r\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(9, "\r\n        ");
            __builder.OpenElement(10, "tbody");
            __builder.AddMarkupContent(11, "\r\n");
#nullable restore
#line 9 "C:\Users\lfrigenti\source\repos\WFM02VS2019\Scheduler\ServerSideWebApp\Pages\BlazorGrid.razor"
             foreach (var item in ItemList)
            {

#line default
#line hidden
#nullable disable
            __builder.AddContent(12, "                ");
            __builder.OpenElement(13, "tr");
            __builder.AddAttribute(14, "class", "jsgrid-row-item");
            __builder.AddAttribute(15, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 11 "C:\Users\lfrigenti\source\repos\WFM02VS2019\Scheduler\ServerSideWebApp\Pages\BlazorGrid.razor"
                                                        () => OnClickTR.InvokeAsync(GetId(item))

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(16, 
#nullable restore
#line 11 "C:\Users\lfrigenti\source\repos\WFM02VS2019\Scheduler\ServerSideWebApp\Pages\BlazorGrid.razor"
                                                                                                    GridRow(item)

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(17, "\r\n");
#nullable restore
#line 12 "C:\Users\lfrigenti\source\repos\WFM02VS2019\Scheduler\ServerSideWebApp\Pages\BlazorGrid.razor"
            }

#line default
#line hidden
#nullable disable
            __builder.AddContent(18, "        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(19, "\r\n    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(20, "\r\n    ");
            __builder.OpenElement(21, "div");
            __builder.AddMarkupContent(22, "\r\n        ");
            __builder.OpenElement(23, "button");
            __builder.AddAttribute(24, "class", "btn btn-outline-primary float-left");
            __builder.AddAttribute(25, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 16 "C:\Users\lfrigenti\source\repos\WFM02VS2019\Scheduler\ServerSideWebApp\Pages\BlazorGrid.razor"
                                                                     NewItem

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(26, "Add");
            __builder.CloseElement();
            __builder.AddMarkupContent(27, "\r\n\r\n        ");
            __builder.OpenElement(28, "span");
            __builder.AddAttribute(29, "class", "pagebutton btn btn-link disabled float-right");
            __builder.AddContent(30, "Page ");
            __builder.AddContent(31, 
#nullable restore
#line 18 "C:\Users\lfrigenti\source\repos\WFM02VS2019\Scheduler\ServerSideWebApp\Pages\BlazorGrid.razor"
                                                                         curPage

#line default
#line hidden
#nullable disable
            );
            __builder.AddContent(32, " of ");
            __builder.AddContent(33, 
#nullable restore
#line 18 "C:\Users\lfrigenti\source\repos\WFM02VS2019\Scheduler\ServerSideWebApp\Pages\BlazorGrid.razor"
                                                                                     totalPages

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(34, "\r\n        ");
            __builder.OpenElement(35, "button");
            __builder.AddAttribute(36, "class", "btn pagebutton btn-info float-right");
            __builder.AddAttribute(37, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 20 "C:\Users\lfrigenti\source\repos\WFM02VS2019\Scheduler\ServerSideWebApp\Pages\BlazorGrid.razor"
                                                                      (() => SetPagerSize("forward"))

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(38, "»");
            __builder.CloseElement();
            __builder.AddMarkupContent(39, "\r\n        ");
            __builder.OpenElement(40, "button");
            __builder.AddAttribute(41, "class", "btn pagebutton btn-secondary float-right");
            __builder.AddAttribute(42, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 21 "C:\Users\lfrigenti\source\repos\WFM02VS2019\Scheduler\ServerSideWebApp\Pages\BlazorGrid.razor"
                                                                           (() => NavigateToPage("next"))

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(43, "Next");
            __builder.CloseElement();
            __builder.AddMarkupContent(44, "\r\n\r\n\r\n");
#nullable restore
#line 24 "C:\Users\lfrigenti\source\repos\WFM02VS2019\Scheduler\ServerSideWebApp\Pages\BlazorGrid.razor"
         for (int i = endPage; i >= startPage; i--)
        {
            var currentPage = i;

#line default
#line hidden
#nullable disable
            __builder.AddContent(45, "            ");
            __builder.OpenElement(46, "button");
            __builder.AddAttribute(47, "class", "btn" + " pagebutton" + "  float-right" + " " + (
#nullable restore
#line 27 "C:\Users\lfrigenti\source\repos\WFM02VS2019\Scheduler\ServerSideWebApp\Pages\BlazorGrid.razor"
                                                         currentPage==curPage?"currentpage":""

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(48, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 27 "C:\Users\lfrigenti\source\repos\WFM02VS2019\Scheduler\ServerSideWebApp\Pages\BlazorGrid.razor"
                                                                                                           (async () => UpdateList(currentPage))

#line default
#line hidden
#nullable disable
            ));
            __builder.AddMarkupContent(49, "\r\n                ");
            __builder.AddContent(50, 
#nullable restore
#line 28 "C:\Users\lfrigenti\source\repos\WFM02VS2019\Scheduler\ServerSideWebApp\Pages\BlazorGrid.razor"
                 currentPage

#line default
#line hidden
#nullable disable
            );
            __builder.AddMarkupContent(51, "\r\n            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(52, "\r\n");
#nullable restore
#line 30 "C:\Users\lfrigenti\source\repos\WFM02VS2019\Scheduler\ServerSideWebApp\Pages\BlazorGrid.razor"
        }

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(53, "      \r\n\r\n        ");
            __builder.OpenElement(54, "button");
            __builder.AddAttribute(55, "class", "btn pagebutton btn-secondary float-right");
            __builder.AddAttribute(56, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 33 "C:\Users\lfrigenti\source\repos\WFM02VS2019\Scheduler\ServerSideWebApp\Pages\BlazorGrid.razor"
                                                                           (() => NavigateToPage("previous"))

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(57, "Prev");
            __builder.CloseElement();
            __builder.AddMarkupContent(58, "\r\n        \r\n\r\n\r\n    ");
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 40 "C:\Users\lfrigenti\source\repos\WFM02VS2019\Scheduler\ServerSideWebApp\Pages\BlazorGrid.razor"
           

            int totalPages;
            int curPage;
            int pagerSize;
            int startPage;
            int endPage;

        [Parameter]
        public EventCallback<string> OnClickTR { get; set; }
        [Parameter]
        public EventCallback NewItem { get; set; }
        [Parameter]
        public RenderFragment GridHeader { get; set; }
        [Parameter]
        public RenderFragment<T>  GridRow { get; set; }
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
            if (direction == "forward" && endPage <= totalPages)
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
            }
            else if (direction == "back" && startPage > 1)
            {
                endPage = startPage - 1;
                startPage = startPage - pagerSize;
                UpdateList(endPage);
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


        public string GetId(T obj)
        {
            IIdentity identity = obj as IIdentity;
            return identity.Id.ToString();
        }
    

#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
