using Microsoft.AspNetCore.Components;
using ToplearnBlogProject.Shared.Dto;

namespace ToplearnBlogProject.UI.Pages.Dashboard.RoleComponents
{
    public partial class RoleForm
    {
        [Parameter]
        public RoleDto Role { get; set; }

        [Parameter]
        public EventCallback RoleCallback { get; set; }
        public async Task Submit()
        {
            await RoleCallback.InvokeAsync();
        }
    }
}
