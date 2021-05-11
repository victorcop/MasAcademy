using AutoMapper;
using MasAcademyLab.Data.Extention;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace MasAcademyLab.Service.Extention
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServiceDependencies(
           this IServiceCollection services,
           IConfiguration configuration)
        {
            services.AddDataDependencies(configuration);
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<ITrainingService, TrainingService>();
            services.AddScoped<ITalkService, TalkService>();
            return services;
        }
    }
}
