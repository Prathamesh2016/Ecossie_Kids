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
        private EcossieKidsEntities db = new EcossieKidsEntities();

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

        //[HttpPost]
        //public JsonResult DoesUserNameExist(string name)
        //{
        //    bool isValid = db.Dashboards.ToList().Exists(p => p.name.Equals(name, StringComparison.CurrentCultureIgnoreCase));
        //    return Json(isValid);

        //}


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
            ViewBag.quizResult1 = "123";
            ViewBag.quizResult2 = "";
            ViewBag.quizResult3 = "";

            return View();
        }
        [HttpPost]
        public ActionResult Quiz(FormCollection form)
        {
            string name = form["name"].ToString();
            string quiz1 = form["quiz1"].ToString();
            string quiz2 = form["quiz2"].ToString();
            string quiz3 = form["quiz3"].ToString();
            int iquiz1, iquiz2, iquiz3;
            if (String.IsNullOrEmpty(quiz1))
              iquiz1 = 0;
             else
                 iquiz1 = Convert.ToInt32(quiz1);

            if (String.IsNullOrEmpty(quiz2))
                iquiz2 = 0;
            else
                iquiz2 = Convert.ToInt32(quiz2);

            if (String.IsNullOrEmpty(quiz3))
                iquiz3 = 0;
            else
                iquiz3 = Convert.ToInt32(quiz3);

            
            try
            {
                Dashboard dashboard = new Dashboard
                {
                    name = name,
                    quiz1_score = iquiz1,
                    quiz2_score = iquiz2,
                    quiz3_score = iquiz3
                };
                dashboard.total_score = dashboard.quiz1_score + dashboard.quiz2_score + dashboard.quiz3_score;
                dashboard.badge = "desp";
                db.Dashboards.Add(dashboard);
                db.SaveChanges();

            }
            catch(Exception e)
            {

            }

            ViewBag.Message = "Your quiz page.";
            ViewBag.Current = "Quiz";
            return View();
        }
        public ActionResult Leaderboard()
        {
            //var data = db.Dashboards.

            //var orderByDescendingResult = from s in Dashboard
            //                              orderby s. descending
            //                              select s
            //var main = db.Dashboards;
            //var data = (from t in db.Dashboards
                        
            //            orderby t.total_score
            //            select t);
            IEnumerable<Dashboard> x = db.Dashboards.ToList().OrderByDescending(t => t.total_score).Take(10);
            Dashboard d1 = x.ElementAt(0);
            ViewBag.Name1 = d1.name;
            ViewBag.Result1 = d1.total_score;

            Dashboard d2 = x.ElementAt(1);
            ViewBag.Name2 = d2.name;
            ViewBag.Result2 = d2.total_score;

            Dashboard d3 = x.ElementAt(2);
            ViewBag.Name3 = d3.name;
            ViewBag.Result3 = d3.total_score;

            Dashboard d4 = x.ElementAt(3);
            ViewBag.Name4 = d4.name;
            ViewBag.Result4 = d4.total_score;

            Dashboard d5 = x.ElementAt(4);
            ViewBag.Name5 = d5.name;
            ViewBag.Result5 = d5.total_score;

            Dashboard d6 = x.ElementAt(5);
            ViewBag.Name6 = d6.name;
            ViewBag.Result6 = d6.total_score;

            Dashboard d7 = x.ElementAt(6);
            ViewBag.Name7 = d7.name;
            ViewBag.Result7 = d7.total_score;

            Dashboard d8 = x.ElementAt(7);
            ViewBag.Name8 = d8.name;
            ViewBag.Result8 = d8.total_score;

            Dashboard d9 = x.ElementAt(8);
            ViewBag.Name9 = d9.name;
            ViewBag.Result9 = d9.total_score;

            Dashboard d10 = x.ElementAt(9);
            ViewBag.Name10 = d10.name;
            ViewBag.Result10 = d10.total_score;



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