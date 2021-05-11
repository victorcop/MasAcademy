using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace MasAcademyLab.Data.Repositories
{
    public abstract class GenericRepository
    {
        private readonly MasAcademyLabContext _context;
        private readonly ILogger<TrainingRepository> _logger;

        public GenericRepository(MasAcademyLabContext context, ILogger<TrainingRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public void Add<T>(T entity) where T : class
        {
            _logger.LogInformation($"Adding an object of type {entity.GetType()} to the context.");
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _logger.LogInformation($"Removing an object of type {entity.GetType()} to the context.");
            _context.Remove(entity);
        }

        public Task<int> SaveChangesAsync()
        {
            _logger.LogInformation($"Attempitng to save the changes in the context");

            // Only return success if at least one row was changed
            return _context.SaveChangesAsync();
        }
    }
}
