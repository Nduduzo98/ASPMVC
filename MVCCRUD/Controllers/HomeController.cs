using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCCRUD.Controllers
{
    public class HomeController : Controller
    {

        MVCCRUDDBContext _context = new MVCCRUDDBContext();
        public ActionResult Index()
        {
            //return list
            var listofData = _context.Students.ToList();
            return View(listofData);
        }

        //Http Get Method
        [HttpGet]

        public ActionResult Create()
        {
            return View();
        }

        //Http Post Method
        [HttpPost]
        public ActionResult Create(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();

            ViewBag.Message = "Data Saved Successfully";

            return RedirectToAction("index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = _context.Students.Where(x => x.StudentId == id).FirstOrDefault();
            return View(data);
        }

        [HttpPost]
        public ActionResult Edit(Student student)
        {
            var data = _context.Students.Where(x => x.StudentId == student.StudentId).FirstOrDefault();
            if(data != null)
            {
                data.StudentCity = student.StudentCity;
                data.StudentName = student.StudentName;
                data.StudentFees = student.StudentFees;

                _context.SaveChanges();
            }
            return RedirectToAction("index");
        }
        public ActionResult Detail(int id)
        {
            var data = _context.Students.Where(x => x.StudentId == id).FirstOrDefault();
            return View(data);

        }

        public ActionResult Delete(int id)
        {
            var data = _context.Students.Where(x => x.StudentId == id).FirstOrDefault();
            _context.Students.Remove(data);
            _context.SaveChanges();
            ViewBag.Message = "Record has been deleted";
            return RedirectToAction("index");
        }
    }
}