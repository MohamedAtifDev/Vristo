
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using Microsoft.Extensions.Options;
using Serilog;
using MediatR;

using VristoAPI.Application.Mappings;
using VristoAPI.Infrastructure.Database;
using System.Reflection;
using VristoAPI.Domain.Models;
using VristoAPI.Application.Models;
using VristoAPI.Application.Services;
using VristoAPI.Domain.GenericRepo;
using VristoAPI.Domain.UnitOfWork;
using VristoAPI.Infrastructure.UnitOfWork;

namespace VristoAPI
{
    public class Program
    {

    
    
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Host.ConfigureLogging((context, logging) =>
            {
                logging.ClearProviders();  // Clear the default logging providers (optional)
                logging.AddSerilog(new LoggerConfiguration()
                    .ReadFrom.Configuration(context.Configuration)  // Read settings from appsettings.json
                    .Enrich.FromLogContext()                        // Add additional context like request info
                    .CreateLogger());
            });

            // Add services to the container.
        
            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.Configure<TwillioSettings>(builder.Configuration.GetSection("Twillio"));
            builder.Services.AddScoped<ISMSSender, SMSSender>();
            builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepoistory<>));
            builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();
            builder.Services.AddDbContext<DataContext>(opt =>
            {
                opt.UseSqlServer(builder.Configuration.GetConnectionString("DBConnection"));
            });
            builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;
            }).AddEntityFrameworkStores<DataContext>()
.AddDefaultTokenProviders();
            var assemblies = Assembly.Load("VristoAPI.Application");

            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assemblies));
            builder.Services.AddAutoMapper(opt =>
            {
                opt.AddProfile(new MapperProfiler());
            });
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();  // Enable the Swagger middleware to generate the Swagger JSON
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                    options.RoutePrefix = string.Empty;  // Set Swagger UI at the root (optional)
                });
            }

            app.UseHttpsRedirection();


            app.UseAuthentication();
            app.UseAuthorization();
            

            app.MapControllers();

            app.Run();
        }
    }
}
