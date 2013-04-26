using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClearDebtDMP.Core.Models
{
    public class DebtModel
    {
        public string DebtDescription { get; set; }
        public decimal DebtAmount { get; set; }
        public decimal DebtMonthlyRepayment { get; set; }
    }
}
