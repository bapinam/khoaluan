using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using KhoaLuan.Data.EF;
using KhoaLuan.Service.AutoMapper;
using KhoaLuan.Service;
using KhoaLuan.ViewModels;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KhoaLuan.Utilities.Constants;
using KhoaLuan.Service.MaterialsTypeService;
using KhoaLuan.ViewModels.MaterialsTypeViewModel;
using Microsoft.AspNetCore.Identity;
using KhoaLuan.Data.Entities;
using KhoaLuan.Service.UserService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using KhoaLuan.ViewModels.User;
using KhoaLuan.Service.RoleService;
using KhoaLuan.Service.SupplierService;
using KhoaLuan.ViewModels.Supplier;
using KhoaLuan.ViewModels.ProductType;
using KhoaLuan.Service.ProductTypeService;
using KhoaLuan.ViewModels.ProductTypeGroup;
using KhoaLuan.Service.ProductTypeGroupService;
using KhoaLuan.Service.ProductService;
using KhoaLuan.Service.Common;
using KhoaLuan.Service.MaterialService;
using KhoaLuan.ViewModels.Product;
using KhoaLuan.ViewModels.Material;
using KhoaLuan.Service.RecipeService;
using KhoaLuan.Service.ManageCodeService;

namespace KhoaLuan.API
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
            services.AddDbContext<EnterpriseDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString(SystemConstants.MainConectionString)));

            services.AddIdentity<AppUser, AppRole>()
                .AddEntityFrameworkStores<EnterpriseDbContext>()
                .AddDefaultTokenProviders();

            services.AddAuthorization(options =>
            {
                //Employee

                options.AddPolicy(SystemConstants.PolicyEmployee.EditEmployee,
                    policy => policy.RequireClaim(SystemConstants.CustomClaimTypes.Permission, SystemConstants.EmployeeRoleClaims.Edit,
                      SystemConstants.AdminRoleClaims.Admin));

                options.AddPolicy(SystemConstants.PolicyEmployee.ViewEmployee,
                    policy => policy.RequireClaim(SystemConstants.CustomClaimTypes.Permission, SystemConstants.EmployeeRoleClaims.View,
                      SystemConstants.AdminRoleClaims.Admin));

                // Recorads
                options.AddPolicy(SystemConstants.PolicyRecorads.Recorads, policy =>
                {
                    policy.RequireRole(SystemConstants.ListRole.Admin, SystemConstants.ListRole.RecordsManagement);
                });

                // admin
                options.AddPolicy(SystemConstants.PolicyRecorads.Admin, policy =>
                {
                    policy.RequireRole(SystemConstants.ListRole.Admin);
                });
            });

            //Declare DI
            services.AddTransient<IManageCodeService, ManageCodeService>();
            services.AddTransient<IRecipeService, RecipeService>();
            services.AddTransient<IProductTypeGroupService, ProductTypeGroupService>();
            services.AddTransient<IProductTypeService, ProductTypeService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<ISupplierService, SupplierService>();
            services.AddTransient<IMaterialService, MaterialService>();
            services.AddTransient<IMaterialsTypeService, MaterialsTypeService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IRoleService, RoleService>();

            services.AddTransient<UserManager<AppUser>, UserManager<AppUser>>();
            services.AddTransient<SignInManager<AppUser>, SignInManager<AppUser>>();
            services.AddTransient<RoleManager<AppRole>, RoleManager<AppRole>>();

            services.AddTransient<IStorageService, FileStorageService>();

            // Khai báo fluent validation
            services.AddTransient<IValidator<CreateMaterialsType>, CreateMaterialsTypeValidor>();
            services.AddTransient<IValidator<UpdateMaterialsType>, UpdateMaterialsTypeValidor>();

            services.AddTransient<IValidator<MaterialCreate>, MaterialCreateValidator>();
            services.AddTransient<IValidator<MaterialUpdate>, MaterialUpdateValidator>();

            services.AddTransient<IValidator<CreateProductTypeGroup>, CreateProductTypeGroupValidor>();
            services.AddTransient<IValidator<UpdateProductTypeGroup>, UpdateProductTypeGroupValidor>();

            services.AddTransient<IValidator<ProductCreate>, ProductCreateValidator>();
            services.AddTransient<IValidator<ProductUpdate>, ProductUpdateValidator>();

            services.AddTransient<IValidator<CreateProductType>, CreateProductTypeValidor>();
            services.AddTransient<IValidator<UpdateProductType>, UpdateProductTypeValidor>();

            services.AddTransient<IValidator<SupplierCreate>, SupplierCreateValidator>();
            services.AddTransient<IValidator<SupplierUpdate>, SupplierUpdateValidator>();

            services.AddTransient<IValidator<RegisterRequest>, RegisterRequestValidator>();
            services.AddTransient<IValidator<LoginRequest>, LoginRequestValidator>();
            services.AddTransient<IValidator<UserUpdatePassword>, UserUpdatePasswordValidator>();
            services.AddTransient<IValidator<UserUpdateRequest>, UserUpdateRequestValidator>();

            //-------
            services.AddControllers()
                .AddFluentValidation();

            services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Swagger Doanh Nghiệp", Version = "v1" });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                  {
                    {
                      new OpenApiSecurityScheme
                      {
                        Reference = new OpenApiReference
                          {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                          },
                          Scheme = "oauth2",
                          Name = "Bearer",
                          In = ParameterLocation.Header,
                        },
                        new List<string>()
                      }
                    });
            });

            // nếu có token thì nó tự giải mã ra, ko đúng sẽ trả về 401
            string issuer = Configuration.GetValue<string>("Tokens:Issuer");
            string signingKey = Configuration.GetValue<string>("Tokens:Key");
            byte[] signingKeyBytes = System.Text.Encoding.UTF8.GetBytes(signingKey);

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })

            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidIssuer = issuer,
                    ValidateAudience = true,
                    ValidAudience = issuer,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ClockSkew = System.TimeSpan.Zero,
                    IssuerSigningKey = new SymmetricSecurityKey(signingKeyBytes)
                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger Doanh Nghiệp V1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}