using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using HTTP5112Assignment3.Models;

namespace HTTP5112Assignment3.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher
        public ActionResult Index()
        {
            return View();
        }

        //GET : /Teacher/List
        public ActionResult List(string SearchKey = null)
        {
            TeacherDataController controller = new TeacherDataController();
            IEnumerable<Teacher> Teachers = controller.ListTeacher(SearchKey);
            ViewBag.SearchKey = SearchKey;
            return View(Teachers);
        }

        //GET : /Tecaher/Show/{id}
        public ActionResult Show(int id)
        {
            TeacherDataController controller = new TeacherDataController();
            Teacher NewTeacher = controller.FindTeacher(id);
            IEnumerable<Class> Classes = controller.ListClasses(id);
            ViewBag.classes = Classes;

            return View(NewTeacher);
        }
    }
}