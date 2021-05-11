using MasAcademyLab.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MasAcademyLab.Data.Repositories
{
    public interface ITalkRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<Talk> GetTalkByCodeAsync(string code, int talkId, bool includeSpeakers = false);
        Task<List<Talk>> GetTalksByCodeAsync(string code, bool includeSpeakers = false);
        Task<int> SaveChangesAsync();
    }
}
