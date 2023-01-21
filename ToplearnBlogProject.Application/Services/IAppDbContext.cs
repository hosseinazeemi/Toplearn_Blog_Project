using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToplearnBlogProject.Domain.Entities;

namespace ToplearnBlogProject.Application.Services
{
    public interface IAppDbContext
    {
        DbSet<Admin> Admins { get; set; }
        DbSet<Blog> Blogs { get; set; }
        DbSet<BlogFile> BlogFiles { get; set; }
        DbSet<BlogTag> BlogTags { get; set; }
        DbSet<Tag> Tags { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<Role> Roles { get; set; }
        DbSet<Setting> Setting { get; set; }
        DbSet<Comment> Comments { get; set; }
        int SaveChanges(bool acceptAllChangesOnSuccess);
        int SaveChanges();
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess , CancellationToken cancelation = new CancellationToken());
        Task<int> SaveChangesAsync(CancellationToken cancelation = new CancellationToken());
    }
}
