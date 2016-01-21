using System.Web;
using System.Web.Mvc;

namespace AuthoryManage.Plugins {
    public class FilterConfig {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters) {
            filters.Add(new HandleErrorAttribute());
        }
    }
}