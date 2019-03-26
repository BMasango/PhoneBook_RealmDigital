using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using PhoneBook.Services.Interfaces;

namespace PhoneBook
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //Get all the services which inherit from IBaseService and register them as services.
            //Otherwise use services.Add<IContactServcie, ContractService>()
            Assembly.GetExecutingAssembly().GetTypes().Where(x => x.IsClass && x.GetInterfaces().Any(y => y == typeof(IBaseService))).ToList().ForEach(svc => 
            {
                services.Add(new ServiceDescriptor(svc.GetInterfaces().First(), svc, ServiceLifetime.Singleton));
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc(config => {
                config.MapRoute(
                    name: "Default",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Contacts", action = "GetAllContactDetails" }
                    );
            });
        }
    }
}
