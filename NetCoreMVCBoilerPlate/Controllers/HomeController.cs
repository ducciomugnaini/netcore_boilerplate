using Microsoft.AspNetCore.Mvc;
using NetCoreMVCBoilerPlate.Models;
using System.Diagnostics;
using NetCoreMVCBoilerPlate.Data;

namespace NetCoreMVCBoilerPlate.Controllers
{
   public class HomeController : Controller
   {
      private readonly ILogger<HomeController> _logger;
      private readonly ApplicationDbContext _dbContext;

      public HomeController(ILogger<HomeController> logger, ApplicationDbContext applicationDbContext)
      {
         _logger = logger;
         _dbContext = applicationDbContext;
      }

      public IActionResult Index()
      {
         var dummyEntities= _dbContext.DummyEntities.ToList();
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