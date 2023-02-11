using System.ComponentModel.DataAnnotations;

namespace MicroFIN.Core.Contracts;

public enum AccountType
{
    Default = 1,
    Investor = 2,
    Customer = 3,
    Agent = 4,
    Expense = 5,
    Diary = 6
}

public enum TransactionType
{
    [Display(Description = "Opening Balance")]
    OpningBalance = 1,
    [Display(Description = "Add Fund")]
    AddFund = 2,
    [Display(Description = "Transfer Fund")]
    Transfer = 3,
    [Display(Description = "Dairy Payment")]
    DairyPayment = 4,
    [Display(Description = "Withdrawal Fund")]
    WithdrawalFund = 5,
}