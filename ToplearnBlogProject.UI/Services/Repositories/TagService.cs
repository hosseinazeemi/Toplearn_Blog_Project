using ToplearnBlogProject.Shared.Dto;
using ToplearnBlogProject.Shared.Dto.Global;

namespace ToplearnBlogProject.UI.Services.Repositories
{
    public class TagService : ITagService
    {
        private readonly IHttpService _httpService;
        private const string baseUrl = "/api/tags";
        public TagService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<ResponseDto<bool>> Create(TagDto data)
        {
            return await _httpService.PostAsync<bool, TagDto>($"{baseUrl}/create", data);
        }
        public async Task<ResponseDto<bool>> Update(TagDto data)
        {
            return await _httpService.PostAsync<bool, TagDto>($"{baseUrl}/update", data);
        }
        public async Task<ResponseDto<List<TagDto>>> GetAll()
        {
            return await _httpService.GetAsync<List<TagDto>>($"{baseUrl}/get-all");
        }
        public async Task<ResponseDto<bool>> Remove(int id)
        {
            return await _httpService.PostAsync<bool, int>($"{baseUrl}/remove", id);
        }
        public async Task<ResponseDto<TagDto>> FindById(int id)
        {
            return await _httpService.PostAsync<TagDto, int>($"{baseUrl}/find", id);
        }
    }
    public interface ITagService
    {
        Task<ResponseDto<bool>> Create(TagDto data);
        Task<ResponseDto<TagDto>> FindById(int id);
        Task<ResponseDto<List<TagDto>>> GetAll();
        Task<ResponseDto<bool>> Remove(int id);
        Task<ResponseDto<bool>> Update(TagDto data);
    }
}
