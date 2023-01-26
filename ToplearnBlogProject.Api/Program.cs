using Microsoft.EntityFrameworkCore;
using ToplearnBlogProject.Api.Services;
using ToplearnBlogProject.Application.Services;
using ToplearnBlogProject.Application.Services.Repositories;
using ToplearnBlogProject.Persistence.Context;

namespace ToplearnBlogProject.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            string connection = builder.Configuration.GetSection("ConnectionStrings")["DefaultConnection"];
            builder.Services.AddDbContext<AppDbContext>(p => p.UseSqlServer(connection));
            builder.Services.AddScoped<IAppDbContext, AppDbContext>();
            builder.Services.AddScoped<IRoleRepository, RoleRepository>();
            builder.Services.AddScoped<IAdminRepository, AdminRepository>();
            builder.Services.AddScoped<IUploadFileService, UploadFileService>();
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}