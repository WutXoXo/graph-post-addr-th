using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TH.POST.Address.MySQL.GraphQL.Features;
using TH.POST.Address.MySQL.GraphQL.Features.Amphures;
using TH.POST.Address.MySQL.GraphQL.Features.Districts;
using TH.POST.Address.MySQL.GraphQL.Features.Geographies;
using TH.POST.Address.MySQL.GraphQL.Features.Provinces;
using TH.POST.Address.Persistence;
using TH.POST.Address.Persistence.Background;

namespace TH.POST.Address.MySQL.GraphQL
{
    public class Startup
    {
        private readonly IConfiguration Configuration;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            #region Localization
            services.AddLocalization(options => options.ResourcesPath = "Resources");
            #endregion

            services.AddMySQLContext(Configuration);
            services.AddPersistenceRegistration();
            services.AddHostedService<InitialMySQLBackground>();
            services.AddGraphQLServer()
                .AddQueryType<Query>()
                .AddType<GeographyType>()
                .AddType<ProvinceType>()
                .AddType<AmphurType>()
                .AddType<DistrictType>()
                .AddFiltering()
                .AddSorting();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            var supportedCultures = new[] { "en-US", "th" };
            var localizationOptions = new RequestLocalizationOptions().SetDefaultCulture(supportedCultures[0])
                .AddSupportedCultures(supportedCultures)
                .AddSupportedUICultures(supportedCultures);

            app.UseRequestLocalization(localizationOptions);

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL();

                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });

            app.UseGraphQLVoyager();
        }
    }
}
