using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClearDebtDMP.Core.Models
{
    public class DMPFeeResponseViewModel
    {

        public DMPFeeRequestViewModel Request { get; set; }

        public List<DebtModel> DebtRepaymentList { get; set; }

        public decimal TotalDebt { get; set; }

        public decimal DisposableIncome { get; set; }

        public decimal DistributableIncome { get; set; }

        public decimal Fee { get; set; }

    }
}
