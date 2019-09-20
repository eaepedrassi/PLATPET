using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PlatPetWebApplicationAPI.Models;
using Microsoft.EntityFrameworkCore;


namespace PlatPetWebApplicationAPI
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

            string connectionString = "Provider=SQLOLEDB.1;Persist Security Info=False;User ID=platpet;Initial Catalog=PLATPET_201902;Data Source=172.16.48.10";

            services.AddDbContext<PlatPetContext>(opt => opt.UseSqlServer(connectionString));
            //services.AddDbContext<PlatPetContext>(opt => opt.UseInMemoryDatabase("PlatPetList"));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
