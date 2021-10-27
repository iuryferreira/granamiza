using Granamiza.Api.Models;
using Granamiza.Api.Services;
using Microsoft.AspNetCore.Mvc;
using Notie.Contracts;
using static Granamiza.Shared.Dtos.Requests;
using static Granamiza.Shared.Dtos.Responses;

namespace Granamiza.Api.Controllers.v1
{

    [ApiController]
    [Route("api/v1/incomes")]
    public class IncomesController : ControllerBase
    {
        private readonly IIncomeService _service;
        private readonly INotifier _notifier;

        public IncomesController (IIncomeService service, INotifier notifier)
        {
            _service = service;
            _notifier = notifier;
        }

        [HttpGet]
        public async Task<ActionResult<List<IncomeResponse>>> All ()
        {
            return Ok(await _service.All());
        }

        [HttpPost]
        public async Task<ActionResult<AddIncomeResponse>> Store (AddIncomeRequest data)
        {
            var result = await _service.Add(data);
            if (_notifier.HasNotifications()) return BadRequest(_notifier.All());
            return Created($"/v1/incomes/{result?.Id}", result);
        }

    }
}
