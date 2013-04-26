using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClearDebtDMP.Core.Controllers;
using ClearDebtDMP.Core.Service;
using ClearDebtDMP.Core.Models;
using ClearDebtDMP.Core.Utility;
using System.Web.Mvc;

namespace ClearDebtDMP.Tests
{
    [TestClass]
    public class McDermottGodfreyTests
    {

        [TestMethod]
        public void Test_McDermottGodfrey_1()
        {

            // need to be able to use DI to work with this object

            DMPFeeService service = new DMPFeeService();

            DMPFeeRequestViewModel req = new DMPFeeRequestViewModel()
            {
                CustomerFirstname = "Cam",
                CustomerSurname = "Braidwood",
                CustomerDebtManagementCompanyId = DebtServiceProviderEnumerator.McDermottGodfrey.ToString(),
                Income = 1000,
                Expenses = 1000,
                Debt1Desctiption = "loan",
                Debt1Value = 5000
            };

            DMPFeeResultModel result = service.Calculate(req);

            Assert.AreEqual(result.OK, true);
            Assert.AreEqual(result.DMPResponse.Fee, 0);
        }

        [TestMethod]
        public void Test_McDermottGodfrey_2()
        {

            // need to be able to use DI to work with this object

            DMPFeeService service = new DMPFeeService();

            DMPFeeRequestViewModel req = new DMPFeeRequestViewModel()
            {
                CustomerFirstname = "Cam",
                CustomerSurname = "Braidwood",
                CustomerDebtManagementCompanyId = DebtServiceProviderEnumerator.McDermottGodfrey.ToString(),
                Income = 1000,
                Expenses = 1300,
                Debt1Desctiption = "loan",
                Debt1Value = 5000
            };

            DMPFeeResultModel result = service.Calculate(req);

            Assert.AreEqual(result.OK, true);
            Assert.AreEqual(result.DMPResponse.Fee, 0);
        }

        [TestMethod]
        public void Test_McDermottGodfrey_3()
        {

            // need to be able to use DI to work with this object
            
            DMPFeeService service = new DMPFeeService();

            DMPFeeRequestViewModel req = new DMPFeeRequestViewModel()
            {
                 CustomerFirstname = "Cam",
                 CustomerSurname = "Braidwood",
                 CustomerDebtManagementCompanyId = DebtServiceProviderEnumerator.McDermottGodfrey.ToString(),
                 Income = 1000,
                 Expenses = 900,
                 Debt1Desctiption = "loan",
                 Debt1Value = 1000
            };

            DMPFeeResultModel result = service.Calculate(req);

            Assert.AreEqual(result.OK, true);
            Assert.AreEqual(result.DMPResponse.Fee, 15);
            Assert.AreEqual(result.DMPResponse.DebtRepaymentList.Count, 1);
            Assert.AreEqual(result.DMPResponse.DebtRepaymentList[0].DebtMonthlyRepayment, 85);

        }

        [TestMethod]
        public void Test_McDermottGodfrey_4()
        {

            // need to be able to use DI to work with this object

            DMPFeeService service = new DMPFeeService();

            DMPFeeRequestViewModel req = new DMPFeeRequestViewModel()
            {
                CustomerFirstname = "Cam",
                CustomerSurname = "Braidwood",
                CustomerDebtManagementCompanyId = DebtServiceProviderEnumerator.McDermottGodfrey.ToString(),
                Income = 1000,
                Expenses = 900,
                Debt1Desctiption = "loan",
                Debt1Value = 1000,
                Debt2Desctiption = "loan 2",
                Debt2Value = 1000
            };

            DMPFeeResultModel result = service.Calculate(req);

            Assert.AreEqual(result.OK, true);
            Assert.AreEqual(result.DMPResponse.Fee, 15);
            Assert.AreEqual(result.DMPResponse.DebtRepaymentList.Count, 2);
            Assert.AreEqual(result.DMPResponse.DebtRepaymentList[0].DebtMonthlyRepayment, 42.5m);
            Assert.AreEqual(result.DMPResponse.DebtRepaymentList[1].DebtMonthlyRepayment, 42.5m);

        }

    }
}
