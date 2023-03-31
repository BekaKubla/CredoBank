using System;
using System.ComponentModel.DataAnnotations;

namespace KredoBank.Application.Statements.Commands.UpdateStatement
{
    public class UpdateStatementCommandModel
    {
        [Required]
        public int? Id { get; set; }
        public DateTime? CreateStatementDate { get; set; }
        public int? LoanType { get; set; }
        public decimal? Amount { get; set; }
        public int? Currency { get; set; }
        public DateTime? Periodus { get; set; }
        public int? StatementStatus { get; set; }
    }
}
