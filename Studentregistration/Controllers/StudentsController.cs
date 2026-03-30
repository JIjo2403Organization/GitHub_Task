using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Studentregistration.Context;
using Studentregistration.Models;

namespace Studentregistration.Controllers
{
    public class StudentsController : Controller
    {

        private readonly StudentDbcontext _context;
        public StudentsController(StudentDbcontext context)
        {
            _context= context;
        }
        // GET: StudentsController
        public ActionResult Index()
        {
            var objrej=_context.students.Include(r => r.Batches).Include(r => r.Courses);
            return View(objrej);
        }

        // GET: StudentsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: StudentsController/Create
        public ActionResult Create()
        {
            List<Course> courses = new List<Course>();
            courses = _context.courses!.ToList();
            ViewBag.listofcourses = courses;
            List<Batch> batches = new List<Batch>();
            batches = _context.batches!.ToList();
            ViewBag.listofbatches = batches;
            return View();
        }

        // POST: StudentsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Id,FirstName,LastName,phone,Course_Id,Batch_id")] StudentRegistration objregistration)
        {
            if (ModelState.IsValid)
            {
                _context.students!.Add(objregistration);
                _context.SaveChanges();
                TempData["ResultOk"] = "Record Added Successfully !";
                return RedirectToAction("Index");
            }

            List<Course> courses = new List<Course>();
            courses = _context.courses!.ToList();
            ViewBag.listofcourses = courses;
            List<Batch> batches = new List<Batch>();
            batches = _context.batches!.ToList();
            ViewBag.listofbatches = batches;
            return View(objregistration);
        }

        // GET: StudentsController/Edit/5
        public ActionResult Edit(int id)
        {
            if(id==null || id == 0)
            {
                return NotFound();
            }
            StudentRegistration registation = _context.students!.Find(id)!;
            if(registation==null )
            {
                return NotFound();
            }
            ViewBag.batch_id = new SelectList(_context.batches, "Id", "BatchName", registation.Batch_id);
            ViewBag.course_id = new SelectList(_context.courses, "Id", "CourseName", registation.Course_Id);
            return View(registation);
        }

        // POST: StudentsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind ("Id,FirstName,LastName,phone,Course_Id,Batch_id")] StudentRegistration registation)
        {
            if (ModelState.IsValid)
            {
                _context.students.Update(registation);
                _context.SaveChanges();
                TempData["Result ok"] = "Data updated sucessfully";
                return RedirectToAction("index");
            }
            ViewBag.batch_id = new SelectList(_context.batches, "Id", "BatchName", registation.Batch_id);
            ViewBag.course_id = new SelectList(_context.courses, "Id", "CourseName", registation.Course_Id);
            return View(registation);
        }

        // GET: StudentsController/Delete/5
        public ActionResult Delete(int id)
        {

            if (id == null)
            {
                return NotFound();
            }
            var dleterecord = _context.students.Find(id);
            
            if (dleterecord != null)
            {
                _context.students.Remove(dleterecord);
                _context.SaveChanges();
                TempData["Result ok"]= "Data deleted sucessfully!";
               

            }

            return RedirectToAction("Index");

        }

        // POST: StudentsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Orderbyname()
        {
            var name = from n in _context.students!.Include(r => r.Batches).Include(r => r.Courses)
                       orderby n.FirstName ascending
                       select n;
            return View(name);
        }
        public ActionResult Orderbycourse()
        {
            var course = from n in _context.students!.Include(r => r.Batches).Include(r => r.Courses)
                         orderby n.Courses!.CourseName ascending
                         select n;
            return View(course);
        }
        public ActionResult Orderbybatch()
        {
            var batch = from n in _context.students!.Include(r => r.Batches).Include(r => r.Courses)
                        orderby n.Batches!.BatchName ascending
                        select n;
            return View(batch);
        }

    }
}
