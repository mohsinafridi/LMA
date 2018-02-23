using LMA.Data;
using LMA.Data.Interfaces;
using LMA.Data.Model;
using LMA.Data.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LMA
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
            services.AddDbContext<LMADbContext>(options => options.UseInMemoryDatabase("LMADbContext"));
            services.AddTransient<IAuthorRepository, AuthorRepository>();
            services.AddTransient<IBookRepository, BookRepository>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            
            
            services.AddMvc();
            //services.AddDbContext<LMADbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DbConnection")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.IDesignTimeDbContextFactory
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
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

            DbInitialize.Seed(app);

        }


    }
}
