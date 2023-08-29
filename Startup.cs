using ApiProject.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using ApiProject.Models;
using System.Reflection;

namespace ApiProject
{
    public class Startup
    {

       /* public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddSwaggerGen{options => (options.SwaggerDoc{ "v2", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "ApiProject", Version = "v2", Description = "Project", }); });
            services.AddDbContext < Project2DBContext>(options => options.UseSqlServer("Persist Security Info=False;User ID=projectadmin;Password=CMPG@323;Initial Catalog=Project2DB;Data Source=sqldbproject.database.windows.net"); 
        }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger(); app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v2/swagger.json", "ApiProject"));

        }*/
    }
}

