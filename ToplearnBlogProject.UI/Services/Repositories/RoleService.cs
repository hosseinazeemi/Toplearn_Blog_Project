using ToplearnBlogProject.Shared.Dto;
using ToplearnBlogProject.Shared.Dto.Global;

namespace ToplearnBlogProject.UI.Services.Repositories
{
    public class RoleService:IRoleService
    {
        private readonly IHttpService _httpService;
        private const string baseUrl = "/api/roles";
        public RoleService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public ResponseDto<bool> Create(RoleDto data)
        {
            return _httpService.PostAsync<bool, RoleDto>($"{baseUrl}/create", data).Result;
        }
    }
    public interface IRoleService
    {
        ResponseDto<bool> Create(RoleDto data);
    }
}
