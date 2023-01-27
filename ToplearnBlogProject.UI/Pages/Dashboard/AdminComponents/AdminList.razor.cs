using Microsoft.AspNetCore.Components;
using MudBlazor;
using ToplearnBlogProject.Shared.Dto;
using ToplearnBlogProject.UI.Services.Repositories;

namespace ToplearnBlogProject.UI.Pages.Dashboard.AdminComponents
{
    public partial class AdminList
    {
        [Inject]
        private IAdminService _repo { get; set; }

        [Inject]
        private ISnackbar _snackbar { get; set; }
        [Inject]
        private IDialogService _dialog { get; set; }
        [Inject]
        private NavigationManager _nav { get; set; }
        [Inject]
        private IConfiguration _config { get; set; }
        private List<AdminDto> Admins { get; set; }
        private bool showProgress;
        private string imageBaseUrl;
        protected override async Task OnInitializedAsync()
        {
            showProgress = true;
            await Task.Delay(200);
            imageBaseUrl = _config.GetValue<string>("ApiBaseUrl");
            var result = await _repo.GetAll();
            if (result.Status)
            {
                Admins = result.Data;
                _snackbar.Add(result.Message, Severity.Success);
            }
            else
            {
                Admins = new List<AdminDto>();
                _snackbar.Add(result.Message, Severity.Error);
            }
            await Task.Delay(200);
            showProgress = false;
        }

        public async Task ShowRemoveDialog(AdminDto item)
        {
            bool? result = await _dialog.ShowMessageBox(
            "اخطار",
            $"آیا از حذف مدیر {string.Concat(item.Name , " " , item.LastName)} اطمینان دارید ؟",
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
                Admins.RemoveAll(p => p.Id == id);
                //Admins.Remove();
            }
            else
            {
                _snackbar.Add(result.Message, Severity.Error);
            }
            await Task.Delay(200);
            showProgress = false;
        }
        public void NavigateToEdit(int id)
        {
            _nav.NavigateTo($"/dashboard/admins/edit/{id}");
        }
    }
}
