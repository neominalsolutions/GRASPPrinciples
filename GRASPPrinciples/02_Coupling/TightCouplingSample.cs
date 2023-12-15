using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRASPPrinciples._02_Coupling
{
  public class SendGridSmsProvider // SENDGRID -> TurkcellSmsProvider
  {
    public void SendSms(string to, string message) { }
  }

  public class AdoNetRepository // ADONET -> Dapper
  {
    public void Save() { }
  }

  public class TurkcellSmsProvider
  {
    public void SendSms(string to, string message) { }
  }

  public class DapperRepository
  {
    public void Save() { }
  }

  public class TightCouplingSample
  {
    // bir sınıf başka bir sınıfın referansı direk olarak kullanırsa sınıflar arasında yada moduüller arasında sıkı sıkıya bağlılık oluşur. Bu durumda code refactoring sürecine girmemiz gerekir. 
    private TurkcellSmsProvider emailService;
    private DapperRepository repository;

    public TightCouplingSample()
    {
      emailService = new TurkcellSmsProvider();
      repository = new DapperRepository();
    }

    public void Handle()
    {
      repository.Save();
      Console.WriteLine("Handle");
    }
  }
}
