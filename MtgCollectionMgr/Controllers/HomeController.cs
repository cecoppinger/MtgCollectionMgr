using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MtgApiManager.Lib.Model;
using MtgApiManager.Lib.Service;
using MtgCollectionMgr.Models;

namespace MtgCollectionMgr.Controllers
{
    public class HomeController : Controller
    {
        //public IActionResult Index()
        //{
        //    var cards = GetAllCards();
            
        //    return View(cards);
        //}

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

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

        //public static IEnumerable<Card> GetAllCards()
        //{
        //    CardService service = new CardService();
        //    var result = service.All();
        //    var value = result.Value;
        //    return value;
        //}
    }
}
