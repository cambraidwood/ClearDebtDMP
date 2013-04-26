using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClearDebtDMP.Core.Models
{
    public class BaseResultModel
    {
        public bool OK { get; set; }
        public List<ErrorDetailModel> ErrorDetailList { get; set; }
        public bool ExceptionOccurred { get; set; }

        public BaseResultModel()
        {
            this.OK = false;
            this.ErrorDetailList = new List<ErrorDetailModel>();
            this.ExceptionOccurred = false;
        }

        public void AddExceptionError(ErrorDetailModel e)
        {
            this.ErrorDetailList.Add(e);
            this.ExceptionOccurred = true;
        }

        public void AddError(ErrorDetailModel e)
        {
            this.ErrorDetailList.Add(e);
        }
    }
}
