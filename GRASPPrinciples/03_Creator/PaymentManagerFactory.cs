using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRASPPrinciples._03_Creator
{

  public interface IPayment
  {
    void Pay(double amount);
  }

  public class CreditCardPayment : IPayment
  {
    public void Pay(double amount)
    {
      Console.WriteLine("Kredi kartı ile ödeme");
    }
  }

  public class CachePayment : IPayment
  {
    public void Pay(double amount)
    {
      Console.WriteLine("nakit ödeme");
    }
  }

  public class CoinPayment : IPayment
  {
    public void Pay(double amount)
    {
      Console.WriteLine("Coin ödeme");
    }
  }

  // Open-Closed Principle => Bir kod blogu değişeme kapalı gelişime açık olmalıdır. 

  public enum PaymentType
  {
    CreditCard,
    Cache

  }

  // factory sınıflarının görevi aynı arayüzden türeyen farklı sınıf instancelarının yöntemini sağlamak.
  public static class PaymentManagerFactory
  {

    public static IPayment GetInstance(PaymentType paymentType)
    {
      if (paymentType == PaymentType.Cache)
        return new CachePayment();
      else if (paymentType == PaymentType.CreditCard)
        return new CreditCardPayment();

      // default Behavior
      return new CreditCardPayment();
          
    }

  }
}
