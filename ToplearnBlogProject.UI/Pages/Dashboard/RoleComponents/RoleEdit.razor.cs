using Microsoft.AspNetCore.Components;
using MudBlazor;
using ToplearnBlogProject.Shared.Dto;
using ToplearnBlogProject.UI.Services.Repositories;

namespace ToplearnBlogProject.UI.Pages.Dashboard.RoleComponents
{
    public partial class RoleEdit
    {
        [Inject]
        private IRoleService _repo { get; set; }

        [Inject]
        private ISnackbar _snackbar { get; set; }
        [Inject]
        private NavigationManager _nav { get; set; }
        [Parameter]
        public int Id { get; set; }
        public RoleDto Role { get; set; }
        private bool showProgress = false;
        public async Task Update()
        {
            showProgress = true;
            await Task.Delay(500);
            var result = await _repo.Update(Role);
            
            if (result.Status)
            {
                _snackbar.Add(result.Message, Severity.Success);
                _nav.NavigateTo("/dashboard/roles/list");
            }
            else
            {
                _snackbar.Add(result.Message, Severity.Error);
            }
            await Task.Delay(300);
            showProgress = false;
        }
        protected override async Task OnInitializedAsync()
        {
            showProgress = true;
            await Task.Delay(500);
            var response = await _repo.FindById(Id);
            if (response.Status)
            {
                Role = response.Data;
                _snackbar.Add(response.Message, Severity.Success);
            }
            else
            {
                Role = new RoleDto();
                _snackbar.Add(response.Message, Severity.Error);
            }
            
            await Task.Delay(300);
            showProgress = false;
        }
    }
}
