using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToplearnBlogProject.Api.Helpers;
using ToplearnBlogProject.Api.Services;
using ToplearnBlogProject.Application.Services.Repositories;
using ToplearnBlogProject.Domain.Entities;
using ToplearnBlogProject.Shared.Dto;
using ToplearnBlogProject.Shared.Dto.Global;

namespace ToplearnBlogProject.Api.Controllers
{
    [Route("api/admins")]
    [ApiController]
    public class AdminApiController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAdminRepository _adminRepository;
        private readonly IUploadFileService _upload;
        public AdminApiController(IMapper mapper, IAdminRepository adminRepository, IUploadFileService upload)
        {
            _mapper = mapper;
            _upload = upload;
            _adminRepository = adminRepository;
        }
        [HttpPost("create")]
        public ResponseDto<bool> Create(AdminDto data)
        {
            Admin admin = _mapper.Map<AdminDto, Admin>(data);

            try
            {
                if (data.File != null)
                {
                    admin.Avatar = _upload.Save(data.File, nameof(Admin).ToLower());
                }
                admin.CreatedAt = DateTime.Now;
                admin.Password = HashPassword.Generate(admin.Password);
                var result = _adminRepository.Create(admin).Result;
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
        public ResponseDto<bool> Update(AdminDto data)
        {
            Admin admin = _mapper.Map<AdminDto, Admin>(data);
            if (!string.IsNullOrEmpty(admin.Password))
            {
                admin.Password = HashPassword.Generate(admin.Password);
            }
            try
            {
                var result = _adminRepository.Update(admin).Result;
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
        public ResponseDto<List<AdminDto>> GetAll()
        {
            try
            {
                var result = _adminRepository.GetAll().Result;
                List<AdminDto> admins = _mapper.Map<List<Admin>, List<AdminDto>>(result);
                return new ResponseDto<List<AdminDto>>(true, "اطلاعات با موفقیت دریافت شد", admins);
            }
            catch (Exception e)
            {

                return new ResponseDto<List<AdminDto>>(false, e.Message, null);
            }
        }
        [HttpPost("remove")]
        public ResponseDto<bool> Remove([FromBody] int id)
        {
            try
            {
                var result = _adminRepository.Remove(id).Result;
                return new ResponseDto<bool>(true, "موفقیت آمیز", result);
            }
            catch (Exception e)
            {
                return new ResponseDto<bool>(false, e.Message, false);
            }
        }

        [HttpPost("find")]
        public ResponseDto<AdminDto> Find([FromBody] int id)
        {
            try
            {
                var result = _adminRepository.FindById(id).Result;
                AdminDto admin = _mapper.Map<Admin, AdminDto>(result);
                return new ResponseDto<AdminDto>(true, "دریافت اطلاعات انجام شد", admin);
            }
            catch (Exception)
            {
                return new ResponseDto<AdminDto>(false, "خطا", null);
            }
        }
    }
}
