using MasAcademyLab.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasAcademyLab.Data.Repositories
{
    public class SpeakerRepository : GenericRepository, ISpeakerRepository
    {
        private readonly MasAcademyLabContext _context;
        private readonly ILogger<TrainingRepository> _logger;

        public SpeakerRepository(MasAcademyLabContext context, ILogger<TrainingRepository> logger) : base(context, logger)
        {
            _context = context;
            _logger = logger;
        }

        public Task<List<Speaker>> GetSpeakersByCodeAsync(string code)
        {
            _logger.LogInformation($"Getting all Speakers for a Training");

            IQueryable<Speaker> query = _context.Talks
              .Where(t => t.Training.Code == code)
              .Select(t => t.Speaker)
              .Where(s => s != null)
              .OrderBy(s => s.LastName)
              .Distinct();

            return query.ToListAsync();
        }

        public Task<List<Speaker>> GetAllSpeakersAsync()
        {
            _logger.LogInformation($"Getting Speaker");

            var query = _context.Speakers
              .OrderBy(t => t.LastName);

            return query.ToListAsync();
        }

        public Task<Speaker> GetSpeakerAsync(int speakerId)
        {
            _logger.LogInformation($"Getting Speaker");

            var query = _context.Speakers
              .Where(t => t.SpeakerId == speakerId);

            return query.FirstOrDefaultAsync();
        }
    }
}
