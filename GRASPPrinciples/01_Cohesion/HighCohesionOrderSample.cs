using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRASPPrinciples._01_Cohesion
{
  public class EmailService // reuseablelity // DRY (Dont repeat yourself)
  {
    public void SendEmail(string to, string message) { }
  }

  // Single Resposibity
  public class OrderRepository
  {
    public void Save(Order order) { }
  }

  public class DiscountService
  {
    public decimal ApplyPromationCode(string code) {
      return 1; 
    }
  }

  public class HighCohesionOrderSample
  {
    // Kompleks iş süreçlerin yönetecek olan manager sınıflar ile alt hizmet sınıflarına bağlanma yöntemiine facade design pattern ismi verilir.
    // facade
    private readonly EmailService emailService;
    private readonly OrderRepository orderRepository;
    private readonly DiscountService discountService;

    public HighCohesionOrderSample()
    {
      emailService = new EmailService();
      orderRepository = new OrderRepository();
      discountService = new DiscountService();
    }

    private string GenerateCode()
    {
      return "sdsdsa";
    }
    public void SubmitOrder(Order order,string promationCode)
    {
      string code = GenerateCode();
      order.Code = code;
      decimal totalDiscountedPrice = discountService.ApplyPromationCode(promationCode);
      orderRepository.Save(order);
      emailService.SendEmail(order.CustomerName, "Sipariş oluştu");
    }
  }
}
