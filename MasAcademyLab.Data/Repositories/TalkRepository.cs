using MasAcademyLab.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasAcademyLab.Data.Repositories
{
    public class TalkRepository : GenericRepository, ITalkRepository
    {
        private readonly MasAcademyLabContext _context;
        private readonly ILogger<TrainingRepository> _logger;

        public TalkRepository(MasAcademyLabContext context, ILogger<TrainingRepository> logger) : base(context, logger)
        {
            _context = context;
            _logger = logger;
        }

        public Task<List<Talk>> GetTalksByCodeAsync(string code, bool includeSpeakers = false)
        {
            _logger.LogInformation($"Getting all Talks for a Training");

            IQueryable<Talk> query = _context.Talks;

            if (includeSpeakers)
            {
                query = query
                  .Include(t => t.Speaker);
            }

            // Add Query
            query = query
              .Where(t => t.Training.Code == code)
              .OrderByDescending(t => t.Title);

            return query.ToListAsync();
        }

        public Task<Talk> GetTalkByCodeAsync(string code, int talkId, bool includeSpeakers = false)
        {
            _logger.LogInformation($"Getting all Talks for a Training");

            IQueryable<Talk> query = _context.Talks;

            if (includeSpeakers)
            {
                query = query
                  .Include(t => t.Speaker);
            }

            // Add Query
            query = query
              .Where(t => t.TalkId == talkId && t.Training.Code == code);

            return query.FirstOrDefaultAsync();
        }
    }
}
