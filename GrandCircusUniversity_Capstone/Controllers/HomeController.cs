using GrandCircusUniversity_Capstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GrandCircusUniversity_Capstone.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListOfStudents()
        {
            GCUniversityEntities ORM = new GCUniversityEntities();
            ViewBag.StudentList = ORM.Students.ToList();
            return View();
        }

        public ActionResult ListOfCourses()
        {
            GCUniversityEntities ORM = new GCUniversityEntities();
            ViewBag.CourseList = ORM.Courses.ToList();
            return View();

        }
        public ActionResult DeleteStudent(int Id)
        {
            GCUniversityEntities ORM = new GCUniversityEntities();
           
            List<StudentCourse> scList = ORM.Students.Find(Id).StudentCourses.ToList();
            ORM.StudentCourses.RemoveRange(scList);

            Student found = ORM.Students.Find(Id);
            
            ORM.Entry(found).State = System.Data.Entity.EntityState.Deleted;
           
            ORM.SaveChanges();
            return RedirectToAction("ListOfStudents");
        }

        public ActionResult DeleteCourse(int Id)
        {
            GCUniversityEntities ORM = new GCUniversityEntities();
            List<StudentCourse> courseList = ORM.StudentCourses.
                Where(x => x.CourseID == Id).ToList();
           
            foreach (StudentCourse studentCourse in courseList)
            {
                ORM.StudentCourses.Remove(studentCourse);
            }
            Course found = ORM.Courses.Find(Id);
            ORM.Courses.Remove(found);
            ORM.SaveChanges();
            return RedirectToAction("ListOfCourses");
        }
        public ActionResult AddStudent()
        {
            return View();
        }

        public ActionResult SaveNewStudent(Student newStudent)
        {
            GCUniversityEntities ORM = new GCUniversityEntities();
            ORM.Students.Add(newStudent);
            ORM.SaveChanges();
            return RedirectToAction("ListOfStudents");
        }

        public ActionResult AddCourse()
        {
            return View();
        }

        public ActionResult SaveNewCourse(Course newCourse)
        {
            GCUniversityEntities ORM = new GCUniversityEntities();
            ORM.Courses.Add(newCourse);
            ORM.SaveChanges();
            return RedirectToAction("ListOfCourses");
        }

        public ActionResult EditStudent(int Id)
        {
            GCUniversityEntities ORM = new GCUniversityEntities();
            ViewBag.ThisStudent = ORM.Students.Find(Id);
            return View();
        }

        public ActionResult SaveStudentUpdates(Student updatedStudent)
        {
            GCUniversityEntities ORM = new GCUniversityEntities();
            Student oldStudent = ORM.Students.Find(updatedStudent.ID);
            oldStudent.FirstName = updatedStudent.FirstName;
            oldStudent.LastName = updatedStudent.LastName;
            oldStudent.Phone = updatedStudent.Phone;
            oldStudent.Address = updatedStudent.Address;

            ORM.Entry(oldStudent).State = System.Data.Entity.EntityState.Modified;
            ORM.SaveChanges();
            return RedirectToAction("ListOfStudents");
        }
        public ActionResult EditCourse(int Id)
        {
            GCUniversityEntities ORM = new GCUniversityEntities();
            ViewBag.ThisCourse = ORM.Courses.Find(Id);
            return View();

        }
        public ActionResult SaveCourseUpdates(Course updatedCourse)
        {
            GCUniversityEntities ORM = new GCUniversityEntities();
            Course oldCourse = ORM.Courses.Find(updatedCourse.ID);
            oldCourse.Name = updatedCourse.Name;
            oldCourse.Category = updatedCourse.Category;


            ORM.Entry(oldCourse).State = System.Data.Entity.EntityState.Modified;
            ORM.SaveChanges();
            return RedirectToAction("ListOfCourses");
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