using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using OrderShop.Api.UI.Filter;
using OrderShop.Api.UI.Services;
using OrderShopNet.Api.Core;
using OrderShopNet.Api.Core.Common.Interfaces;
using OrderShopNet.Api.Infrastructure;
using OrderShopNet.Api.Infrastructure.Persistence;

namespace OrderShop.Api.UI
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
            services.AddApplicationCore();

            services.AddInfrastructure(Configuration);

            services.AddSingleton<ICurrentUserService, CurrentUserService>();

            services.AddHttpContextAccessor();

            services.AddControllers();

            services.AddRazorPages();

            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen();

            services.AddHealthChecks()
           .AddDbContextCheck<ApplicationDbContext>();

            services.AddControllersWithViews(options =>
                options.Filters.Add<ApiExceptionFilterAttribute>())
                    .AddFluentValidation(x => x.AutomaticValidationEnabled = false);

            services.AddRazorPages();

            // Customise default API behaviour
            services.Configure<ApiBehaviorOptions>(options =>
                options.SuppressModelStateInvalidFilter = true);

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
                configuration.RootPath = "ClientApp/dist");

            //services.AddOpenApiDocument(configure =>
            //{
            //    configure.Title = "CleanArchitecture API";
            //    configure.AddSecurity("JWT", Enumerable.Empty<string>(), new OpenApiSecurityScheme
            //    {
            //        Type = OpenApiSecuritySchemeType.ApiKey,
            //        Name = "Authorization",
            //        In = OpenApiSecurityApiKeyLocation.Header,
            //        Description = "Type into the textbox: Bearer {your JWT token}."
            //    });

            //    configure.OperationProcessors.Add(new AspNetCoreOperationSecurityScopeProcessor("JWT"));
            //});
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHealthChecks("/health");
            app.UseHttpsRedirection();
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Core Order Shop API");
                c.RoutePrefix = string.Empty;
            });

            app.UseRouting();
            app.UseAuthentication();
            app.UseIdentityServer();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                   name: "default",
                   pattern: "{area=OrderShop}/{controller=OrderShopUI}/{action=Get}/{id?}");
            });
        }
    }
}
