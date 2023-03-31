using KredoBank.Application.Common;
using KredoBank.Domain.Enum;
using MediatR;
using System;

namespace KredoBank.Application.Statements.Commands.CreateStatement
{
    public class CreateStatementCommand : IRequest<ResultModel>
    {
        public LoanType? LoanType { get; set; }
        public decimal? Amount { get; set; }
        public Currency? Currency { get; set; }
        public DateTime? Periodus { get; set; }
        public StatementStatus? StatementStatus { get; set; }

    }
}
