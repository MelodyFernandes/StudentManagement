using StudentManagement.Data;
using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentManagement.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
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
        
        public ActionResult NewStudent()
        {
            ViewBag.Message = "Create Student.";
            DbData dbData = new DbData();
            List<Subject> subjects = dbData.GetSubject();
            Student sudent = new Student();
            sudent.Departments = dbData.GetDepartment();
            sudent.Compulsory = subjects.Where(s => s.Optional == false).ToList();
            sudent.Optional = subjects.Where(s => s.Optional == true).ToList();
            return View(sudent);
        }

        [HttpGet]
        public JsonResult GetSubject(int depId, bool optional)
        {
            DbData dbData = new DbData();
            List<Subject> subjects = dbData.GetSubject();
            var selSub = subjects.Where(s => s.Optional == optional && s.DepartmentId == depId).ToList();
            return Json(selSub, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CreateStudent(Student model)
        {
            DbData dbData = new DbData();
            var t = dbData.GetStudents();
            return View("Report",t.FirstOrDefault());
        }

    }
}