using Hangfire;
using System.Web.Mvc;

namespace CotacaoDolar.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult AddSchedule()
        {
            RecurringJob.AddOrUpdate("JobID", () => GetDollarQuotation(), Cron.Daily);

            return RedirectToAction(nameof(Index));
        }

        public string GetDollarQuotation()
        {
            //Use this code if you need proxy authentication.
            //IMPORTANT: To use proxy authentication you need add the service reference as Web Reference (Add Service Reference > Advanced > Add Web Reference)
            //var service = new WebReference.FachadaWSSGSService
            //{
            //    Proxy = new WebProxy("MyProxyAddress", PortNumber)
            //    {
            //        Credentials = new NetworkCredential { UserName = "user", Password = "P@$$w0rd", Domain = "MyDomain" }
            //    }
            //};

            //If you don't need proxy authentication you can add as service reference instead web reference
            var service = new WebReference.FachadaWSSGSService();

            var cotacao = service.getUltimoValorVO(10813);

            return cotacao.ultimoValor.svalor;
        }
    }
}