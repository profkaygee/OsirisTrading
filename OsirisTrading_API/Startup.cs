using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using OsirisTrading.Application;
using OsirisTrading.Contracts;
using OsirisTrading.Infrastructure.ServiceLayer;
using OsirisTrading.Mapping;
using RestSharp;

namespace OsirisTrading_API
{
    /// <summary>
    /// The start up class.
    /// </summary>
    public class Startup
    {
        private string identityServerUrl = string.Empty;
        private string apiName = string.Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        /// <value>
        /// The configuration.
        /// </value>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services">The services.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddControllers();
            services.AddMemoryCache();

            // Add the versioning
            services.AddApiVersioning(config =>
            {
                config.DefaultApiVersion = new ApiVersion(1, 0);
                config.AssumeDefaultVersionWhenUnspecified = true;
            });

            services.AddIdentityServer()
                .AddDeveloperSigningCredential()
                .AddInMemoryIdentityResources(OsirisTrading_API.Configuration.IdentityResources)
                .AddInMemoryClients(OsirisTrading_API.Configuration.Clients)
                .AddInMemoryApiResources(OsirisTrading_API.Configuration.Apis)
                .AddTestUsers(TestUsers.Users);

            //services.AddLocalApiAuthentication();
            services.AddTransient<IRestClient, RestClient>();
            services.AddTransient<IApplicationSettings, ApplicationSettings>();
            services.AddTransient<IServiceLayer, ServiceLayer>();

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllPolicy", builder =>
                {
                    builder.AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowAnyOrigin();
                });
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "OsirisTrading_API", Version = "v1" });
            });

            services.AddHealthChecks();

            MapServices(services);
            MapIdentityServices(services);
        }

        private void MapIdentityServices(IServiceCollection services)
        {
            identityServerUrl = Configuration["AppSettings:IdentityServerUrl"];
            apiName = Configuration["AppSettings:IdentityServerName"];

            //services.AddAuthentication(options =>
            //{

            //}).AddJwtBearer(options =>
            //{
            //    options.backc
            //})
        }

        private void MapServices(IServiceCollection services)
        {
            services.AddApplicationLayer();
            services.AddAutoMapper(typeof(MappingProfile));
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app">The application.</param>
        /// <param name="env">The env.</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "OsirisTrading_API v1"));
            }

            app.UseCors("AllowAllPolicy");
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseIdentityServer();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}