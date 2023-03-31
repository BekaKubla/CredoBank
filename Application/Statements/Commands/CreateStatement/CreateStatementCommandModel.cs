using System;

namespace KredoBank.Application.Statements.Commands.CreateStatement
{
    public class CreateStatementCommandModel
    {
        public int? LoanType { get; set; }
        public decimal? Amount { get; set; }
        public int? Currency { get; set; }
        public DateTime? Periodus { get; set; }
        public int? StatementStatus { get; set; }
    }
}
