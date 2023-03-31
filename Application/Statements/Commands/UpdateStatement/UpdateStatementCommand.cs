using KredoBank.Application.Common;
using KredoBank.Domain.Enum;
using MediatR;
using System;
using System.ComponentModel.DataAnnotations;

namespace KredoBank.Application.Statements.Commands.UpdateStatement
{
    public class UpdateStatementCommand : IRequest<ResultModel>
    {
        [Required]
        public int? Id { get; set; }
        public DateTime? CreateStatementDate { get; set; }
        public LoanType? LoanType { get; set; }
        public decimal? Amount { get; set; }
        public Currency? Currency { get; set; }
        public DateTime? Periodus { get; set; }
        public StatementStatus? StatementStatus { get; set; }
    }
}
