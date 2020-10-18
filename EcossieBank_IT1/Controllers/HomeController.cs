using EcossieBank_IT1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EcossieBank_IT1.Controllers
{
    [BasicAuthenticationAttribute("EcossieKids", "EcoPathseekers25",
    BasicRealm = "your-realm")]
    public class HomeController : Controller
    {


        private DashboardEntities db = new DashboardEntities();

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

        [HttpPost]
        public JsonResult DoesUserNameExist(string name)
        {
            bool isValid = db.Dashboards.ToList().Exists(p => p.name.Equals(name, StringComparison.CurrentCultureIgnoreCase));
            return Json(isValid);

        }


        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            ViewBag.Current = "Send_Email";
            return View();
        }

        public ActionResult Stats()
        {
            ViewBag.Message = "Your contact page.";
            ViewBag.Current = "Stats";
            return View();
        }

        public ActionResult RenewableStats()
        {
            ViewBag.Message = "Your contact page.";
            ViewBag.Current = "RenewableStats";
            return View();
        }

        public ActionResult RenewableGame()
        {
            ViewBag.Message = "Your contact page.";
            ViewBag.Current = "RenewableGame";
            return View();
        }

        public ActionResult Tips()
        {
            ViewBag.Message = "Your contact page.";
            ViewBag.Current = "Tips";
            return View();
        }
        public ActionResult Quiz()
        {
            ViewBag.Message = "Your quiz page.";
            ViewBag.Current = "Quiz";
            ViewBag.quizResult1 = "";
            ViewBag.quizResult2 = "";
            ViewBag.quizResult2 = "";

            return View();
        }
        [HttpPost]
        public ActionResult Quiz(FormCollection form)
        {
            string demo = form["name"].ToString();
            int quiz1 = Convert.ToInt32(ViewBag.Data);
            int quiz2 = Convert.ToInt32(form["result_quiz2"].ToString());
            int quiz3 = Convert.ToInt32(form["result_quiz3"].ToString());
            ViewBag.Message = "Your quiz page.";
            ViewBag.Current = "Quiz";
            return View();
        }

        public ActionResult Quiz1()
        {
            ViewBag.Message = "Your quiz page.";
            ViewBag.Current = "Quiz";
            return View();
        }

        public ActionResult Quiz2()
        {
            ViewBag.Message = "Your quiz2 page.";
            ViewBag.Current = "Quiz2";
            return View();
        }

        public ActionResult Quiz3()
        {
            ViewBag.Message = "Your quiz3 page.";
            ViewBag.Current = "Quiz3";
            return View();
        }

        public ActionResult Image_Game()
        {
            ViewBag.Message = "Your game page.";
            ViewBag.Current = "Image_Game";
            return View();
        }

        public ActionResult Book_Shelf()
        {
            ViewBag.Message = "Book_shelf";
            ViewBag.Current = "Book_Shelf";
            return View();
        }

        public ActionResult Additional_Tips()
        {
            ViewBag.Current = "Additional_Tips";
            return View();
        }


        public ActionResult Send_Email()
        {
            ViewBag.Current = "Send_Email";
            return View(new SendEmailViewModel());
        }

        public ActionResult Leaderboard()
        {
            ViewBag.Current = "Leaderboard";
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


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


    }
}