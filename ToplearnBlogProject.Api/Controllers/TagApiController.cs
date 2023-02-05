using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToplearnBlogProject.Application.Services.Repositories;
using ToplearnBlogProject.Domain.Entities;
using ToplearnBlogProject.Shared.Dto;
using ToplearnBlogProject.Shared.Dto.Global;

namespace ToplearnBlogProject.Api.Controllers
{
    [Route("api/tags")]
    [ApiController]
    public class TagApiController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ITagRepository _tagRepository;
        public TagApiController(IMapper mapper, ITagRepository tagRepository)
        {
            _mapper = mapper;
            _tagRepository = tagRepository;
        }
        [HttpPost("create")]
        public ResponseDto<bool> Create(TagDto data)
        {
            Tag role = _mapper.Map<TagDto, Tag>(data);

            try
            {
                var result = _tagRepository.Create(role).Result;
                if (result > 0)
                {
                    return new ResponseDto<bool>(true, "موفقیت آمیز", true);
                }
                return new ResponseDto<bool>(false, "سیستم با خطا مواجه شد", false);
            }
            catch (Exception e)
            {
                return new ResponseDto<bool>(false, e.Message, false);
            }
        }

        [HttpPost("update")]
        public ResponseDto<bool> Update(TagDto data)
        {
            Tag role = _mapper.Map<TagDto, Tag>(data);

            try
            {
                var result = _tagRepository.Update(role).Result;
                if (result)
                {
                    return new ResponseDto<bool>(true, "موفقیت آمیز", true);
                }
                return new ResponseDto<bool>(false, "سیستم با خطا مواجه شد", false);
            }
            catch (Exception e)
            {
                return new ResponseDto<bool>(false, e.Message, false);
            }
        }

        [HttpGet("get-all")]
        public ResponseDto<List<TagDto>> GetAll()
        {
            try
            {
                var result = _tagRepository.GetAll().Result;
                List<TagDto> roles = _mapper.Map<List<Tag>, List<TagDto>>(result);
                return new ResponseDto<List<TagDto>>(true, "اطلاعات با موفقیت دریافت شد", roles);
            }
            catch (Exception e)
            {

                return new ResponseDto<List<TagDto>>(false, e.Message, null);
            }
        }
        [HttpPost("remove")]
        public ResponseDto<bool> Remove([FromBody] int id)
        {
            try
            {
                var result = _tagRepository.Remove(id).Result;
                return new ResponseDto<bool>(true, "موفقیت آمیز", result);
            }
            catch (Exception e)
            {
                return new ResponseDto<bool>(false, e.Message, false);
            }
        }

        [HttpPost("find")]
        public ResponseDto<TagDto> Find([FromBody] int id)
        {
            try
            {
                var result = _tagRepository.FindById(id).Result;
                TagDto role = _mapper.Map<Tag, TagDto>(result);
                return new ResponseDto<TagDto>(true, "دریافت اطلاعات انجام شد", role);
            }
            catch (Exception)
            {
                return new ResponseDto<TagDto>(false, "خطا", null);
            }
        }
    }
}
