using Arrow.DeveloperTest.Services;
using Arrow.DeveloperTest.Types;
using AutoFixture;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Arrow.DeveloperTest.Tests
{
    [TestClass]
    public class BacsPaymentTest
    {
        private BacsPayment _payment;
        private IFixture _autoFixture;

        [TestInitialize]
        public void Setup()
        {
            _payment = new BacsPayment();
            _autoFixture = new Fixture();
        }



        [TestMethod]
        public void DoPaymentReturnFalse()
        {
            //set wrong value to be tested
            Account account = _autoFixture.Build<Account>().With(x => x.AllowedPaymentSchemes, AllowedPaymentSchemes.Chaps).Create();
            MakePaymentResult result = new MakePaymentResult();
            

            MakePaymentResult ret = _payment.DoPayment(account, result);

            Assert.IsFalse(ret.Success);
        }

        [TestMethod]
        public void DoPaymentReturnTrue()
        {
            //set right value to be tested
            Account account = _autoFixture.Build<Account>().With(x => x.AllowedPaymentSchemes, AllowedPaymentSchemes.Bacs).Create();
            MakePaymentResult result = new MakePaymentResult();


            MakePaymentResult ret = _payment.DoPayment(account, result);

            Assert.IsTrue(ret.Success);
        }


        //THERE ARE MORE TESTS TO BE MADE, BUT TO BRAVITY I DIDN'T DO
        //The most important is the archtecture that was made
        //now is just repeat and make a lot of tests \o/


    }
}
