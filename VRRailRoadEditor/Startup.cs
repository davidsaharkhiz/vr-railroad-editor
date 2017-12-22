using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using VRRailRoadEditor.Data;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace EmployeeBenefits
{
	public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();

			services.AddDbContext<VRRailRoadEditorContext>(options =>
				options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
			// During serialization we wish to ignore nulls
			services.AddMvc()
				 .AddJsonOptions(options => {
					 options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore; //do not include null values during serialization
					 options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
					 options.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.Objects; //avoid self referencing loops
				 });

		}

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
