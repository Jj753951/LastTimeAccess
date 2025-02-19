using Microsoft.AspNetCore.Mvc;
using System;

namespace CookieDemo.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            // �������� �� ���������
            string lastVisit = Request.Cookies["LastVisit"];
            if (string.IsNullOrEmpty(lastVisit))
            {
                ViewBag.LastVisitMessage = "���� � ������� �� ���������!";
            }
            else
            {
                ViewBag.LastVisitMessage = $"�������� ���������: {lastVisit}";
            }

            // ��������� �� �������� ���� � ��� � ���������
            CookieOptions option = new CookieOptions
            {
                Expires = DateTime.Now.AddDays(30) // ����������� � ������� 30 ���
            };
            Response.Cookies.Append("LastVisit", DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss"), option);

            return View();
        }
    }
}
