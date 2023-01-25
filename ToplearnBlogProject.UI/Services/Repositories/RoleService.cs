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
        public async Task<ResponseDto<bool>> Update(RoleDto data)
        {
            return await _httpService.PostAsync<bool, RoleDto>($"{baseUrl}/update", data);
        }
        public async Task<ResponseDto<List<RoleDto>>> GetAll()
        {
            return await _httpService.GetAsync<List<RoleDto>>($"{baseUrl}/get-all");
        }
        public async Task<ResponseDto<bool>> Remove(int id)
        {
            return await _httpService.PostAsync<bool, int>($"{baseUrl}/remove" , id);
        }
        public async Task<ResponseDto<RoleDto>> FindById(int id)
        {
            return await _httpService.PostAsync<RoleDto, int>($"{baseUrl}/find" , id);
        }
    }
    public interface IRoleService
    {
        Task<ResponseDto<bool>> Create(RoleDto data);
        Task<ResponseDto<RoleDto>> FindById(int id);
        Task<ResponseDto<List<RoleDto>>> GetAll();
        Task<ResponseDto<bool>> Remove(int id);
        Task<ResponseDto<bool>> Update(RoleDto data);
    }
}
