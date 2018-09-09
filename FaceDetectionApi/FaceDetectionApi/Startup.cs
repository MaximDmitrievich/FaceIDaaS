using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FaceDetectionApi.Utils;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Azure.CognitiveServices.Vision.Face;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace FaceDetectionApi
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
            services.AddMvc();

            services.AddSingleton<IFaceClient>(x => new FaceClient(new ApiKeyServiceClientCredentials(Consts.Subscription)));
            services.AddTransient<FaceClientContext>(x => new FaceClientContext(x.GetService<IFaceClient>()));
            services.AddTransient<IFaceClientRepository, FaceClientRepository>(x => new FaceClientRepository(x.GetService<FaceClientContext>()));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
