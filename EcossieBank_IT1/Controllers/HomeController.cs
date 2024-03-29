﻿using EcossieBank_IT1.Models;
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
        public static int position;
        
        [HandleError]
        public ActionResult Index()
        {
            ViewBag.Current = "Index";
            return View();
        }

        [HandleError]
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



        [HandleError]
        public ActionResult Stats()
        {
            ViewBag.Message = "Your contact page.";
            ViewBag.Current = "Stats";
            return View();
        }

        [HandleError]
        public ActionResult RenewableStats()
        {
            ViewBag.Message = "Your contact page.";
            ViewBag.Current = "RenewableStats";
            return View();
        }

        [HandleError]
        public ActionResult RenewableGame()
        {
            ViewBag.Message = "Your contact page.";
            ViewBag.Current = "RenewableGame";
            return View();
        }

        [HandleError]
        public ActionResult Tips()
        {
            ViewBag.Message = "Your contact page.";
            ViewBag.Current = "Tips";
            return View();
        }

        [HandleError]
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
            ViewBag.Error = "";
            if (String.IsNullOrEmpty(quiz1))
                iquiz1 = 0;
            else
            {
                int temp = Convert.ToInt32(quiz1);
                if (temp > 30 )
                    iquiz1 = 0;
                else
                    iquiz1 = temp;
            }

            if (String.IsNullOrEmpty(quiz2))
                iquiz2 = 0;
            else
            {
                int temp = Convert.ToInt32(quiz2);
                if (temp > 40)
                    iquiz2 = 0;
                else
                    iquiz2 = temp;
            }

            if (String.IsNullOrEmpty(quiz3))
                iquiz3 = 0;
            else
            {
                int temp = Convert.ToInt32(quiz3);
                if (temp > 30)
                    iquiz3 = 0;
                else
                    iquiz3 = temp;
            }


            try
            {
                Dashboard d1 = db.Dashboards.FirstOrDefault(p => p.name.Equals(name.ToUpper()));
                if (d1 == null)
                {
                 Dashboard dashboard = new Dashboard
                    {
                        name = name.ToUpper(),
                        quiz1_score = iquiz1,
                        quiz2_score = iquiz2,
                        quiz3_score = iquiz3
                    };
                   
                    dashboard.total_score = dashboard.quiz1_score + dashboard.quiz2_score + dashboard.quiz3_score;
                    if (dashboard.total_score != 0)
                    {
                        dashboard.badge = "desp";
                        db.Dashboards.Add(dashboard);
                        ViewBag.UserAdded = dashboard.name + " successfully added";
                        db.SaveChanges();

                        ViewBag.Sucess = "User " + dashboard.name + " successfully added.";
                        IEnumerable<Dashboard> myRank = db.Dashboards.ToList().OrderByDescending(t => t.total_score);
                        position = myRank.ToList().IndexOf(dashboard);

                        return RedirectToAction("Dashboard","Home");
                    }
                    else
                    {
                        ViewBag.Error = "Please play Quiz and then enter the name.";
                    }


                    //IEnumerable<Dashboard> myRank = db.Dashboards.ToList().OrderByDescending(t => t.total_score);
                    //position = myRank.ToList().IndexOf(dashboard);

                   
                }
                else
                {

                 
                    ViewBag.Error = "User with same name already exist.";
                    return View();
                }




                }
            catch(Exception e)
            {

            }
            return View();
        }

        [HandleError]
        public ActionResult Dashboard()
        {
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

            //Getting my current rank

            IEnumerable<Dashboard> myRank = db.Dashboards.ToList().OrderByDescending(t => t.total_score);
            
            if (position > 0 )
            {
                Dashboard mine = myRank.ElementAt(position);
                ViewBag.Mine = mine.name;
                ViewBag.MyResult = mine.total_score;
                ViewBag.Position = position + 1;
                ViewBag.Result = "My Rank";
                ViewBag.TopScore = "My Score";
            }
            else
            {
                Dashboard top = myRank.ElementAt(0);
                ViewBag.Mine = top.name;
                ViewBag.MyResult = top.total_score;
                ViewBag.Position =  "1";
                ViewBag.Result = "Highest Rank";
                ViewBag.TopScore = "Highest Score";
            }
     

            return View();
        }




        [HandleError]
        public ActionResult Quiz1()
        {
            ViewBag.Message = "Your quiz page.";
            ViewBag.Current = "Quiz";
            return View();
        }

        [HandleError]
        public ActionResult Quiz2()
        {
            ViewBag.Message = "Your quiz2 page.";
            ViewBag.Current = "Quiz2";
            return View();
        }

        [HandleError]
        public ActionResult Quiz3()
        {
            ViewBag.Message = "Your quiz3 page.";
            ViewBag.Current = "Quiz3";
            return View();
        }

        [HandleError]
        public ActionResult Image_Game()
        {
            ViewBag.Message = "Your game page.";
            ViewBag.Current = "Image_Game";
            return View();
        }

        [HandleError]
        public ActionResult Book_Shelf()
        {
            ViewBag.Message = "Book_shelf";
            ViewBag.Current = "Book_Shelf";
            return View();
        }

        [HandleError]
        public ActionResult Additional_Tips()
        {
            ViewBag.Current = "Additional_Tips";
            return View();
        }

        [HandleError]
        public ActionResult Send_Email()
        {
            ViewBag.Current = "Send_Email";
            return View(new SendEmailViewModel());
        }

        

        [HttpPost]
        [HandleError]
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