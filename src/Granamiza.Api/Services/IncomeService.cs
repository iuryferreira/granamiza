using Granamiza.Api.Infra.Repositories;
using Granamiza.Api.Models;
using Notie.Contracts;
using static Granamiza.Shared.Dtos.Requests;
using static Granamiza.Shared.Dtos.Responses;

namespace Granamiza.Api.Services
{
    public interface IIncomeService
    {
        Task<AddIncomeResponse?> Add (AddIncomeRequest data);
        Task<List<IncomeResponse>> All ();
    }

    class IncomeService : IIncomeService
    {

        private readonly INotifier _notifier;
        private readonly IIncomeRepository _repository;


        public IncomeService (INotifier notifier, IIncomeRepository repository)
        {
            _notifier = notifier;
            _repository = repository;
        }

        public async Task<AddIncomeResponse?> Add (AddIncomeRequest data)
        {

            var entity = new Income(data.Title, data.Value);

            if (!entity.Valid)
            {
                _notifier.AddNotificationsByFluent(entity.ValidationResult);
                return null;
            }

            await _repository.Add(entity);
            return new AddIncomeResponse(entity.Id, entity.Title, entity.Value, entity.CreatedAt);
        }

        public async Task<List<IncomeResponse>> All ()
        {
            var entities = await _repository.All();
            return entities.Select(x => new IncomeResponse(x.Id, x.Title, x.Value, x.CreatedAt)).ToList();
        }
    }
}
