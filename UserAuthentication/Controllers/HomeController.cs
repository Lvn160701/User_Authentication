using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserAuthentication.Models;

namespace UserAuthentication.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext context = new ApplicationDbContext();
        [Authorize]
        public ActionResult Index()
        {
            //lấy userId đăng nhập
            var userID = User.Identity.GetUserId();
            var usercourse = context.UserCourse.Where(x => x.UserID == userID).ToList();
           
            return View(usercourse);
        }
        [CustomeAuthorize(Roles = "Teacher")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [CustomeAuthorize(Roles = "Student")]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [CustomeAuthorize(Roles = "Teacher")]
        public ActionResult ListUser(string id, string searchString, string sortOrder, string currentFilter)
        {


            ViewBag.FullNameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";


            var users = from s in context.Users
                        select s;
            switch (sortOrder)
            {
                case "name_desc":
                    users = users.OrderByDescending(s => s.FullName);
                    break;


                default:
                    users = users.OrderBy(s => s.FullName);
                    break;
            }
            if (!String.IsNullOrEmpty(searchString))
            {
                users = users.Where(s => s.FullName.Contains(searchString));
            }


            ViewBag.CurrentFilter = searchString;
            return View(users);
        }

        //lít course
        public ActionResult ListCourse(string id, string searchString, string sortOrder, string currentFilter)
        {


            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";


            var courses = from s in context.Course
                        select s;
            switch (sortOrder)
            {
                case "name_desc":
                    courses = courses.OrderByDescending(s => s.Name);
                    break;


                default:
                    courses = courses.OrderBy(s => s.Name);
                    break;
            }
            if (!String.IsNullOrEmpty(searchString))
            {
              courses = courses.Where(s => s.Name.Contains(searchString));
            }


            ViewBag.CurrentFilter = searchString;
            return View(courses);
        }

        //coursecategory
        public ActionResult CourseCategory(string id, string searchString, string sortOrder, string currentFilter)
        {


            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";


            var coursecategorys = from s in context.CourseCategories
                          select s;
            switch (sortOrder)
            {
                case "name_desc":
                    coursecategorys = coursecategorys.OrderByDescending(s => s.Name);
                    break;


                default:
                    coursecategorys = coursecategorys.OrderBy(s => s.Name);
                    break;
            }
            if (!String.IsNullOrEmpty(searchString))
            {
                coursecategorys = coursecategorys.Where(s => s.Name.Contains(searchString));
            }


            ViewBag.CurrentFilter = searchString;
            return View(coursecategorys);
        }



    }
}