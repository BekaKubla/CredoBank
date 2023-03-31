using MediatR;
using System.Collections.Generic;

namespace KredoBank.Application.Statements.Queries.GetStatement
{
    public class GetStatementQuery : IRequest<List<GetStatementResultModel>>
    {

    }
}
