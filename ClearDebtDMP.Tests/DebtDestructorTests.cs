using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClearDebtDMP.Core.Service;
using ClearDebtDMP.Core.Models;
using ClearDebtDMP.Core.Utility;
using ClearDebtDMP.Core.Controllers;
using System.Web.Mvc;
using StructureMap;

namespace ClearDebtDMP.Tests
{
    [TestClass]
    public class DebtDestructorTests
    {

        //IDMPFeeService DIService;

        //public DebtDestructorTests()
        //{
        //    DIService = ObjectFactory.GetInstance<IDMPFeeService>();
        //}

        [TestMethod]
        public void Test_DebtDestructor_1()
        {

            // need to be able to use DI to work with this object

            DMPFeeService service = new DMPFeeService();

            DMPFeeRequestViewModel req = new DMPFeeRequestViewModel()
            {
                CustomerFirstname = "Cam",
                CustomerSurname = "Braidwood",
                CustomerDebtManagementCompanyId = DebtServiceProviderEnumerator.DebtDestructor.ToString(),
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
        public void Test_DebtDestructor_2()
        {

            // need to be able to use DI to work with this object

            DMPFeeService service = new DMPFeeService();

            DMPFeeRequestViewModel req = new DMPFeeRequestViewModel()
            {
                CustomerFirstname = "Cam",
                CustomerSurname = "Braidwood",
                CustomerDebtManagementCompanyId = DebtServiceProviderEnumerator.DebtDestructor.ToString(),
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
        public void Test_DebtDestructor_3()
        {

            // need to be able to use DI to work with this object

            DMPFeeService service = new DMPFeeService();

            DMPFeeRequestViewModel req = new DMPFeeRequestViewModel()
            {
                CustomerFirstname = "Cam",
                CustomerSurname = "Braidwood",
                CustomerDebtManagementCompanyId = DebtServiceProviderEnumerator.DebtDestructor.ToString(),
                Income = 1000,
                Expenses = 950,
                Debt1Desctiption = "loan",
                Debt1Value = 1000
            };

            DMPFeeResultModel result = service.Calculate(req);

            Assert.AreEqual(result.OK, true);
            Assert.AreEqual(result.DMPResponse.Fee, 25);
            Assert.AreEqual(result.DMPResponse.DebtRepaymentList.Count, 1);
            Assert.AreEqual(result.DMPResponse.DebtRepaymentList[0].DebtMonthlyRepayment, 25);

        }

        [TestMethod]
        public void Test_DebtDestructor_4()
        {

            // need to be able to use DI to work with this object

            DMPFeeService service = new DMPFeeService();

            DMPFeeRequestViewModel req = new DMPFeeRequestViewModel()
            {
                CustomerFirstname = "Cam",
                CustomerSurname = "Braidwood",
                CustomerDebtManagementCompanyId = DebtServiceProviderEnumerator.DebtDestructor.ToString(),
                Income = 1000,
                Expenses = 810,
                Debt1Desctiption = "loan",
                Debt1Value = 1000,
                Debt2Desctiption = "loan 2",
                Debt2Value = 1000
            };

            DMPFeeResultModel result = service.Calculate(req);

            Assert.AreEqual(result.OK, true);
            Assert.AreEqual(result.DMPResponse.Fee, 30);
            Assert.AreEqual(result.DMPResponse.DebtRepaymentList.Count, 2);
            Assert.AreEqual(result.DMPResponse.DebtRepaymentList[0].DebtMonthlyRepayment, 80);
            Assert.AreEqual(result.DMPResponse.DebtRepaymentList[1].DebtMonthlyRepayment, 80);

        }

        [TestMethod]
        public void Test_DebtDestructor_5()
        {

            DMPFeeService service = new DMPFeeService();
            //IDMPFeeService service = ObjectFactory.GetInstance<IDMPFeeService>();

            //HomeController c = new HomeController(service);

            DMPFeeRequestViewModel req = new DMPFeeRequestViewModel()
            {
                CustomerFirstname = "Cam",
                CustomerSurname = "Braidwood",
                CustomerDebtManagementCompanyId = DebtServiceProviderEnumerator.DebtDestructor.ToString(),
                Income = 1000,
                Expenses = 810,
                Debt1Desctiption = "loan",
                Debt1Value = 1000,
                Debt2Desctiption = "loan 2",
                Debt2Value = 1000
            };

            DMPFeeResultModel result = service.Calculate(req);

            Assert.AreEqual(result.OK, true);
            Assert.AreEqual(result.DMPResponse.Fee, 30);
            Assert.AreEqual(result.DMPResponse.DebtRepaymentList.Count, 2);
            Assert.AreEqual(result.DMPResponse.DebtRepaymentList[0].DebtMonthlyRepayment, 80);
            Assert.AreEqual(result.DMPResponse.DebtRepaymentList[1].DebtMonthlyRepayment, 80);

        }
    }
}
