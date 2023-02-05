using Microsoft.AspNetCore.Components;
using ToplearnBlogProject.Shared.Dto;

namespace ToplearnBlogProject.UI.Pages.Dashboard.TagComponents
{
    public partial class TagForm
    {
        [Parameter]
        public TagDto Tag{ get; set; }

        [Parameter]
        public EventCallback TagCallback { get; set; }
        public async Task Submit()
        {
            await TagCallback.InvokeAsync();
        }
    }
}
