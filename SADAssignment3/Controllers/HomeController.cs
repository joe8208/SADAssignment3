using SADAssignment3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SADAssignment3.KWIC;
using SADAssignment3.DAL;

namespace SADAssignment3.Controllers
{
    public class HomeController : Controller
    {
        private SADAssignment3Context db = new SADAssignment3Context();

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
            

            List<LineInput> listOfLineInputs = db.LineInputs.ToList();
            List<string> input = listOfLineInputs.Select(s => s.Descriptor).ToList();

            List<string> noiseWords = db.NoiseWords.Select(s => s.Word).ToList();

            KWICMasterController mc = new KWICMasterController();
            mc.Execute(input, noiseWords);
            var shiftedOutPut = mc.KWICOutPut;

            // search through the shifted lines and find the ones with the keywords
            return View();
        }
    }
}