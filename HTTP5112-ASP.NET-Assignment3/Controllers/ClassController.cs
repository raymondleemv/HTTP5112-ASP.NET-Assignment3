using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc;
using HTTP5112Assignment3.Models;

namespace HTTP5112Assignment3.Controllers
{
    public class ClassController : Controller
    {
        // GET: Class
        public ActionResult Index()
        {
            return View();
        }

        //GET : /Class/List
        public ActionResult List()
        {
            ClassDataController controller = new ClassDataController();
            IEnumerable<Class> Classes = controller.ListClass();
            return View(Classes);
        }

        //GET : /Class/Show/{id}
        public ActionResult Show(int id)
        {
            ClassDataController classController = new ClassDataController();
            Class NewClass = classController.FindClass(id);
            TeacherDataController teacherController = new TeacherDataController();
            Teacher Teacher = teacherController.FindTeacher(NewClass.TeacherId);
            ViewBag.Teacher = Teacher;

            return View(NewClass);
        }
    }
}