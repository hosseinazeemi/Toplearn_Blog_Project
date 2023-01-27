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
        [Inject]
        private IConfiguration _config { get; set; }

        public bool showProgress { get; set; }
        private string baseImageUrl { get; set; }
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
            baseImageUrl = _config.GetValue<string>("ApiBaseUrl");
            editContext = new EditContext(Admin);
            StateHasChanged();
            var response = await _roleService.GetAll();

            if (response.Status)
            {
                Roles = response.Data;
            }
            else
            {
                Roles = new List<RoleDto>();
            }
            showProgress = false;
        }

        public void OnSelectedFile(FileDto file)
        {
            Admin.File = file;
        }
        public void OnChangeRole(ChangeEventArgs args)
        {
            if (args.Value != null)
            {
                int val = Convert.ToInt32(args.Value);
                Admin.Role = Roles.FirstOrDefault(p => p.Id == val);
                Admin.RoleId = val;
            }
        }
    }
}
