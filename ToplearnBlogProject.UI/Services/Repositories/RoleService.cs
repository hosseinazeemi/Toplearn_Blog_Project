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

        public async Task<ResponseDto<bool>> Create(RoleDto data)
        {
            return await _httpService.PostAsync<bool, RoleDto>($"{baseUrl}/create", data);
        }
    }
    public interface IRoleService
    {
        Task<ResponseDto<bool>> Create(RoleDto data);
    }
}
