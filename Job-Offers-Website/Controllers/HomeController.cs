using Job_Offers_Website.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            var list = db.Categories.ToList();
            return View(list);
        }

        public ActionResult Details(int jobId)
        {
            var job = db.Jobs.Find(jobId);
            if (job == null)
            {
                return HttpNotFound();
            }
            Session["jobid"] = jobId;
            return View(job);
        }
        [Authorize]
        [HttpGet]
        public ActionResult Apply()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Apply(string Message)
        {
            var userId = User.Identity.GetUserId();
            var jobId = (int)Session["jobid"];

            var check = db.ApplyForJobs.Where(a => a.jobId == jobId && a.userId == userId).ToList();


            if (check.Count < 1)
            {
                var job = new ApplyForJob();
                job.userId = userId;
                job.jobId = jobId;
                job.Message = Message;
                job.ApplyDate = DateTime.Now;

                db.ApplyForJobs.Add(job);
                db.SaveChanges();
                ViewBag.Result = "you Appled Successfully !";
            }
            else
            {
                ViewBag.Result = "you Appled this job !";
            }

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}