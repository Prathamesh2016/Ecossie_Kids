using EcossieBank_IT1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EcossieBank_IT1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Current = "Index";
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            ViewBag.Current = "About";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            ViewBag.Current = "Send_Email";
            return View();
        }

        public ActionResult Tips()
        {
            ViewBag.Message = "Your contact page.";
            ViewBag.Current = "Tips";
            return View();
        }

        public ActionResult Image_Game()
        {
            ViewBag.Message = "Your game page.";
            ViewBag.Current = "Image_Game";
            return View();
        }

       
        public ActionResult Send_Email()
        {
            ViewBag.Current = "Send_Email";
            return View(new SendEmailViewModel());
        }

        [HttpPost]
        public ActionResult Send_Email(SendEmailViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    String toEmail = model.ToEmail;
                    String subject = model.Subject;
                    String contents = model.Contents;

                    EmailSender es = new EmailSender();
                    es.Send(toEmail, subject, contents);
                    
                    ViewBag.Result = "Email has been sent.";

                    ModelState.Clear();
                    ViewBag.Current = "Send_Email";
                    return View(new SendEmailViewModel());
                }
                catch
                {
                    return View();
                }
            }
            ViewBag.Current = "Send_Email";
            return View();
        }


    }
}