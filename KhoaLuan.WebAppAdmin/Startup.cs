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
            services.AddScoped<IValidator<MaterialCreate>, MaterialCreateValidator>();
            services.AddScoped<IValidator<MaterialUpdate>, MaterialUpdateValidator>();

            services.AddScoped<IValidator<CreateMaterialsType>, CreateMaterialsTypeValidor>();
            services.AddScoped<IValidator<UpdateMaterialsType>, UpdateMaterialsTypeValidor>();

            services.AddScoped<IValidator<CreateProductTypeGroup>, CreateProductTypeGroupValidor>();
            services.AddScoped<IValidator<UpdateProductTypeGroup>, UpdateProductTypeGroupValidor>();

            services.AddScoped<IValidator<CreateProductType>, CreateProductTypeValidor>();
            services.AddScoped<IValidator<UpdateProductType>, UpdateProductTypeValidor>();

            services.AddScoped<IValidator<ProductCreate>, ProductCreateValidator>();
            services.AddScoped<IValidator<ProductUpdate>, ProductUpdateValidator>();

            services.AddScoped<IValidator<SupplierCreate>, SupplierCreateValidator>();
            services.AddScoped<IValidator<SupplierUpdate>, SupplierUpdateValidator>();

            services.AddScoped<IValidator<RegisterRequest>, RegisterRequestValidator>();
            services.AddScoped<IValidator<LoginRequest>, LoginRequestValidator>();
            services.AddScoped<IValidator<UserUpdatePassword>, UserUpdatePasswordValidator>();
            services.AddScoped<IValidator<UserUpdateRequest>, UserUpdateRequestValidator>();

            //------
            services.AddControllersWithViews();

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(240);
            });

            //DI
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<IUserApiClient, UserApiClient>();
            services.AddScoped<IRoleApiClient, RoleApiClient>();

            services.AddScoped<IManageCodeApiClient, ManageCodeApiClient>();
            services.AddScoped<IRecipeApiClient, RecipeApiClient>();
            services.AddScoped<ISupplierApiClient, SupplierApiClient>();
            services.AddScoped<IMaterialApiClient, MaterialApiClient>();
            services.AddScoped<IMaterialsTypeApiClient, MaterialsTypeApiClient>();
            services.AddScoped<IProductTypeApiClient, ProductTypeApiClient>();
            services.AddScoped<IProductTypeGroupApiClient, ProductTypeGroupApiClient>();
            services.AddScoped<IProductApiClient, ProductApiClient>();
            services.AddScoped<IOrderPlanApiClient, OrderPlanApiClient>();
            services.AddScoped<IBillApiClient, BillApiClient>();
            services.AddScoped<IProcessPlanApiClient, ProcessPlanApiClient>();
            services.AddScoped<IProcessingDetailApiClient, ProcessingDetailApiClient>();
            services.AddScoped<INotificationApiClient, NotificationApiClient>();

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