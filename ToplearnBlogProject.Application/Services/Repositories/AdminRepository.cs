using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToplearnBlogProject.Domain.Entities;

namespace ToplearnBlogProject.Application.Services.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        private readonly IAppDbContext _dbContext;
        public AdminRepository(IAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Create(Admin model)
        {
            _dbContext.Admins.Add(model);

            try
            {
                await _dbContext.SaveChangesAsync();
                return model.Id;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
        public async Task<List<Admin>> GetAll()
        {
            var data = _dbContext.Admins.Include(p => p.Role)
                .Select(p => new Admin
                {
                    Role = p.Role,
                    BlogCount = p.BlogCount,
                    Id = p.Id,
                    Name = p.Name,
                    LastName = p.LastName,
                    Email = p.Email,
                    IsActive = p.IsActive,
                    Phone = p.Phone,
                    CreatedAt = p.CreatedAt,
                    RoleId = p.RoleId,
                    Avatar = p.Avatar != null ? string.Concat(nameof(Admin).ToLower(), "/", p.Avatar) : null
                }).ToList();

            return data;
            //return _dbContext.Admins.Include(p => p.Role).ToList();
        }

        public async Task<string> Remove(int id)
        {
            var admin = _dbContext.Admins.FirstOrDefault(p => p.Id == id);
            if (admin != null)
            {
                var avatar = admin.Avatar;
                _dbContext.Admins.Remove(admin);

                try
                {
                    await _dbContext.SaveChangesAsync();
                    return avatar;
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
            throw new Exception("Admin Not Found");
        }
        public async Task<Admin> FindById(int id)
        {
            //return await Task.FromResult(_dbContext.Admins.FirstOrDefault(p => p.Id == id));

            var result = _dbContext.Admins
                .Where(p => p.Id == id)
                .Include(p => p.Role)
                .Select(p => new Admin
                {
                    Role = p.Role,
                    BlogCount = p.BlogCount,
                    Id = p.Id,
                    Name = p.Name,
                    LastName = p.LastName,
                    Email = p.Email,
                    IsActive = p.IsActive,
                    Phone = p.Phone,
                    CreatedAt = p.CreatedAt,
                    RoleId = p.RoleId,
                    Avatar = p.Avatar != null ? string.Concat(nameof(Admin).ToLower(), "/", p.Avatar) : null
                })
                .FirstOrDefault();

            if (result != null)
            {
                return await Task.FromResult(result);
            }
            throw new Exception("Admin Not Found");
        }
        public async Task<bool> Update(Admin data)
        {
            //var admin = await _dbContext.Admins.FirstOrDefaultAsync(p => p.Id == data.Id);
            _dbContext.Admins.Update(data);

            try
            {
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }

    public interface IAdminRepository
    {
        Task<int> Create(Admin model);
        Task<Admin> FindById(int id);
        Task<List<Admin>> GetAll();
        Task<string> Remove(int id);
        Task<bool> Update(Admin data);
    }
}
