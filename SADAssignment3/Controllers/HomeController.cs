using SADAssignment3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SADAssignment3.KWIC;

namespace SADAssignment3.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Search()
        {
            return View();
        }


        // input data into kwic
        // run kwic return list of results
        // search from list of results and find keywords within the list.
        // return the original unshifted descriptor value and url for found keyword.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Search(SearchViewModel model)
        {
            // 1. read from db and input data into KWIC
            //MasterController mc = new MasterController();
            

            return View();
        }
    }
}