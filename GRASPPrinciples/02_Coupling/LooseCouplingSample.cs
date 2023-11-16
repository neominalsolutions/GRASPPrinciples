using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRASPPrinciples._02_Coupling
{
  public interface ISmsProvider
  {
    void SendSms(string to, string message);
  }

  public interface IRepository<TEntity>
  {
    void Save(TEntity entity);
  }

  public class TurkcelSmsService : ISmsProvider
  {
    public void SendSms(string to, string message)
    {
      Console.WriteLine("Türkcell Sms Service");
    }
  }

  public class SendGridSmsService : ISmsProvider
  {
    public void SendSms(string to, string message)
    {
      Console.WriteLine("SendGrid Sms Service");
    }
  }

  public class Product
  {

  }

  public class AdoNetProductRepository : IRepository<Product>
  {
    public void Save(Product entity)
    {
      Console.WriteLine("Adonet ile kayıt");
    }
  }

  public class DapperProductRepository : IRepository<Product>
  {
    public void Save(Product entity)
    {
      Console.WriteLine("Dapper ile kayıt");
    }
  }

  public class LooseCouplingSample
  {
    // Dependecy Inversion Principle
    // iki sınıf arasındaki bağlantıyı arayüzler üzerinden yönteme prensibi
    private ISmsProvider smsProvider;
    private IRepository<Product> productRepository;

    // constructor üzerinden instanceların servislere enjecte edilmesine Dependecy Injection ismini veriyoruz.
    public LooseCouplingSample(ISmsProvider smsProvider, IRepository<Product> repository)
    {
      this.smsProvider = smsProvider;
      this.productRepository = repository;
    }

    public void Handle()
    {
      smsProvider.SendSms("ali", "merhaba");
      productRepository.Save(new Product());
    }

  }
}
