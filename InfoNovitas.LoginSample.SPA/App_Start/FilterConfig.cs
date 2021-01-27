using System.Web;
using System.Web.Mvc;

namespace InfoNovitas.LoginSample.SPA
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
