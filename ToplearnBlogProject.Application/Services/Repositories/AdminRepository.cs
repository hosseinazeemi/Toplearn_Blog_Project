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
            //return await Task.FromResult(_dbContext.Admins.ToList());
            return _dbContext.Admins.Include(p => p.Role).ToList();
        }

        public async Task<bool> Remove(int id)
        {
            Admin admin = new Admin
            {
                Id = id
            };
            _dbContext.Admins.Remove(admin);

            try
            {
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
                throw;
            }
        }
        public async Task<Admin> FindById(int id)
        {
            //return await Task.FromResult(_dbContext.Admins.FirstOrDefault(p => p.Id == id));

            var result = _dbContext.Admins.Where(p => p.Id == id).Include(p => p.Role).FirstOrDefault();

            if (result != null)
            {
                return await Task.FromResult(result);
            }
            throw new Exception("Admin Not Found");
        }
        public async Task<bool> Update(Admin data)
        {
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
        Task<bool> Remove(int id);
        Task<bool> Update(Admin data);
    }
}
