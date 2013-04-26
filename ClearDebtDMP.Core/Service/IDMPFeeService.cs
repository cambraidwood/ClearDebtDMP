using ClearDebtDMP.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClearDebtDMP.Core.Service
{
    public interface IDMPFeeService
    {

        DMPFeeResultModel Calculate(DMPFeeRequestViewModel req);

    }
}
