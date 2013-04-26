using ClearDebtDMP.Core.Models;
using ClearDebtDMP.Core.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClearDebtDMP.Core.Service
{

    public class DMPFeeService : IDMPFeeService
    {
        public DMPFeeResultModel Calculate(DMPFeeRequestViewModel req)
        {
            
            DMPFeeResultModel result = new DMPFeeResultModel();

            DMPFeeResponseViewModel feeResponse = null;

            DebtServiceProviderEnumerator debtProvider = (DebtServiceProviderEnumerator)Enum.Parse(typeof(DebtServiceProviderEnumerator), req.CustomerDebtManagementCompanyId);

            switch (debtProvider)
            {

                case DebtServiceProviderEnumerator.McDermottGodfrey :

                    feeResponse = new McDermottGodfreyDMPServiceProvider(req).Calculate();

                    break;

                case DebtServiceProviderEnumerator.DebtDestructor:

                    feeResponse = new DebtDestructorDMPServiceProvider(req).Calculate();

                    break;

                case DebtServiceProviderEnumerator.MoneyHelper:

                    feeResponse = new MoneyHelperDMPServiceProvider(req).Calculate();

                    break;

                default:
                    break;
            }

            if (feeResponse.IsNotNull())
            {

                feeResponse.Request = req; // original request

                result.DMPResponse = feeResponse; // provider response

                result.OK = true;

            }

            return (result);

        }
    }

    public abstract class BaseDMPServiceProvider
    {

        public string FirstName { get; set; }

        public string Surname { get; set; }

        public List<DebtModel> DebtRepaymentList { get; set; }

        public decimal Income { get; set; }

        public decimal Expenses { get; set; }

        public decimal TotalDebt { get; set; }

        public decimal DisposableIncome { get; set; }

        public decimal DistributableIncome { get; set; }

        public decimal Fee { get; set; }

        public abstract DMPFeeResponseViewModel Calculate();

        public BaseDMPServiceProvider(DMPFeeRequestViewModel req)
        {
            if (req.IsNotNull())
            {
                this.FirstName = req.CustomerFirstname;
                this.Surname = req.CustomerSurname;
                this.Income = req.Income;
                this.Expenses = req.Expenses;

                this.DebtRepaymentList = new List<DebtModel>();

                if (req.Debt1Desctiption.IsNotNullOrBlank() && req.Debt1Value.IsNotNull())
                    this.DebtRepaymentList.Add(new DebtModel() { DebtDescription = req.Debt1Desctiption, DebtAmount = req.Debt1Value });

                if (req.Debt2Desctiption.IsNotNullOrBlank() && req.Debt2Value.IsNotNull())
                    this.DebtRepaymentList.Add(new DebtModel() { DebtDescription = req.Debt2Desctiption, DebtAmount = req.Debt2Value });

                if (req.Debt3Desctiption.IsNotNullOrBlank() && req.Debt3Value.IsNotNull())
                    this.DebtRepaymentList.Add(new DebtModel() { DebtDescription = req.Debt3Desctiption, DebtAmount = req.Debt3Value });

                if (req.Debt4Desctiption.IsNotNullOrBlank() && req.Debt4Value.IsNotNull())
                    this.DebtRepaymentList.Add(new DebtModel() { DebtDescription = req.Debt4Desctiption, DebtAmount = req.Debt4Value });

                if (req.Debt5Desctiption.IsNotNullOrBlank() && req.Debt5Value.IsNotNull())
                    this.DebtRepaymentList.Add(new DebtModel() { DebtDescription = req.Debt5Desctiption, DebtAmount = req.Debt5Value });

                this.TotalDebt = DebtRepaymentList.Sum(x => x.DebtAmount);

                this.DisposableIncome = this.Income - this.Expenses;

            }
        }
    }

    public class McDermottGodfreyDMPServiceProvider : BaseDMPServiceProvider
    {

        public McDermottGodfreyDMPServiceProvider(DMPFeeRequestViewModel req) : base (req)
        {
        }

        public override DMPFeeResponseViewModel Calculate()
        {
            DMPFeeResponseViewModel response = new DMPFeeResponseViewModel();

            if (this.DisposableIncome > 0.0m)
            {

                if (this.TotalDebt > 0.0m)
                {

                    this.Fee = this.DisposableIncome * 0.15m;
                    this.DistributableIncome = this.DisposableIncome - this.Fee;

                    foreach (DebtModel d in DebtRepaymentList)
                    {
                        // work out repayments

                        d.DebtMonthlyRepayment = this.DistributableIncome * (d.DebtAmount / this.TotalDebt);
                    }

                    response.DistributableIncome = this.DistributableIncome;
                    response.Fee = this.Fee;
                }

            }

            response.TotalDebt = this.TotalDebt;
            response.DebtRepaymentList = this.DebtRepaymentList;
            response.DisposableIncome = this.DisposableIncome;
            
            return (response);
        }

    }

    public class DebtDestructorDMPServiceProvider : BaseDMPServiceProvider
    {

        public DebtDestructorDMPServiceProvider(DMPFeeRequestViewModel req) : base(req)
        {
        }

        public override DMPFeeResponseViewModel Calculate()
        {
            DMPFeeResponseViewModel response = new DMPFeeResponseViewModel();

            if (this.DisposableIncome > 0)
            {

                if (this.TotalDebt > 0)
                {

                    if (this.DisposableIncome < 100)
                        this.Fee = 25;
                    else if (this.DisposableIncome >= 100 && this.DisposableIncome < 200)
                        this.Fee = 30;
                    else if (this.DisposableIncome >= 200)
                    {
                        this.Fee = this.DisposableIncome * 0.16m;

                        if (this.Fee < 25)
                            this.Fee = 25;

                        if (this.Fee > 300)
                            this.Fee = 300;

                    }

                    this.DistributableIncome = this.DisposableIncome - this.Fee;

                    foreach (DebtModel d in DebtRepaymentList)
                    {
                        // work out repayments

                        d.DebtMonthlyRepayment = this.DistributableIncome * (d.DebtAmount / this.TotalDebt);
                    }

                    response.DistributableIncome = this.DistributableIncome;
                    response.Fee = this.Fee;
                }

            }

            response.TotalDebt = this.TotalDebt;
            response.DebtRepaymentList = this.DebtRepaymentList;
            response.DisposableIncome = this.DisposableIncome;

            return (response);
        }

    }

    public class MoneyHelperDMPServiceProvider : BaseDMPServiceProvider
    {

        public MoneyHelperDMPServiceProvider(DMPFeeRequestViewModel req) : base(req)
        {
        }

        public override DMPFeeResponseViewModel Calculate()
        {
            DMPFeeResponseViewModel response = new DMPFeeResponseViewModel();

            if (this.DisposableIncome > 0)
            {

                if (this.TotalDebt > 0)
                {

                    if (this.TotalDebt < 1000)
                        this.Fee = 10;
                    else
                    {
                        this.Fee = Math.Ceiling(this.TotalDebt / 1000) * 10;

                        if (this.Fee > 100)
                            this.Fee = 100;

                    }
                    
                    this.DistributableIncome = this.DisposableIncome - this.Fee;

                    foreach (DebtModel d in DebtRepaymentList)
                    {
                        // work out repayments

                        d.DebtMonthlyRepayment = this.DistributableIncome * (d.DebtAmount / this.TotalDebt);
                    }

                    response.DistributableIncome = this.DistributableIncome;
                    response.Fee = this.Fee;
                }

            }

            response.TotalDebt = this.TotalDebt;
            response.DebtRepaymentList = this.DebtRepaymentList;
            response.DisposableIncome = this.DisposableIncome;

            return (response);
        }

    }
}
