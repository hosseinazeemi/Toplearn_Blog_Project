using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToplearnBlogProject.Domain.Entities;

namespace ToplearnBlogProject.Application.Services.Repositories
{
    public class RoleRepository:IRoleRepository
    {
        private readonly IAppDbContext _dbContext;
        public RoleRepository(IAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Create(Role model)
        {
            _dbContext.Roles.Add(model);

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
        public async Task<List<Role>> GetAll()
        {
            //return await Task.FromResult(_dbContext.Roles.ToList());
            return _dbContext.Roles.ToList();
        }

        public async Task<bool> Remove(int id)
        {
            Role role = new Role
            {
                Id = id
            };
            _dbContext.Roles.Remove(role);

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
        public async Task<Role> FindById(int id)
        {
            return await Task.FromResult(_dbContext.Roles.FirstOrDefault(p => p.Id == id));

            //var result = _dbContext.Roles.Where(p => p.Id == id).FirstOrDefault();

            //return await Task.FromResult(result);
        }
        public async Task<bool> Update(Role data)
        {
            _dbContext.Roles.Update(data);

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

    public interface IRoleRepository
    {
        Task<int> Create(Role model);
        Task<Role> FindById(int id);
        Task<List<Role>> GetAll();
        Task<bool> Remove(int id);
        Task<bool> Update(Role data);
    }
}
