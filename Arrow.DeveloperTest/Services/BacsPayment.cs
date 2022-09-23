using Arrow.DeveloperTest.Types;

namespace Arrow.DeveloperTest.Services
{
    public class BacsPayment : IStrategyPaymentSchemes
    {
        public PaymentScheme PaymentScheme => PaymentScheme.Bacs;

        public MakePaymentResult DoPayment(Account account, MakePaymentResult result, MakePaymentRequest request = null)
        {
            if (account == null)
                result.Success = false;
            else if (!account.AllowedPaymentSchemes.HasFlag(AllowedPaymentSchemes.Bacs))
                result.Success = false;
            else
                result.Success = true;

            return result;
        }
    }
}