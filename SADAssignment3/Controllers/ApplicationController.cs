using SADAssignment3.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SADAssignment3.Controllers
{
    public class ApplicationController : Controller
    {
        protected UnitOfWork unitOfWork = new UnitOfWork();
    }
}