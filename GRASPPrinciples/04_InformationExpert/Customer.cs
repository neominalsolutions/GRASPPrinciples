using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRASPPrinciples._04_InformationExpert
{
  public class Customer
  {
    public string Name { get; set; }
    public string SurName { get; set; }
    private List<Account> accounts = new List<Account>();
    public IReadOnlyList<Account> Accounts => accounts;

    //public List<Account> Accounts { get; set; }

    // OpenAccount ve CloseAccount gibi iki farklı method davranış ile customer nesnesine Account nesnesinin yöntemi sorumluluğu devrediyoruz. Information Expert uygulamış oluyor. 

    /// <summary>
    /// Hesap açlışı işlemi
    /// </summary>
    /// <param name="accountNumber"></param>
    public void OpenNewAccount(string accountNumber)
    {
      accounts.Add(new Account(accountNumber));
    }
    /// <summary>
    /// Hesabı şu nedenle kapatıyoruz
    /// </summary>
    /// <param name="reason"></param>
    /// <param name="accountNumber"></param>
    public void CloseAccount(string reason, string accountNumber)
    {
      var account = accounts.Find(x => x.Number == accountNumber);
      if(account is not null)
      {
        account.Close(reason);
      }
    }

    public Account GetCurrentAccount(string accountNumber)
    {
     var currentAccount = accounts.Find(x => x.Number == accountNumber);

      if (currentAccount is not null)
        return currentAccount;
      else
      {
        throw new Exception("Account is not exists");
      }
      
    }

  }
}
