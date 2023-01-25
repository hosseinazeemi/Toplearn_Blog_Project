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
        [Inject] 
        private IDialogService _dialog { get; set; }
        [Inject]
        private NavigationManager _nav { get; set; }
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

        public async Task ShowRemoveDialog(RoleDto item)
        {
            bool? result = await _dialog.ShowMessageBox(
            "اخطار",
            $"آیا از حذف نقش {item.FaName} اطمینان دارید ؟",
            yesText: "بله !", cancelText: "خیر");

            if (result == true)
            {
                await Remove(item.Id);
            }
        }
        public async Task Remove(int id)
        {
            showProgress = true;
            await Task.Delay(200);
            var result = await _repo.Remove(id);
            if (result.Status)
            {
                _snackbar.Add(result.Message, Severity.Success);
                Roles.RemoveAll(p => p.Id == id);
                //Roles.Remove();
            }else
            {
                _snackbar.Add(result.Message, Severity.Error);
            }
            await Task.Delay(200);
            showProgress = false;
        }
        public void NavigateToEdit(int id)
        {
            _nav.NavigateTo($"/dashboard/roles/edit/{id}");
        }
    }
}
