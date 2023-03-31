using AutoMapper;
using KredoBank.Application.Users.Commands.CreateUser;
using KredoBank.Application.Users.Queries.LogInUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace KredoBank.API.Users
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public UserController(IMediator mediator,
                              IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> UserRegistration([FromBody] CreateUserCommandModel command)
        {
            var requestModel = _mapper.Map<CreateUserCommand>(command);
            var userResult = await _mediator.Send(requestModel);
            return Ok(userResult.ResultMessage);
        }

        [HttpPost("LogIn")]
        public async Task<IActionResult> UserLogIn([FromBody] LogInUserQueryModel query)
        {
            var requestModel = _mapper.Map<LogInUserQuery>(query);
            var userResult = await _mediator.Send(requestModel);
            return Ok(userResult);
        }
    }
}
