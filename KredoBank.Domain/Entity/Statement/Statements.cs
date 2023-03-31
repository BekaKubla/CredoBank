using KredoBank.Domain.Entity.User;
using KredoBank.Domain.Enum;
using System;
using System.Text.Json.Serialization;

namespace KredoBank.Domain.Entity.Statement
{
    public class Statements
    {
        public Statements(LoanType? loanType, decimal? amount, Currency? currency, DateTime? periodus, StatementStatus? statementStatus)
        {
            CreateStatementDate = DateTime.Now;
            LoanType = loanType;
            Amount = amount;
            Currency = currency;
            Periodus = periodus;
            StatementStatus = statementStatus;
        }
        public int Id { get; private set; }
        public DateTime CreateStatementDate { get; private set; }
        public bool IsActive { get; private set; }
        public bool IsDeleted { get; private set; }
        public LoanType? LoanType { get; private set; }
        public decimal? Amount { get; private set; }
        public Currency? Currency { get; private set; }
        public DateTime? Periodus { get; private set; }
        public StatementStatus? StatementStatus { get; private set; }

        public int UserId { get; private set; }
        public virtual Users User { get; private set; }

        public static Statements CreateStatement(LoanType? loanType,
                                                decimal? amount,
                                                Currency? currency,
                                                DateTime? periodus,
                                                StatementStatus? statementStatus) => new(loanType,
                                                                                         amount,
                                                                                         currency,
                                                                                         periodus,
                                                                                         statementStatus);

        public void DeleteStatement()
        {
            IsActive = false;
            IsDeleted = true;
        }

        public void UpdateStatement(LoanType? loanType,
                                    decimal? amount,
                                    Currency? currency,
                                    DateTime? periodus,
                                    StatementStatus? statementStatus)
        {
            LoanType = loanType;
            Amount = amount;
            Currency = currency;
            Periodus = periodus;
            StatementStatus = statementStatus;
        }
    }
}
