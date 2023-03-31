using KredoBank.Application.Common;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace KredoBank.Application.Statements.Commands.DeleteStatement
{
    public class DeleteStatementCommand : IRequest<ResultModel>
    {
        [Required]
        public int? StatementId { get; set; }
    }
}
