using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRASPPrinciples._04_InformationExpert
{
  public enum TransactionTypes
  {
    Deposit,
    WithDraw
  }

  // Hesap Döküm
  public class AccountTransaction
  {
    public decimal Amount { get; init; } //( +, -)
    public int TransactionType { get; init; }

    public DateTime ProcessAt { get; init; }

    public AccountTransaction(decimal amount, TransactionTypes transactionType)
    {
      this.Amount = amount;
      this.TransactionType = (int)transactionType;
      this.ProcessAt = DateTime.Now;

    }

  }
}
