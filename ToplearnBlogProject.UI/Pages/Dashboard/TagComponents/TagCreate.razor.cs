using Microsoft.AspNetCore.Components;
using MudBlazor;
using ToplearnBlogProject.Shared.Dto;
using ToplearnBlogProject.UI.Services.Repositories;

namespace ToplearnBlogProject.UI.Pages.Dashboard.TagComponents
{
    public partial class TagCreate
    {
        [Inject]
        private ITagService _repo { get; set; }

        [Inject]
        private ISnackbar _snackbar { get; set; }
        public TagDto Tag { get; set; }
        private bool showProgress = false;
        public async Task Create()
        {
            showProgress = true;
            StateHasChanged();
            await Task.Delay(1200);
            var result = await _repo.Create(Tag);
            if (result.Status)
            {
                _snackbar.Add(result.Message, Severity.Success);
                Tag = new TagDto();
            }
            else
            {
                _snackbar.Add(result.Message, Severity.Error);
            }
            showProgress = false;
        }
        protected override void OnInitialized()
        {
            Tag = new TagDto();
        }
    }
}
