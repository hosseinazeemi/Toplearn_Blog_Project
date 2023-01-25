using Microsoft.AspNetCore.Components;
using MudBlazor;
using ToplearnBlogProject.Shared.Dto;
using ToplearnBlogProject.UI.Services.Repositories;

namespace ToplearnBlogProject.UI.Pages.Dashboard.RoleComponents
{
    public partial class RoleList
    {
        [Inject]
        private IRoleService _repo { get; set; }

        [Inject]
        private ISnackbar _snackbar { get; set; }
        private List<RoleDto> Roles { get; set; }
        private bool showProgress;
        protected override async Task OnInitializedAsync()
        {
            showProgress = true;
            await Task.Delay(200);
            var result = await _repo.GetAll();
            if (result.Status)
            {
                Roles = result.Data;
                _snackbar.Add(result.Message, Severity.Success);
            }
            else
            {
                Roles = new List<RoleDto>();
                _snackbar.Add(result.Message, Severity.Error);
            }
            await Task.Delay(200);
            showProgress = false;
        }
    }
}
