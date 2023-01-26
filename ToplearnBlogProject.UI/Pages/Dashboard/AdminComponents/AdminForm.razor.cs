using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using ToplearnBlogProject.Shared.Dto;
using ToplearnBlogProject.Shared.Dto.Global;
using ToplearnBlogProject.UI.Services.Repositories;

namespace ToplearnBlogProject.UI.Pages.Dashboard.AdminComponents
{
    public partial class AdminForm
    {
        [Parameter]
        public AdminDto Admin { get; set; }
        public List<RoleDto> Roles { get; set; }

        [Parameter]
        public EventCallback AdminCallback { get; set; }
        [Inject]
        private IRoleService _roleService { get; set; }

        public bool showProgress { get; set; }
        private EditContext editContext { get; set; }
        public async Task Submit()
        {
            if (editContext.Validate())
            {
                await AdminCallback.InvokeAsync();
            }
        }

        protected override async Task OnInitializedAsync()
        {
            showProgress = true;
            editContext = new EditContext(Admin);
            StateHasChanged();
            var response = await _roleService.GetAll();

            if (response.Status)
            {
                Roles = response.Data;
            }else
            {
                Roles = new List<RoleDto>();
            }
            showProgress = false;
        }

        public async Task OnSelectedFile(FileDto file)
        {
            Admin.File = file;
        }
    }
}
