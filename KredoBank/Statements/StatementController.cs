using AutoMapper;
using KredoBank.Application.Statements.Commands.CreateStatement;
using KredoBank.Application.Statements.Commands.DeleteStatement;
using KredoBank.Application.Statements.Commands.UpdateStatement;
using KredoBank.Application.Statements.Queries.GetStatement;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace KredoBank.API.Statements
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class StatementController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public StatementController(IMediator mediator,
                                   IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetStatementById()
        {

            var result = await _mediator.Send(new GetStatementQuery());
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateStatement([FromBody] CreateStatementCommandModel command)
        {
            var requestModel = _mapper.Map<CreateStatementCommand>(command);
            var result = await _mediator.Send(requestModel);
            return Ok(result.ResultMessage);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteStatement([FromQuery] DeleteStatementCommand command)
        {
            var requestModel = new DeleteStatementCommand { StatementId = command.StatementId };
            var result = await _mediator.Send(requestModel);
            return Ok(result.ResultMessage);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateStatement([FromBody] UpdateStatementCommandModel command)
        {
            var requestModel = _mapper.Map<UpdateStatementCommand>(command);
            var result = await _mediator.Send(requestModel);
            return Ok(result.ResultMessage);
        }
    }
}
