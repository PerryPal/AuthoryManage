using AuthoryManage.InterfaceService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AuthoryManage.Web.Controllers {
    public class HomeController : Controller {
        //
        // GET: /Home/
        private IEmpService _service;
        public HomeController(IEmpService service) {
            this._service = service;
        }
        public ActionResult Index() {
            ViewBag.SSSS = _service.LoadEntities();
            return View();
        }

    }
}
