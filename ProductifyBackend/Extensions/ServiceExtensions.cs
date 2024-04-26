using Contracts;
using Entities.Models;
using LoggerService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Repository;
using Service;
using Service.Contract;
using System.Text;

namespace ProductifyBackend.Extensions
{
    public static class ServiceExtensions
    {
        //Extension method for CORs
        public static void ConfigureCores(this IServiceCollection services) => services.AddCors(
            options =>
            {
                options.AddPolicy("CorsPolicy", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            }
            );

        //Extenion method for IISConfiguration 
        public static void ConfigureIISIntegration(this IServiceCollection services) =>
            services.Configure<IISOptions>(Options =>
            {

            });

        //Extension method for Logger
        public static void ConfigureLoggerService(this IServiceCollection services) =>
           services.AddSingleton<ILoggerManager, LoggerManager>();

        //Extension method for repository manager
        public static void ConfigureRepositoryManager(this IServiceCollection services) => 
            services.AddScoped<IRepositoryManager , RepositoryManager>();

        //extension method for service layer
        public static void ConfigureServiceManager(this IServiceCollection services) =>
            services.AddScoped<IServiceManager, ServiceManager>();


        //service extension for sql connection to remove migration assembly
        public static void ConfigureSqlContext(this IServiceCollection services,
           IConfiguration configuration) =>
                services.AddDbContext<RepositoryContext>(opts =>
                                                     opts.UseSqlServer(configuration.GetConnectionString("sqlConnection")));



        public static void ConfigureIdentity(this IServiceCollection services)
        {
            var builder = services.AddIdentity<User, IdentityRole>(o =>
            {
                o.Password.RequireDigit = true;
                o.Password.RequireLowercase = false;
                o.Password.RequireUppercase = false;
                o.Password.RequireNonAlphanumeric = false;
                o.Password.RequiredLength = 10;
                o.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<RepositoryContext>()
            .AddDefaultTokenProviders();
        }


        public static void ConfigureJWT(this IServiceCollection services, IConfiguration configuration)

        {
            var jwtSettings = configuration.GetSection("JwtSettings");
            var secretKey = "your_secret_key_here_00000000000000000";

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    ValidIssuer = jwtSettings["validIssuer"],
                    ValidAudience = jwtSettings["validAudience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))

                };
            });
        }



    }
}
