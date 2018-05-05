using System;
using System.Diagnostics;
using System.Net.Mail;
using Microsoft.AspNetCore.Mvc;
using SimpleMVC_VIPInvitation.Models;

namespace SimpleMVC_VIPInvitation.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public ViewResult About()
        {
            int hour = DateTime.Now.Hour;
            ViewBag.Greeting = hour < 17 ? "Dzień dobry" : "Dobry wieczór";
            return View();
        }

        [HttpPost]
        public ViewResult About(VipRsvpModel model)
        {
            if (ModelState.IsValid)
            {
                #region wysyłanie Maila
                try
                {
                    MailMessage mail = new MailMessage();
                    SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                    mail.From = new MailAddress("puszynski@gmail.com");
                    mail.To.Add("tadamczewski@gmail.com");
                    mail.Subject = "4 Pory Rocka - Lista VIP";
                    mail.Body = "treść wiadomości";

                    SmtpServer.Port = 587;
                    SmtpServer.Credentials = new System.Net.NetworkCredential("username", "password");
                    SmtpServer.EnableSsl = true;

                    SmtpServer.Send(mail);                    
                }
                catch (Exception ex)
                {
                    //ToDo
                }
                #endregion
                return View("Thanks", model);
            }
            else
            {
                return View(); // W razie niepoprawności wypełnienia formularza zwracamy ten sam widok + używając @Html.ValidationSummary() w widoku, uwidaczniamy komunikaty o błędach wypełnienia formularza // 
            }
            
        }


        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
