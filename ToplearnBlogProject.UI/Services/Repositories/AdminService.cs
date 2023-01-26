using ToplearnBlogProject.Shared.Dto;
using ToplearnBlogProject.Shared.Dto.Global;

namespace ToplearnBlogProject.UI.Services.Repositories
{
    public class AdminService : IAdminService
    {
        private readonly IHttpService _httpService;
        private const string baseUrl = "/api/admins";
        public AdminService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<ResponseDto<bool>> Create(AdminDto data)
        {
            return await _httpService.PostAsync<bool, AdminDto>($"{baseUrl}/create", data);
        }
        public async Task<ResponseDto<bool>> Update(AdminDto data)
        {
            return await _httpService.PostAsync<bool, AdminDto>($"{baseUrl}/update", data);
        }
        public async Task<ResponseDto<List<AdminDto>>> GetAll()
        {
            return await _httpService.GetAsync<List<AdminDto>>($"{baseUrl}/get-all");
        }
        public async Task<ResponseDto<bool>> Remove(int id)
        {
            return await _httpService.PostAsync<bool, int>($"{baseUrl}/remove", id);
        }
        public async Task<ResponseDto<AdminDto>> FindById(int id)
        {
            return await _httpService.PostAsync<AdminDto, int>($"{baseUrl}/find", id);
        }
    }
    public interface IAdminService
    {
        Task<ResponseDto<bool>> Create(AdminDto data);
        Task<ResponseDto<AdminDto>> FindById(int id);
        Task<ResponseDto<List<AdminDto>>> GetAll();
        Task<ResponseDto<bool>> Remove(int id);
        Task<ResponseDto<bool>> Update(AdminDto data);
    }
}
