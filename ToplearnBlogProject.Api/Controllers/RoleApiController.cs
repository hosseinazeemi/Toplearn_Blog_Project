using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToplearnBlogProject.Application.Services.Repositories;
using ToplearnBlogProject.Domain.Entities;
using ToplearnBlogProject.Shared.Dto;
using ToplearnBlogProject.Shared.Dto.Global;

namespace ToplearnBlogProject.Api.Controllers
{
    [Route("api/roles")]
    [ApiController]
    public class RoleApiController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IRoleRepository _roleRepository;
        public RoleApiController(IMapper mapper, IRoleRepository roleRepository)
        {
            _mapper = mapper;
            _roleRepository = roleRepository;
        }
        [HttpPost("create")]
        public ResponseDto<bool> Create(RoleDto data)
        {
            Role role = _mapper.Map<RoleDto, Role>(data);

            try
            {
                var result = _roleRepository.Create(role).Result;
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
        [HttpGet("get-all")]
        public ResponseDto<List<RoleDto>> GetAll()
        {
            try
            {
                var result = _roleRepository.GetAll().Result;
                List<RoleDto> roles = _mapper.Map<List<Role>, List<RoleDto>>(result);
                return new ResponseDto<List<RoleDto>>(true , "اطلاعات با موفقیت دریافت شد" , roles);
            }
            catch (Exception e)
            {

                return new ResponseDto<List<RoleDto>>(false, e.Message, null);
            }
        }
    }
}
