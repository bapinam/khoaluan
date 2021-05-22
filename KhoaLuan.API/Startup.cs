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
using KhoaLuan.Service.OrderPlanService;
using KhoaLuan.Service.BillService;
using KhoaLuan.Service.ProcessPlanService;
using KhoaLuan.Service.ProcessingDetailService;
using KhoaLuan.Service.NotificationService;

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
            // doi voi db thi nen dung Scoped, ko nen dung Transient, do la li do tai sao return ve 15, nhung debug ra 16
            // Transient thi lifetime cua no la moi khi dc inject no se thanh new instance, scoped la xuyen suot Request
            services.AddScoped<INotificationService, NotificationService>();
            services.AddScoped<IManageCodeService, ManageCodeService>();
            services.AddScoped<IProcessPlanService, ProcessPlanService>();
            services.AddScoped<IProcessingDetailService, ProcessingDetailService>();
            services.AddScoped<IRecipeService, RecipeService>();
            services.AddScoped<IProductTypeGroupService, ProductTypeGroupService>();
            services.AddScoped<IProductTypeService, ProductTypeService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ISupplierService, SupplierService>();
            services.AddScoped<IMaterialService, MaterialService>();
            services.AddScoped<IMaterialsTypeService, MaterialsTypeService>();
            services.AddScoped<IOrderPlanService, OrderPlanService>();
            services.AddScoped<IBillService, BillService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRoleService, RoleService>();

            services.AddScoped<UserManager<AppUser>, UserManager<AppUser>>();
            services.AddScoped<SignInManager<AppUser>, SignInManager<AppUser>>();
            services.AddScoped<RoleManager<AppRole>, RoleManager<AppRole>>();

            services.AddScoped<IStorageService, FileStorageService>();

            // Khai báo fluent validation
            services.AddScoped<IValidator<CreateMaterialsType>, CreateMaterialsTypeValidor>();
            services.AddScoped<IValidator<UpdateMaterialsType>, UpdateMaterialsTypeValidor>();

            services.AddScoped<IValidator<MaterialCreate>, MaterialCreateValidator>();
            services.AddScoped<IValidator<MaterialUpdate>, MaterialUpdateValidator>();

            services.AddScoped<IValidator<CreateProductTypeGroup>, CreateProductTypeGroupValidor>();
            services.AddScoped<IValidator<UpdateProductTypeGroup>, UpdateProductTypeGroupValidor>();

            services.AddScoped<IValidator<ProductCreate>, ProductCreateValidator>();
            services.AddScoped<IValidator<ProductUpdate>, ProductUpdateValidator>();

            services.AddScoped<IValidator<CreateProductType>, CreateProductTypeValidor>();
            services.AddScoped<IValidator<UpdateProductType>, UpdateProductTypeValidor>();

            services.AddScoped<IValidator<SupplierCreate>, SupplierCreateValidator>();
            services.AddScoped<IValidator<SupplierUpdate>, SupplierUpdateValidator>();

            services.AddScoped<IValidator<RegisterRequest>, RegisterRequestValidator>();
            services.AddScoped<IValidator<LoginRequest>, LoginRequestValidator>();
            services.AddScoped<IValidator<UserUpdatePassword>, UserUpdatePasswordValidator>();
            services.AddScoped<IValidator<UserUpdateRequest>, UserUpdateRequestValidator>();

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