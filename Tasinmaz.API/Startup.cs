using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Tasinmaz.API.Business.Concrete;
using Microsoft.EntityFrameworkCore;
using Core.Utilities.Security.JWT;
using TasinmazProje.API.Business.Abstract;
using DataAccess.Abstract;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.Encryption;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using TokenOptions = Core.Utilities.Security.JWT.TokenOptions;
using Core.DependencyResolvers;
using Core.Extensions;
using Core.Utilities.IoC;


namespace Tasinmaz.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddCors();


            services.AddSwaggerGen(c =>
            {

                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Gokce Bektas Tasýnmaz API", Version = "v7", Description = "Taþýnmaz Projesi" });
            });

            services.AddDbContext<Context>(options =>
            options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IParselService, ParselManager>();
            services.AddScoped<IIlService, IlManager>();
            services.AddScoped<IIlceService, IlceManager>();
            services.AddSingleton<IIlceDal, EfIlce>();
            services.AddScoped<IMahalleService, MahalleManager>();
            services.AddSingleton<IUserService, UserManager>();
            services.AddSingleton<IUserOperationClaimService, UserOperationClaimManager>();
            services.AddScoped<IAuthService, AuthManager>();
            services.AddSingleton<ITokenHelper, JwtHelper>();
            services.AddSingleton<IInterceptorSelector, AspectInterceptorSelector>();
            services.AddScoped<ILogService, LogManager>();
            services.AddSingleton<IUserDal, EfUserDal>();
            services.AddSingleton<IUserOperationClaimDal, EfUserOperationClaim>();
            var tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidIssuer = tokenOptions.Issuer,
                        ValidAudience = tokenOptions.Audience,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
                    };
                });

            services.AddDependencyResolvers(new ICoreModule[] {
               new CoreModule()
            });
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.WithOrigins("http://localhost:4200") // Angular uygulamanýzýn adresi
                           .AllowAnyHeader()
                           .AllowAnyMethod()
                           .AllowAnyOrigin();

                });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.ConfigureCustomExceptionMiddleware();

            app.UseCors(builder => builder
                .WithOrigins("http://localhost:4200")
                .AllowAnyHeader()
                .AllowAnyMethod());

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "GokceBektasTasinmaz API v7");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
    
