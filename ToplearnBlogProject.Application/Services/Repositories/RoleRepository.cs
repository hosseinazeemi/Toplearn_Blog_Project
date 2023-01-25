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
    }

    public interface IRoleRepository
    {
        Task<int> Create(Role model);
        Task<List<Role>> GetAll();
    }
}
