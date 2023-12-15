// See https://aka.ms/new-console-template for more information
using GRASPPrinciples._02_Coupling;
using GRASPPrinciples._03_Creator;
using GRASPPrinciples._04_InformationExpert;
using Microsoft.Extensions.DependencyInjection;

Console.WriteLine("Hello, World!");


#region LooseCouplingSample

// IoC => Inversion Of Control
// instance kontrollerinin developerdan framework devredilmesi artık buradaki sürecin tersine çevirlmesi anlamına geliyor. 
// IoC Container yapıları ile sistemdeki kullanılan servisler Framework'e tanıtılıyor. Register etme aşaması
// Daha sonrasında register edilen serviceler sistem tarafında resolve edilip ilgili sınıfların içerisine instanceları geçişi sağlanıyor.

var container = new ServiceCollection();
container.AddTransient<IRepository<Product>, DapperProductRepository>(); // register işlemi
container.AddTransient<ISmsProvider, SendGridSmsService>();
//container.AddTransient<ISmsProvider, TurkcelSmsService>();

// merkezi olarak uygulamanın teknoloji bağımlılıklarını tek bir dosyadan yönetebileceğimiz bir yapıdır, IoC 

var provider = container.BuildServiceProvider(); // bunları framework'e tanıt.

//var repo = new AdoNetProductRepository();
//var smsProvider = new TurkcelSmsService();

// with IoC
var repo = provider.GetRequiredService<IRepository<Product>>(); // resolve işlemi ilgili register edilen servisin instance'a service provider üzerinden eriştik.
var smsProvider = provider.GetRequiredService<ISmsProvider>();


LooseCouplingSample looseCouplingSample = new LooseCouplingSample(smsProvider, repo);
looseCouplingSample.Handle();

#endregion


#region CreatorSample

// Factory Method Creational Design Pattern
// PaymentManagerFactory bir instance üretme sorumluluğu verdik.
var payment1 = PaymentManagerFactory.GetInstance(PaymentType.Cache);
payment1.Pay(50);
PaymentManagerFactory.GetInstance(PaymentType.CreditCard).Pay(50);

#endregion
// Creator Sample


#region InformationExpertSample

Customer c = new Customer();
c.Name = "Ali";
c.SurName = "Tan";
// Information Expert
c.OpenNewAccount("324232-234324-324324324");
c.CloseAccount("Musteri Farklı bankaya geçiş yapıyor", "324232-234324-324324324");


#endregion

#region LawOfDemetter

// Müşteri olarak 324232-234324-324324324 nolu account ait hesap döküm bilgilerine erişmek istiyorum ?
//c.Accounts.FirstOrDefault(x => x.Number == "324232-234324-324324324").Transactions.ToList();
//c.Accounts.FirstOrDefault(x => x.Number == "324232-234324-324324324").Close("Kapanış");
//c.Accounts.FirstOrDefault(x => x.Number == "324232-234324-324324324").Transactions.Add(new AccountTransaction(5, TransactionTypes.WithDraw));

//c.Accounts.Add(new Account("234324324"));
Customer customer = new Customer();
customer.Accounts.ToList(); // ReadOnly

var currentAccount = customer.GetCurrentAccount("234324324"); // CurrentAccount
currentAccount.MakeAccountBlocked("Deneme"); // currentAccount blokladık.
// Repo.update(currenAccount);
currentAccount.GetTransactionsBetween(DateTime.Now, DateTime.Now.AddDays(7)); // 1 haftalık dökümü getir.


#endregion

