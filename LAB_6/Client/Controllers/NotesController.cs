using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Laba6;
using WSSAAModel;
using Note = WSSAAModel.Note;

namespace Client.Controllers
{
    public class NotesController : Controller
    {
        /*        private WSSAAModel.WSSAAEntities db = new WSSAAModel.WSSAAEntities(new Uri("http://localhost:80/WCFDataService/WDSBVD.svc"));
        */
        private WSSAAModel.WSSAAEntities db = new WSSAAModel.WSSAAEntities(new Uri("https://localhost:44360/WCFDataService/WDSBVD.svc"));

        // GET: Students
        public ActionResult Index()
        {
            return View(db.Note.ToList());
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
        public ActionResult Create([Bind(Include = "subj,note1,student_id")] Note note)
        {
            if (ModelState.IsValid)
            {
                var lastNoteId = db.Note.OrderByDescending(s => s.id).FirstOrDefault()?.id;
                note.id = (int)lastNoteId + 1;
                db.AddObject("Note", note);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(note);
        }

        // GET: Students/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            List<Note> noteList = db.Note.ToList();
            Note note = noteList.FirstOrDefault(s => s.id == id);
            if (note == null)
            {
                return HttpNotFound();
            }
            return View(note);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,subj,note1,student_id")] Note note)
        {
            if (ModelState.IsValid)
            {
                var noteToChange = (from notech in db.Note
                                       where notech.id == note.id
                                       select notech).Single();
                noteToChange.subj = note.subj;
                noteToChange.note1 = note.note1;
                noteToChange.student_id = note.student_id;
                db.UpdateObject(noteToChange);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(note);
        }

        // GET: Students/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            List<Note> noteList = db.Note.ToList();
            Note note = noteList.FirstOrDefault(s => s.id == id);
            if (note == null)
            {
                return HttpNotFound();
            }
            return View(note);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var noteToDelete = (from note in db.Note
                                   where note.id == id
                                   select note).Single();
            db.DeleteObject(noteToDelete);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
