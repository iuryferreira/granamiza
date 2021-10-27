using Granamiza.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Granamiza.Api.Infra.Repositories
{
    interface IIncomeRepository
    {
        Task Add (Income entity);
        Task<List<Income>> All ();
    }

    class IncomeRepository : IIncomeRepository
    {
        private readonly Context _context;
        private readonly ILogger<IncomeRepository> _logger;

        public IncomeRepository (Context context, ILogger<IncomeRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task Add (Income entity)
        {
            try
            {
                await _context.Incomes.AddAsync(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "There was an error inserting data into the database.");
                throw new Exception("There was an error inserting data into the database.", ex);
            }
        }

        public async Task<List<Income>> All ()
        {
            try
            {
                return await _context.Incomes.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "There was an error inserting data into the database.");
                throw new Exception("There was an error inserting data into the database.", ex);
            }
        }
    }
}
