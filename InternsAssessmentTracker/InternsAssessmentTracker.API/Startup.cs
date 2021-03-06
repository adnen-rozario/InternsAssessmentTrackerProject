﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using InternsAssessment.Entities.DataContext;
using InternsAssessment.Entities.Repository;
using InternsAssessmentTracker.API.Logging;
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
using NLog;

namespace InternsAssessmentTracker.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            LogManager.LoadConfiguration(System.String.Concat(Directory.GetCurrentDirectory(), configuration.GetValue<string>("NlogConfigFilePath")));
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",                    
                    builder => builder.WithOrigins(Configuration.GetValue<string>("CorsAllowedDomain"))
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    );
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddSingleton<ILog, LogNLog>();

            services.AddDbContext<IATrackerDbContext>(option => option.UseSqlServer(Configuration.GetValue<string>("DBConnectionString")));
                  
            services.AddTransient<IInternRepository, InternRepository>();
            services.AddTransient<IProjectRepository, ProjectRepository>();
            services.AddTransient<IProjectTechnologiesRepository, ProjectTechnologiesRepository>();
            services.AddTransient<IInternRatingRepository, InternRatingRepository>();
            services.AddTransient<ITechnologyRepository, TechnologyRepository>();
            services.AddTransient<IProjectInternRepository, ProjectInternRepository>();
            services.AddTransient<IRatingMasterRepository, RatingMasterRepository>();
            services.AddTransient<IMentorRepository, MentorRepository>();
            services.AddTransient<IMentorProjectRepository, MentorProjectRepository>();


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

        }
    }
}
