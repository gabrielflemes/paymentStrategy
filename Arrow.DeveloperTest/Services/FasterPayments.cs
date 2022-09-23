using Arrow.DeveloperTest.Types;

namespace Arrow.DeveloperTest.Services
{
    public class FasterPayments : IStrategyPaymentSchemes
    {
        public PaymentScheme PaymentScheme => PaymentScheme.FasterPayments;

        public MakePaymentResult DoPayment(Account account, MakePaymentResult result, MakePaymentRequest request = null)
        {
            if (account == null)
                result.Success = false;
            else if (!account.AllowedPaymentSchemes.HasFlag(AllowedPaymentSchemes.FasterPayments))
                result.Success = false;
            else if (account.Balance < request.Amount)
                result.Success = false;
            else
                result.Success = true;

            return result;
        }
    }
}