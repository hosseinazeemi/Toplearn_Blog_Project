using Microsoft.AspNetCore.Components;
using MudBlazor;
using ToplearnBlogProject.Shared.Dto;
using ToplearnBlogProject.UI.Services.Repositories;

namespace ToplearnBlogProject.UI.Pages.Dashboard.RoleComponents
{
    public partial class RoleCreate
    {
        [Inject]
        private IRoleService _repo { get; set; }

        [Inject]
        private ISnackbar _snackbar { get; set; }
        public RoleDto Role { get; set; }
        private bool showProgress = false;
        public async Task Create()
        {
            showProgress = true;
            StateHasChanged();
            var result = await _repo.Create(Role);
            if (result.Status)
            {
                _snackbar.Add(result.Message, Severity.Success);
                Role = new RoleDto();
            }
            else
            {
                _snackbar.Add(result.Message, Severity.Error);
            }
            showProgress = false;
        }
        protected override void OnInitialized()
        {
            Role = new RoleDto();
        }
    }
}
