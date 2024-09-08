using EComPayApp.Application.Features.CQRS.Queries.Address.GetAddress;
using EComPayApp.Application.Interfaces.Repositories.IUnitOfWork;
using EComPayApp.Persistence;
using EComPayApp.Infrastructure;
using EComPayApp.Persistence.UoW;
using System.Reflection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using FluentValidation.AspNetCore;
using EComPayApp.Application.Validators.Abouts;

namespace EComPayApp.API
{
    public class Program
    {
        [Obsolete]
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssemblies(
                    Assembly.GetExecutingAssembly(),
                    Assembly.Load("EComPayApp.Application")
                );
            });

            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddInfrastructureServices();
            builder.Services.AddControllers()
                .AddFluentValidation(opt =>
                {
                    opt.ImplicitlyValidateChildProperties = true;
                    opt.ImplicitlyValidateRootCollectionElements= true;
                    opt.RegisterValidatorsFromAssemblyContaining<CreateAboutDtoValidator>();

                });
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddPersistenceServices();
            builder.Services.AddInfrastructureServices();
            builder.Services.AddHttpClient();
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
       .AddJwtBearer("Admin", options =>
       {
           options.TokenValidationParameters = new TokenValidationParameters
           {
               ValidateAudience = true,
               ValidateIssuer = true,
               ValidateLifetime = true,
               ValidateIssuerSigningKey = true,
               ValidAudience = builder.Configuration["Token:Audience"],
               ValidIssuer = builder.Configuration["Token:Issuer"],
               IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:SecurityKey"])),
               LifetimeValidator = (notBefore, expires, securityToken, validationParameters) => expires != null ? expires > DateTime.UtcNow : false

           };
       });
            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.UseAuthentication();

            app.MapControllers();

            app.Run();
        }
    }
}
