using FluentValidation;
using KhoaLuan.Utilities.Constants;
using KhoaLuan.ViewModels.Material;
using KhoaLuan.ViewModels.MaterialsTypeViewModel;
using KhoaLuan.ViewModels.Product;
using KhoaLuan.ViewModels.ProductType;
using KhoaLuan.ViewModels.ProductTypeGroup;
using KhoaLuan.ViewModels.Supplier;
using KhoaLuan.ViewModels.User;
using KhoaLuan.WebAppAdmin.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhoaLuan.WebAppAdmin
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
            services.AddHttpClient();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/Login/Index"; // nếu chưa đăng nhập thì nó về trang login
                    options.AccessDeniedPath = "/Home/Index/";
                });

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

            ///------
            services.AddTransient<IValidator<MaterialCreate>, MaterialCreateValidator>();
            services.AddTransient<IValidator<MaterialUpdate>, MaterialUpdateValidator>();

            services.AddTransient<IValidator<CreateMaterialsType>, CreateMaterialsTypeValidor>();
            services.AddTransient<IValidator<UpdateMaterialsType>, UpdateMaterialsTypeValidor>();

            services.AddTransient<IValidator<CreateProductTypeGroup>, CreateProductTypeGroupValidor>();
            services.AddTransient<IValidator<UpdateProductTypeGroup>, UpdateProductTypeGroupValidor>();

            services.AddTransient<IValidator<CreateProductType>, CreateProductTypeValidor>();
            services.AddTransient<IValidator<UpdateProductType>, UpdateProductTypeValidor>();

            services.AddTransient<IValidator<ProductCreate>, ProductCreateValidator>();
            services.AddTransient<IValidator<ProductUpdate>, ProductUpdateValidator>();

            services.AddTransient<IValidator<SupplierCreate>, SupplierCreateValidator>();
            services.AddTransient<IValidator<SupplierUpdate>, SupplierUpdateValidator>();

            services.AddTransient<IValidator<RegisterRequest>, RegisterRequestValidator>();
            services.AddTransient<IValidator<LoginRequest>, LoginRequestValidator>();
            services.AddTransient<IValidator<UserUpdatePassword>, UserUpdatePasswordValidator>();
            services.AddTransient<IValidator<UserUpdateRequest>, UserUpdateRequestValidator>();

            //------
            services.AddControllersWithViews();

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(240);
            });

            //DI
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddTransient<IUserApiClient, UserApiClient>();
            services.AddTransient<IRoleApiClient, RoleApiClient>();

            services.AddTransient<IManageCodeApiClient, ManageCodeApiClient>();
            services.AddTransient<IRecipeApiClient, RecipeApiClient>();
            services.AddTransient<ISupplierApiClient, SupplierApiClient>();
            services.AddTransient<IMaterialApiClient, MaterialApiClient>();
            services.AddTransient<IMaterialsTypeApiClient, MaterialsTypeApiClient>();
            services.AddTransient<IProductTypeApiClient, ProductTypeApiClient>();
            services.AddTransient<IProductTypeGroupApiClient, ProductTypeGroupApiClient>();
            services.AddTransient<IProductApiClient, ProductApiClient>();
            services.AddTransient<IOrderPlanApiClient, OrderPlanApiClient>();

            // SignalR
            services.AddSignalR();
            //---
            IMvcBuilder builder = services.AddRazorPages();
            var environment = Environment.GetEnvironmentVariable(SystemConstants.Environment);

#if DEBUG
            if (environment == Environments.Development)
            {
                builder.AddRazorRuntimeCompilation();
            }
#endif
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Welcome}/{id?}");
                endpoints.MapHub<ChatHub>("/chatHub");
            });
        }
    }
}