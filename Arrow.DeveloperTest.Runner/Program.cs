using Arrow.DeveloperTest.Data;
using Arrow.DeveloperTest.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace Arrow.DeveloperTest.Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();


            var service = host.Services.GetService<IPaymentService>();

            var resultPayment = service.MakePayment(new Types.MakePaymentRequest()
            {
                Amount = 100,
                CreditorAccountNumber = "1010",
                DebtorAccountNumber = "1032",
                PaymentDate = DateTime.Now,
                PaymentScheme = Types.PaymentScheme.FasterPayments
            });

            Console.WriteLine(resultPayment.Success);
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args).ConfigureServices(services =>
            {
                services.AddSingleton<IPaymentService, PaymentService>();
                services.AddSingleton<IStrategyPaymentSchemes, BacsPayment>();
                services.AddSingleton<IStrategyPaymentSchemes, ChapsPayment>();
                services.AddSingleton<IStrategyPaymentSchemes, FasterPayments>();
                services.AddSingleton<IAccountDataStore, AccountDataStore>();
            });

        }
    }
}
