using Arrow.DeveloperTest.Data;
using Arrow.DeveloperTest.Types;
using System.Collections.Generic;
using System.Linq;

namespace Arrow.DeveloperTest.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IAccountDataStore _accountDataStore;

        private readonly IEnumerable<IStrategyPaymentSchemes> _paymentSchemes;

        public PaymentService(IAccountDataStore accountDataStore, IEnumerable<IStrategyPaymentSchemes> paymentSchemes)
        {
            _accountDataStore = accountDataStore;
            _paymentSchemes = paymentSchemes;
        }

        public MakePaymentResult MakePayment(MakePaymentRequest request)
        {
            Account account = _accountDataStore.GetAccount(request.DebtorAccountNumber);

            MakePaymentResult result = new MakePaymentResult();

            IStrategyPaymentSchemes strategy = _paymentSchemes.FirstOrDefault(x => x.PaymentScheme == request.PaymentScheme);


            result = strategy.DoPayment(account, result, request);

            if (result.Success)
            {
                account.Balance -= request.Amount;

                _accountDataStore.UpdateAccount(account);
            }

            return result;
        }
    }
}
