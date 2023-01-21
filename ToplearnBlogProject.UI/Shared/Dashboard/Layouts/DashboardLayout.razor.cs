using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace ToplearnBlogProject.UI.Shared.Dashboard.Layouts
{
    public partial class DashboardLayout
    {
        [Inject]
        public IJSRuntime Js { get; set; }
        protected override Task OnAfterRenderAsync(bool firstRender)
        {
            Js.InvokeVoidAsync("LoadFunctionJs");
            return base.OnAfterRenderAsync(firstRender);
        }
    }
}
