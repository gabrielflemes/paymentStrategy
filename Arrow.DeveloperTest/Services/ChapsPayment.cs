using Arrow.DeveloperTest.Types;

namespace Arrow.DeveloperTest.Services
{
    public class ChapsPayment : IStrategyPaymentSchemes
    {
        public PaymentScheme PaymentScheme => PaymentScheme.Chaps;

        public MakePaymentResult DoPayment(Account account, MakePaymentResult result, MakePaymentRequest request = null)
        {
            if (account == null)
                result.Success = false;
            else if (!account.AllowedPaymentSchemes.HasFlag(AllowedPaymentSchemes.Chaps))
                result.Success = false;
            else if (account.Status != AccountStatus.Live)
                result.Success = false;
            else
                result.Success = true;

            return result;
        }
    }
}