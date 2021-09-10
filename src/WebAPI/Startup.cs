namespace WebAPI
{
    using Atlantis.Books.Shared.Extensions;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IWebHostEnvironment WebHostEnvironment { get; }

        public Startup(
            IConfiguration configuration,
            IWebHostEnvironment webHostEnvironment)
        {
            Configuration = configuration;
            WebHostEnvironment = webHostEnvironment;
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        /// </summary>
        /// <param name="services">The services <see cref="IServiceCollection"/>.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddControllers();
            services.AddAtlantisCore(Configuration);

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen();
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app">The app <see cref="IApplicationBuilder"/>.</param>
        /// <param name="env">The env <see cref="IWebHostEnvironment"/>.</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseExceptionHandler("/api/error/on-dev-env");
                //app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/api/error");
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();


            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Atlantis API V1");
                //c.RoutePrefix = string.Empty;         // To serve the Swagger UI at the app's root (http://localhost:<port>/).
            });

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
