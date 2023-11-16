using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRASPPrinciples._01_Cohesion
{
  public class LowCohesionOrderSample // OrderService
  {
    /// <summary>
    /// Sipariş işlemini başlatırız. Promosyon kodumuz varsa indirim uygulanır.
    /// </summary>
    /// <param name="order"></param>
    /// <param name="promationCode"></param>
    public void SubmitOrder(Order order, string promationCode)
    {
      // sipariş kaydet
      // varsa promosyonkoduna göre indirim yap
      // siparişi e-posta ile bildir.
      // orderCodeGenerator
      ApplyPromationCode(promationCode);
      string code = GenerateOrderCode();
      order.Code = code;
      Save(order);
      SendEmail(order.CustomerName, "Sipariş oluştu");
    }

    private void ApplyPromationCode(string code)
    {

    }

    private string GenerateOrderCode()
    {
      return "XXXX";
    }
    private void Save(Order order)
    {

    }

    private void SendEmail(string to, string message)
    {

    }
  }
}
