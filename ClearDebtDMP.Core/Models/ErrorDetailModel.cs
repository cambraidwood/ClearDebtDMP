using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClearDebtDMP.Core.Models
{

    public class ErrorDetailModel
    {
        public string ErrorDescription { get; set; }
        public string ErrorDetail { get; set; }
        public string ErrorIdentifier { get; set; }

        public ErrorDetailModel()
        {
            this.ErrorDescription = "";
            this.ErrorDetail = "";
            this.ErrorIdentifier = "";
        }
    }

}
