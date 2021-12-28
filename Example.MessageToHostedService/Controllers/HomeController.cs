using Example.MessageToHostedService.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Example.MessageToHostedService.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMediator _bus;

        public HomeController(ILogger<HomeController> logger, IMediator bus)
        {
            _logger = logger;
            _bus = bus;
        }

        public async Task<IActionResult> Index()
        {
            await _bus.Send(new Message("Hello from index!"));
            return View();
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