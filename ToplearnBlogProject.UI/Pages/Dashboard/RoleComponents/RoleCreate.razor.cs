using ToplearnBlogProject.Shared.Dto;

namespace ToplearnBlogProject.UI.Pages.Dashboard.RoleComponents
{
    public partial class RoleCreate
    {
        public RoleDto Role { get; set; }
        public async Task Create()
        {
            //.. 
        }
        protected override void OnInitialized()
        {
            Role = new RoleDto();
        }
    }
}
