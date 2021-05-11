using MasAcademyLab.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MasAcademyLab.Data.Extention
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDataDependencies(
           this IServiceCollection services,
           IConfiguration configuration)
        {
            services.AddDbContext<MasAcademyLabContext>(opt =>
                opt.UseSqlServer(configuration.GetConnectionString("MasAcademyLab"))
            );
            services.AddScoped<ITrainingRepository, TrainingRepository>();
            services.AddScoped<ISpeakerRepository, SpeakerRepository>();
            services.AddScoped<ITalkRepository, TalkRepository>();
            return services;
        }
    }
}
