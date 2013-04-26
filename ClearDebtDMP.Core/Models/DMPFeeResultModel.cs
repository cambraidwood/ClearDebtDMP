using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClearDebtDMP.Core.Models
{
    public class DMPFeeResultModel : BaseResultModel
    {

        public DMPFeeResponseViewModel DMPResponse { get; set; }

        public DMPFeeResultModel()
        {
            this.DMPResponse = null;
        }

    }
}
