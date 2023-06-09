﻿using AutoMapper;
using PortfolioService.Application.Interfaces;
using PortfolioService.Domain.Entities;
using PortfolioService.Infrastructure.Data;
using PortfolioService.Infrastructure.Data.Dtos;
using PortfolioService.Infrastructure.Data.Repositories;

namespace PortfolioService.Api.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMongoDbClient(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<MongoClientService, MongoClientService>(sp =>
            {
                var connectionString = configuration.GetConnectionString("MongoDB");
                var database = configuration.GetConnectionString("DatabaseName");
                return new MongoClientService(connectionString, database);
            });

            return services;
        }

        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IExperienceRepository<Experience>, ExperienceRepository>();
            services.AddScoped<IProjectRepository<Project>, ProjectRepository>();
            services.AddScoped<IDegreeRepository<Degree>, DegreeRepository>();

            return services;
        }

        public static IServiceCollection AddAutoMappers(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(configuration =>
            {
                configuration.CreateMap<Experience, ExperienceDto>();
                configuration.CreateMap<ExperienceDto, Experience>();
                configuration.CreateMap<Dtos.Request.Experiences.CreateRequest, Experience>();
                configuration.CreateMap<Dtos.Request.Experiences.UpdateRequest, Experience>();

                configuration.CreateMap<Project, ProjectDto>();
                configuration.CreateMap<ProjectDto, Project>();
                configuration.CreateMap<Dtos.Request.Projects.CreateRequest, Project>();
                configuration.CreateMap<Dtos.Request.Projects.UpdateRequest, Project>();

                configuration.CreateMap<Degree, DegreeDto>();
                configuration.CreateMap<DegreeDto, Degree>();
                configuration.CreateMap<Dtos.Request.Degrees.CreateRequest, Degree>();
                configuration.CreateMap<Dtos.Request.Degrees.UpdateRequest, Degree>();
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            return services;
        }

        public static IServiceCollection AddConfigurationOptions(this IServiceCollection services)
        {
            services.Configure<RouteOptions>(options =>
            {
                options.LowercaseUrls = true;
            });

            return services;
        }

        public static IServiceCollection AddCorsPolicy(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(configuration.GetSection("CorsPolicy:Name").Get<string>(), configurePolicy =>
                {
                    configurePolicy.WithOrigins(configuration.GetSection("CorsPolicy:Urls").Get<string[]>())
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials();
                });
            });

            return services;
        }
    }
}
