using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace ToplearnBlogProject.UI.Shared
{
    public partial class MainLayout
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
