using ClearDebtDMP.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ClearDebtDMP.Core.Controllers
{


    public class BaseController : Controller
    {

        #region events

        //protected override void OnActionExecuted(ActionExecutedContext filterContext)
        //{
        //}

        //protected override void OnResultExecuting(ResultExecutingContext filterContext)
        //{
        //}

        //protected override void OnResultExecuted(ResultExecutedContext filterContext)
        //{
        //}

        #endregion

        public BaseController()
        {

        }

        public bool ProcessModelStateErrors(ModelStateDictionary m, List<ErrorDetailModel> list)
        {
            try
            {

                foreach (ErrorDetailModel e in list)
                {
                    m.AddModelError(e.ErrorIdentifier, e.ErrorDescription);
                }

                return true;

            }
            catch
            {

                return false;

            }

        }

    }


}
