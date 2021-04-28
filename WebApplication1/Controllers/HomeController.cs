using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Service;
using WebApplication1.ViewModel;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var dataContext = new DataContext();

            var generalViewModelService = new GeneralViewModelService();
            var model = generalViewModelService.GetGeneralViewModel(dataContext);

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

    }
}
