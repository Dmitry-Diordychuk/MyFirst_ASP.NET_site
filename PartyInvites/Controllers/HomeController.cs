using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PartyInvites.Models;

namespace PartyInvites.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            Random rand = new Random();
            int number = rand.Next(1, 100);
            ViewBag.Greating = number < 50 ? "Good Morning Sir!" : "Good Afternoon";
            return View("MyView");
        }

        [HttpGet]
        public ViewResult RsvpForm()
        {
            return View();
        }

        [HttpPost]
        public ViewResult RsvpForm(GuestResponse guestResponse)
        {
            if (ModelState.IsValid)
            {
                Repository.AddResponse(guestResponse);
                return View("Thanks", guestResponse);
            }
            else
            {
                return View();
            }
        }

        public ViewResult ListResponses()
        {
            return View(Repository.Responses.Where(r => r.WillAttend == true));
        }

        public IActionResult About()
        {
            throw new NotImplementedException();
        }

        public IActionResult Contact()
        {
            throw new NotImplementedException();
        }

        public IActionResult Privacy()
        {
            throw new NotImplementedException();
        }
    }
}
