using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InternsAssessment.Entities.DataContext;
using InternsAssessment.Entities.Repository;
using InternsAssessmentTracker.Entities.Repository;
using InternsAssessmentTracker.Entities.Repository.Interfaces;
using InternsAssessmentTracker.Services.BusinessObjects;
using InternsAssessmentTracker.Services.Interfaces;
using InternsAssessmentTracker.Services.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace InternsAssessmentTracker.API
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
                    //builder => builder.WithOrigins("http://localhost:4200")
                    builder => builder.WithOrigins("*")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    );
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            
            services.AddDbContext<IATrackerDbContext>(option => option.UseSqlServer(@"Data Source=AROZARIO01;User ID=sa;Password=Ady6ady@@@;Initial Catalog=InternAssessmentTrackerDb;"));
                  
            services.AddTransient<IInternRepository, InternRepository>();
            services.AddTransient<IProjectRepository, ProjectRepository>();
            services.AddTransient<IProjectTechnologiesRepository, ProjectTechnologiesRepository>();
            services.AddTransient<IInternRatingRepository, InternRatingRepository>();
            services.AddTransient<ITechnologyRepository, TechnologyRepository>();


            services.AddTransient<IInternService, InternService>();
            services.AddTransient<IProjectService, ProjectService>();
            services.AddTransient<IRatingService, RatingService>();            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors("CorsPolicy");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            //app.UseCors(options => options.WithOrigins("http://localhost:4200").AllowAnyMethod());

            //builder.WithOrigins("http://localhost:4200/"));

        }
    }
}
