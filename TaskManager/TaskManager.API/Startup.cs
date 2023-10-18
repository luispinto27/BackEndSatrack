using Microsoft.EntityFrameworkCore;
using TaskManager.Business.Services.Categories;
using TaskManager.Business.Services.Tasks;
using TaskManager.Data.Context;
using TaskManager.Data.Repositories.Categories;
using TaskManager.Data.Repositories.Tasks;

namespace TaskManager.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen();
            services.AddDbContext<ApplicationDbContext>(opt =>
            {
                opt.UseSqlServer(Configuration.GetConnectionString("database"));
            });

            services.AddControllers();

            services.AddScoped<ITaskServices, TaskServices>();
            services.AddScoped<ITaskRepository, TaskRepository>();
            services.AddScoped<ICategoryServices, CategoryServices>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();

        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
