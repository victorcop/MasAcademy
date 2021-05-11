using MasAcademyLab.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MasAcademyLab.Data.Repositories
{
    public interface ISpeakerRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<List<Speaker>> GetAllSpeakersAsync();
        Task<Speaker> GetSpeakerAsync(int speakerId);
        Task<List<Speaker>> GetSpeakersByCodeAsync(string code);
        Task<int> SaveChangesAsync();
    }
}
