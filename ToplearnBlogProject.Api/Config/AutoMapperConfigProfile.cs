using AutoMapper;
using ToplearnBlogProject.Domain.Entities;
using ToplearnBlogProject.Shared.Dto;

namespace ToplearnBlogProject.Api.Config
{
    public class AutoMapperConfigProfile:Profile
    {
        public AutoMapperConfigProfile()
        {
            CreateMap<RoleDto, Role>();
            CreateMap<Role, RoleDto>();
        }
    }
}
