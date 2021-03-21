using GreetingAppManagerLayer;
using GreetingAppRepositoryLayer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreetingApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        //ConfigureServices method includes IServiceCollection parameter to register services to the IoC container. 
        public void ConfigureServices(IServiceCollection services)
        {
            //"Service" then understand it as a class which is going to be used in some other class.
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddTransient<IEmployeeManager,EmployeeManager>();
            services.AddTransient<IEmployeeRepo, EmployeeRepo>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Greeting API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //IApplicationBuilder, IHostingEnvironment, and ILoggerFactory by default. These services are framework services injected by built-in IoC container.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment()) //// true if the enviroment is Devlopment otherwise false
            {
                // Extension Method UseDeveloperExceptionPage()
                //Captures synchronous and asynchronous exceptions from the pipeline and generates HTML error responses.
                app.UseDeveloperExceptionPage();  
            }
            else
            {
                app.UseHsts();
            }
            //Each Use extension method adds one or more middlewarecomponents to the request pipeline.
            app.UseHttpsRedirection();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyAPI V1");
            });
            app.UseMvc();
            app.UseStaticFiles();
            


        }
    }
}
