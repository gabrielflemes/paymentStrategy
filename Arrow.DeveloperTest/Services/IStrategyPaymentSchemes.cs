using Arrow.DeveloperTest.Types;

namespace Arrow.DeveloperTest.Services
{
    public interface IStrategyPaymentSchemes
    {
        PaymentScheme PaymentScheme { get; }

        MakePaymentResult DoPayment(Account account, MakePaymentResult result, MakePaymentRequest request = null);
    }
}