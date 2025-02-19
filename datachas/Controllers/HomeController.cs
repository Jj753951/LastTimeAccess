using Microsoft.AspNetCore.Mvc;
using System;

namespace CookieDemo.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            // Проверка за бисквитка
            string lastVisit = Request.Cookies["LastVisit"];
            if (string.IsNullOrEmpty(lastVisit))
            {
                ViewBag.LastVisitMessage = "Това е първото Ви посещение!";
            }
            else
            {
                ViewBag.LastVisitMessage = $"Последно посещение: {lastVisit}";
            }

            // Запазване на текущата дата и час в бисквитка
            CookieOptions option = new CookieOptions
            {
                Expires = DateTime.Now.AddDays(30) // Бисквитката е валидна 30 дни
            };
            Response.Cookies.Append("LastVisit", DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss"), option);

            return View();
        }
    }
}
