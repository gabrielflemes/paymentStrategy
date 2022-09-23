using Arrow.DeveloperTest.Data;
using Arrow.DeveloperTest.Services;
using Arrow.DeveloperTest.Types;
using AutoFixture;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arrow.DeveloperTest.Tests
{
    [TestClass]
    public class PaymentServiceTest
    {
        private PaymentService _payment;
        private IFixture _autoFixture;
        private Mock<IAccountDataStore> _mockAccountDataStore;
        private IStrategyPaymentSchemes[] _listStrategy;

        [TestInitialize]
        public void Setup()
        {
            _mockAccountDataStore = new Mock<IAccountDataStore>();
            _listStrategy = new IStrategyPaymentSchemes[] { new ChapsPayment() };
            _payment = new PaymentService(_mockAccountDataStore.Object, _listStrategy);
            _autoFixture = new Fixture();
        }


        [TestMethod]
        public void MakePaymentSuccess()
        {

            Account account = _autoFixture.Build<Account>().With(x => x.AllowedPaymentSchemes, AllowedPaymentSchemes.Chaps).Create();
            MakePaymentResult result = new MakePaymentResult();

            MakePaymentRequest request = _autoFixture.Build<MakePaymentRequest>().With(x => x.PaymentScheme, PaymentScheme.Chaps).Create();

            _mockAccountDataStore.Setup(x => x.GetAccount(request.DebtorAccountNumber)).Returns(account);

            MakePaymentResult ret = _payment.MakePayment(request);

            Assert.IsTrue(ret.Success);
        }

    }
}
