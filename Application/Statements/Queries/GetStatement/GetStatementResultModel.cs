using System;

namespace KredoBank.Application.Statements.Queries.GetStatement
{
    public class GetStatementResultModel
    {
        public int Id { get; set; }
        public int? LoanType { get; set; }
        public decimal? Amount { get; set; }
        public int? Currency { get; set; }
        public DateTime? Periodus { get; set; }
        public int? StatementStatus { get; set; }
    }
}
