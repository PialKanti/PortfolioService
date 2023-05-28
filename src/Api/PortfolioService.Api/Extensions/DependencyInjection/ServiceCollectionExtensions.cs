using AutoMapper;
using PortfolioService.Api.Dtos.Request;
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
                var database = "portfolio_db";
                return new MongoClientService(connectionString, database);
            });

            return services;
        }

        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IExperienceRepository<Experience>, ExperienceRepository>();

            return services;
        }

        public static IServiceCollection AddAutoMappers(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(configuration =>
            {
                configuration.CreateMap<Experience, ExperienceDto>();
                configuration.CreateMap<ExperienceCreateRequest, Experience>();
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            return services;
        }
    }
}
