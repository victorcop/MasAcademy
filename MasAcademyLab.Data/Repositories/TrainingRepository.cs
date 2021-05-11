using MasAcademyLab.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasAcademyLab.Data.Repositories
{
    public class TrainingRepository : GenericRepository, ITrainingRepository
    {
        private readonly MasAcademyLabContext _context;
        private readonly ILogger<TrainingRepository> _logger;

        public TrainingRepository(MasAcademyLabContext context, ILogger<TrainingRepository> logger) : base(context, logger)
        {
            _context = context;
            _logger = logger;
        }        

        public Task<List<Training>> GetAllTrainingByEventDate(DateTime dateTime, bool includeTalks = false)
        {
            _logger.LogInformation($"Getting all Training");

            IQueryable<Training> query = _context.Trainings
                .Include(c => c.Location);

            if (includeTalks)
            {
                query = query
                  .Include(c => c.Talks)
                  .ThenInclude(t => t.Speaker);
            }

            // Order It
            query = query.OrderByDescending(c => c.EventDate)
              .Where(c => c.EventDate.Date == dateTime.Date);

            return query.ToListAsync();
        }

        public Task<List<Training>> GetAllTrainingsAsync(bool includeTalks = false)
        {
            _logger.LogInformation($"Getting all Training");

            IQueryable<Training> query = _context.Trainings
                .Include(c => c.Location);

            if (includeTalks)
            {
                query = query
                  .Include(c => c.Talks)
                  .ThenInclude(t => t.Speaker);
            }

            // Order It
            query = query.OrderByDescending(c => c.EventDate);

            return query.ToListAsync();
        }

        public Task<Training> GetTrainingAsync(string code, bool includeTalks = false)
        {
            _logger.LogInformation($"Getting a Training for {code}");

            IQueryable<Training> query = _context.Trainings
                .Include(c => c.Location);

            if (includeTalks)
            {
                query = query.Include(c => c.Talks)
                  .ThenInclude(t => t.Speaker);
            }

            // Query It
            query = query.Where(c => c.Code == code);

            return query.FirstOrDefaultAsync();
        }
    }
}
