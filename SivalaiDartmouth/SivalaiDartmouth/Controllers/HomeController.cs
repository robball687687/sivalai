using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SivalaiDartmouth.Interfaces;
using SivalaiDartmouth.Models;

namespace SivalaiDartmouth.Controllers
{
    public class HomeController : Controller
    {
        private readonly IInventoryRetrievalService m_InventoryRetrievalService;

        public HomeController(IInventoryRetrievalService inventoryRetrievalService)
        {
            m_InventoryRetrievalService = inventoryRetrievalService;
        }

        public IActionResult Index()
        {
            RestaurantItems test = m_InventoryRetrievalService.getInventory();
            //ViewData["Menu"] = m_InventoryRetrievalService.getInventory();

            //var test = ViewData["Menu"];

            return View(test);
        }

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

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
