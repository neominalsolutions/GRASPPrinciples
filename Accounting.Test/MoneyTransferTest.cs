using GRASPPrinciples._04_InformationExpert;

namespace Accounting.Test
{
  public class MoneyTransferTest
  {
    Account account = new Account("324324");
    
    public MoneyTransferTest()
    {
      account.SetBalance(150000);
    }


    [Fact] // method bir parametere almıyor fact
    // Parametreli çalışıyorsa Teory
    public void AccountBlockedTest() // TestCase
    {
      // Arrange (test için gerekli bileşenleri hazırlandığı yer.)
      Account account = new Account("12345");
      account.SetBalance(50000);
      account.MakeAccountBlocked("Bloke");

      // Act (test tabi tutulacak fonskiyon çağırımı yaptığımız yer)
      account.WithDraw(10000);

      // Assert (expected value, actual value kıyaslaması);

      Assert.Equal(account.Balance, 40000M);
      //Assert.True(account.IsBlocked == false);
      
    }

    // Hesaptan farklı değerler gönderilerek para çekeliebiliyor mu testi

    [Theory]
    [InlineData(10000,140000)]
    [InlineData(70000, 70000)]
    [InlineData(50000,20000)]
    // [InlineData(30000, -10000)]
    public void DailyWithDrawLimitedTest(decimal amount, decimal balance)
    {
      // Arrange // Global Olarak işaretledik
    
      // act
      account.WithDraw(amount);

      // Assert
      Assert.True(account.Balance > 0);

    }

    [Fact]
    public void DailyWithDrawLimitedTest2()
    {
      // Arrange // Global Olarak işaretledik

      // act
      account.WithDraw(10000);
      account.WithDraw(70000);
      account.WithDraw(50000);

      // Assert
      Assert.True(account.Balance > 0);

    }
  }
}