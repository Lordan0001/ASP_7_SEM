using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Laba6;
using WSSAAModel;
using Student = WSSAAModel.Student;

namespace Client.Controllers
{
    public class StudentsController : Controller
    {
        /* private WSSAAModel.WSSAAEntities db = new WSSAAModel.WSSAAEntities(new Uri("http://localhost:80/WCFDataService/WDSBVD.svc"));*/

        private WSSAAModel.WSSAAEntities db = new WSSAAModel.WSSAAEntities(new Uri("https://localhost:44360/WCFDataService/WDSBVD.svc"));
        // GET: Students
        public ActionResult Index()
        {
            return View(db.Student.ToList());
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name")] Student student)
        {
            if (ModelState.IsValid)
            {
                var lastStudentId = db.Student.OrderByDescending(s => s.id).FirstOrDefault()?.id;
                student.id = (int)lastStudentId + 1;
                db.AddObject("Student", student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(student);
        }

        // GET: Students/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            List<Student> studentList = db.Student.ToList();
            Student student = studentList.FirstOrDefault(s => s.id == id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Name")] Student student)
        {
            if (ModelState.IsValid)
            {
                var studentToChange = (from studentch in db.Student
                                       where studentch.id == student.id
                                       select studentch).Single();
                studentToChange.Name = student.Name;
                db.UpdateObject(studentToChange);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // GET: Students/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            List<Student> studentList = db.Student.ToList();
            Student student = studentList.FirstOrDefault(s => s.id == id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var studentToDelete = (from student in db.Student
                                   where student.id == id
                                   select student).Single();
            db.DeleteObject(studentToDelete);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
