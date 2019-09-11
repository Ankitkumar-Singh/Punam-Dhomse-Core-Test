using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductManagement.Interfaces;
using ProductManagement.MyDbContext;
using ProductManagement.Repositories;

namespace ProductManagement
{
    public class Startup
    {
        #region "Private variables"
        private readonly IConfiguration _configuration;
        #endregion

        #region "Constructor"
        //Initializes a new instance of the <see cref="Startup"/> class.
        //<param name="Configuration">The configuration.</param>
        public Startup(IConfiguration Configuration) => _configuration = Configuration;
        #endregion

        #region "ConfigureServices"
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Add connection string to connect with database.
            services.AddDbContextPool<ProductDBContext>(
                option =>
                option.UseSqlServer(_configuration.GetConnectionString("ProductString")));

            //Register service for product.
            services.AddScoped(typeof(IProductRepository), typeof(ProductRepository));

            //Register service for category.
            services.AddScoped(typeof(ICategoryRepository), typeof(CatagoryRepository));

            //Register service of MVC.
            services.AddMvc();

            //Register service for pagelist.
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
        }
        #endregion

        #region "Configure"
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseStatusCodePagesWithRedirects("/Error/{0}");

            //UseStaticFiles to access static files.
            app.UseStaticFiles();

            //UseMvc for use mvc service.
            app.UseMvc();
        }
        #endregion
    }
}
