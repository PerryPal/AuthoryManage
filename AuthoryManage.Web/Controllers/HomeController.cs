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
        private IBaseService _service;
        public HomeController(IBaseService service) {
            this._service = service;
        }
        public ActionResult Index() {
            ViewBag.SSSS = _service.GetData();
            return View();
        }

    }
}
