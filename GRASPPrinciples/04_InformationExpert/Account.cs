using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRASPPrinciples._04_InformationExpert
{
  // code defensing developer kod yanlış müdehalerini engellemek amaçlı yapılan teknikler.
  public class Account
  {
    private List<AccountTransaction> transactions = new List<AccountTransaction>();

    public string Number { get; init; }
    public decimal Balance { get; private set; }

    // public List<AccountTransaction> Transactions { get; set; }
    public bool IsBlocked { get; private set; } // Bloke mi
    public string BlockedReason { get; private set; }
    public DateTime BlockedAt { get; private set; }
    public bool IsClosed { get; private set; }
    public string CloseReason { get; private set; }
    public DateTime ClosedAt { get; private set; }

    // Nenslere birbilerine çift taraflı çok gerekmedikçe bağlanmamlı bu davranıştan kaçınılmalı gereksiz yere nesne instanceların program tarfında çekilmesinin önüne geçilmeli ve kodu okunabirliğini azalmasının önüne geçilmelidir. 
    //public Customer Customer { get; set; }

    public void SetBalance(decimal balance)
    {
      Balance = balance;
    }

    public Account(string accountNumber)
    {
      Number = accountNumber;
      Balance = 0; // Yeni bir account oluşumunda bakiye 0 olarak set edilir.
      IsBlocked = false;
    }

    /// <summary>
    /// Para çekme işlemini Account sınıfına devrettik.
    /// Günlük para çekme limit 100.000
    /// </summary>
    /// <param name="amount"></param>
    public void WithDraw(decimal amount)
    {
      if (IsBlocked)
      {
        throw new Exception("Hesap blokeli para çekilmez");
      }

      if(amount < 0)
      {
        throw new Exception("Miktar pozitid değer olmalıdır");
      }

      decimal dailyTransactionAmountTotal = transactions.Where( x=> x.ProcessAt.Date == DateTime.Now.Date && x.TransactionType == (int)(TransactionTypes.WithDraw)).Sum(x => x.Amount);

      if((dailyTransactionAmountTotal + amount) > 100000)
      {
        throw new Exception("Günlük para çekme limitini aştınız");
      }


      transactions.Add(new AccountTransaction(amount,TransactionTypes.WithDraw));

      Balance -= amount;

    }



    public void MakeAccountBlocked(string reason)
    {
      IsBlocked = true;
      BlockedReason = reason;
      BlockedAt = DateTime.Now;
    }

    public void Close(string closeReason)
    {
      IsClosed = true;
      CloseReason = closeReason;
      ClosedAt = DateTime.Now;
    }

    public IReadOnlyList<AccountTransaction> GetTransactionsBetween(DateTime startDate, DateTime endDate)
    {
      return transactions;
    }
  }
}
