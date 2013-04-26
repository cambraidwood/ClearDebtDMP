using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClearDebtDMP.Core.Models;
using ClearDebtDMP.Core.Service;

namespace ClearDebtDMP.Core.Controllers
{
    public class HomeController : BaseController
    {

        private IDMPFeeService DMPFeeService;

        public HomeController(IDMPFeeService pDMPFeeService)
        {
            this.DMPFeeService = pDMPFeeService;
        }

        [HttpGet]
        public ActionResult Index()
        {

            DMPFeeRequestViewModel req = new DMPFeeRequestViewModel();

            return View(req);

        }

        [HttpPost]
        public ActionResult Index(DMPFeeRequestViewModel data)
        {

            DMPFeeResultModel result = this.DMPFeeService.Calculate(data);

            if (result.OK)
            {

                return View("Summary", result.DMPResponse);

            }
            else
            {

                base.ProcessModelStateErrors(ModelState, result.ErrorDetailList);

                return View(data);

            }


        }

    }
}
