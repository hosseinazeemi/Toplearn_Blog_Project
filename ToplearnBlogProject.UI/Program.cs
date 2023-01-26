using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor.Services;
using ToplearnBlogProject.UI.Services;
using ToplearnBlogProject.UI.Services.Repositories;

namespace Company.WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();

            string apiUrl = builder.Configuration.GetValue<string>("ApiBaseUrl");
            builder.Services.AddHttpClient<IHttpService, HttpService>(op =>
            {
                op.BaseAddress = new Uri(apiUrl);
            });
            builder.Services.AddScoped<IRoleService, RoleService>();
            builder.Services.AddScoped<IAdminService, AdminService>();
            builder.Services.AddMudServices();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.MapRazorPages();
            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");

            app.Run();
        }
    }
}