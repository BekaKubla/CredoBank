using MediatR;

namespace KredoBank.Application.Users.Queries.LogInUser
{
    public class LogInUserQuery : IRequest<string>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
