using System.Diagnostics;
using DI_Services_Lifetime.Models;
using Microsoft.AspNetCore.Mvc;
using DI_Services_Lifetime.Services;
using System.Text;

namespace DI_Services_Lifetime.Controllers
{
    public class HomeController : Controller
    {
        private readonly IScopedGuidService _scopedGuidService1;
        private readonly IScopedGuidService _scopedGuidService2;

        private readonly ITransientGuidService _transientGuidService1;
        private readonly ITransientGuidService _transientGuidService2;

        private readonly ISingletonGuidService _singletonGuidService1;
        private readonly ISingletonGuidService _singletonGuidService2;

        public HomeController(IScopedGuidService scopedGuidService1,
            IScopedGuidService scopedGuidService2,
            ITransientGuidService transientGuidService1,
            ITransientGuidService transientGuidService2,
            ISingletonGuidService singletonGuidService1,
            ISingletonGuidService singletonGuidService2)
        {
            _scopedGuidService1 = scopedGuidService1;
            _scopedGuidService2 = scopedGuidService2;
            _transientGuidService1 = transientGuidService1;
            _transientGuidService2 = transientGuidService2;
            _singletonGuidService1 = singletonGuidService1;
            _singletonGuidService2 = singletonGuidService2;

        }

        public IActionResult Index()
        {
            StringBuilder messages = new StringBuilder();
            messages.Append($"Scoped 1: {_scopedGuidService1.GetGuid()}\n");
            messages.Append($"Scoped 2: {_scopedGuidService2.GetGuid()}\n\n\n");
            messages.Append($"Transient 1: {_transientGuidService1.GetGuid()}\n");
            messages.Append($"Transient 2: {_transientGuidService2.GetGuid()}\n\n\n");
            messages.Append($"Singleton 1: {_singletonGuidService1.GetGuid()}\n");
            messages.Append($"Singleton 2: {_singletonGuidService2.GetGuid()}\n\n\n");

            return Ok(messages.ToString());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
