using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToplearnBlogProject.Domain.Entities;

namespace ToplearnBlogProject.Application.Services.Repositories
{
    public class TagRepository : ITagRepository
    {
        private readonly IAppDbContext _dbContext;
        public TagRepository(IAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Create(Tag model)
        {
            _dbContext.Tags.Add(model);

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
        public async Task<List<Tag>> GetAll()
        {
            return _dbContext.Tags.ToList();
        }

        public async Task<bool> Remove(int id)
        {
            Tag role = new Tag
            {
                Id = id
            };
            _dbContext.Tags.Remove(role);

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
        public async Task<Tag> FindById(int id)
        {
            return await Task.FromResult(_dbContext.Tags.FirstOrDefault(p => p.Id == id));
        }
        public async Task<bool> Update(Tag data)
        {
            _dbContext.Tags.Update(data);

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

    public interface ITagRepository
    {
        Task<int> Create(Tag model);
        Task<Tag> FindById(int id);
        Task<List<Tag>> GetAll();
        Task<bool> Remove(int id);
        Task<bool> Update(Tag data);
    }
}
