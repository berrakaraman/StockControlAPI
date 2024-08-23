using Microsoft.EntityFrameworkCore;
using EnvarterTakip.Data; // AppDbContext'in namespace'i
using Microsoft.AspNetCore.Authentication.JwtBearer; // JWT kimlik doğrulama paketini içe aktarma
using Microsoft.IdentityModel.Tokens; // Token doğrulama için gerekli
using System.Text;
using Microsoft.OpenApi.Models; // Swagger için gerekli

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();

        // Add DbContext with PostgreSQL
        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

        // Add Swagger
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthentication(); // JWT kimlik doğrulamasını ekleyin
        app.UseAuthorization(); // Authorization'ı kimlik doğrulamasından sonra ekleyin

       
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            c.RoutePrefix = string.Empty; // Swagger'ı root URL'de çalıştırmak için
        });

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}
