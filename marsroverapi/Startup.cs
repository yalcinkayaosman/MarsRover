using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace marsroverapi
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
            services.AddCors(options =>
 {
     options.AddPolicy("CorsPolicy",
             builder => builder.AllowAnyOrigin()
                               .AllowAnyMethod()
                               .AllowAnyHeader()
                               .AllowCredentials());
 });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.Configure<MongoSettings>(options =>
    {
        options.ConnectionString
            = Configuration.GetSection("MongoConnection:ConnectionString").Value;
        options.Database
            = Configuration.GetSection("MongoConnection:Database").Value;
    });
            services.AddTransient<ICommandService, CommandService>();
            services.AddTransient<ICommandRepository, CommandRepository>();
            services.AddTransient<IRepository<Command>, Repository<Command>>();
            services.AddTransient<IMongoRepository<Command>, MongoRepository<Command>>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IRepository<User>, Repository<User>>();
            services.AddTransient<IMongoRepository<User>, MongoRepository<User>>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("marsroverapi", new OpenApiInfo
                {
                    Title = "marsroverapi",
                    Version = "1.0.0",
                });
            });
        }

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

            app.UseMiddleware<BasicAuthMiddleware>("tetxua.com");
            app.UseHttpsRedirection();
            app.UseCors("CorsPolicy");
            app.UseMvc();

            app.UseSwagger()
            .UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/marsroverapi/swagger.json", "marsroverapi Swagger");
                });
        }
    }
}
