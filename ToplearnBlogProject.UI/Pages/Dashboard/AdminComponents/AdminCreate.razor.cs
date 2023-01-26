using Microsoft.AspNetCore.Components;
using MudBlazor;
using ToplearnBlogProject.Shared.Dto;
using ToplearnBlogProject.UI.Services.Repositories;

namespace ToplearnBlogProject.UI.Pages.Dashboard.AdminComponents
{
    public partial class AdminCreate
    {
        [Inject]
        private IAdminService _repo { get; set; }

        [Inject]
        private ISnackbar _snackbar { get; set; }
        public AdminDto Admin { get; set; }
        private bool showProgress = false;
        public async Task Create()
        {
            showProgress = true;
            StateHasChanged();
            await Task.Delay(1200);
            var result = await _repo.Create(Admin);
            if (result.Status)
            {
                _snackbar.Add(result.Message, Severity.Success);
                Admin = new AdminDto();
            }
            else
            {
                _snackbar.Add(result.Message, Severity.Error);
            }
            showProgress = false;
        }
        protected override void OnInitialized()
        {
            Admin = new AdminDto();
        }
    }
}
