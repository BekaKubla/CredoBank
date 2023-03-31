using AutoMapper;
using KredoBank.Application.Statements.Commands.CreateStatement;
using KredoBank.Application.Statements.Commands.UpdateStatement;
using KredoBank.Application.Statements.Queries.GetStatement;
using KredoBank.Application.Users.Commands.CreateUser;
using KredoBank.Application.Users.Queries.LogInUser;
using KredoBank.Domain.Entity.Statement;

namespace KredoBank.Infrastructure.Persistence.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CreateUserCommandModel, CreateUserCommand>();
            CreateMap<Statements, GetStatementResultModel>();
            CreateMap<LogInUserQueryModel, LogInUserQuery>();
            CreateMap<CreateStatementCommandModel, CreateStatementCommand>();
            CreateMap<UpdateStatementCommandModel, UpdateStatementCommand>();
        }
    }
}
