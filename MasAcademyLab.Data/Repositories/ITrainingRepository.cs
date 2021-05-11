using MasAcademyLab.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MasAcademyLab.Data.Repositories
{
    public interface ITrainingRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<List<Training>> GetAllTrainingsAsync(bool includeTalks = false);
        Task<List<Training>> GetAllTrainingByEventDate(DateTime dateTime, bool includeTalks = false);
        Task<Training> GetTrainingAsync(string code, bool includeTalks = false);
        Task<int> SaveChangesAsync();
    }
}