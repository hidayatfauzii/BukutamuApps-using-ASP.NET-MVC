using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//untuk keamanan
using System.Security;
using System.Web.Security;
//untuk keamanan

/*untuk identitas pengguna*/
using Microsoft.AspNet.Identity;

using TAS_SIUKDWStore.Models;
using TAS_SIUKDWStore.ViewModels;

namespace TAS_SIUKDWStore.Controllers
{


    //authorisasi hanya untuk pengunjung yang login
    [Authorize]
    public class MessageController : Controller
    {

        private TAS_SIUKDWStoreContext db = new TAS_SIUKDWStoreContext();

        public ActionResult Index()
        {

            var models = from d in db.Messages
                         orderby d.MessageId descending
                         select new MessageViewModel
                         {
                             MessageId = d.MessageId,
                             ContentMessage = d.ContentMessage,
                             UserName = d.UserProfiles.UserName,
                             TimeMessage = d.TimeMessage
                         };
            return View(models);

        }
        //
        // GET: /Buku/Details/5

        public ActionResult Details(int id = 0)
        {

            return View();
        }

        //
        // GET: /Buku/Create

        [Authorize]
        public ActionResult Create()
        {
            var usr = from f in db.UserProfiles
                      where f.UserName == HttpContext.User.Identity.Name
                      select f;

            ViewBag.UserId = new SelectList(usr, "UserId", "UserName");
            return View();
        }

        //
        // POST: /Buku/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Message msg)
        {


            if (ModelState.IsValid)
            {
                db.Messages.Add(msg);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(msg);
        }

        //
        // GET: /Buku/Edit/5
        public ActionResult Edit(int id)
        {
            Message msg = db.Messages.Find(id);
            if (msg == null)
            {
                return HttpNotFound();
            }
         return View(msg);
        }

        //
        // POST: /Buku/Edit/5

        [HttpPost]
        public ActionResult Edit(Message msg)
        {
            if (ModelState.IsValid)
            {
                db.Entry(msg).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(msg);
        }


        //
        // GET: /Buku/Delete/5
        public ActionResult Delete(int? id) 
        {
            var exst = db.Messages.Find(id);



            if (exst !=null)
            {
                Message msg = db.Messages.Find(id);
                db.Messages.Remove(msg);
                db.SaveChanges();
            }
            else
            {

            }
            //if (id == null)
            //{

            //}
            //else if (id <= 0 )
            //{

            //}
            //else if (ModelState.IsValid)
            //{
            //    Message msg = db.Messages.Find(id);
            //    db.Messages.Remove(msg);
            //    db.SaveChanges();


            //}
            return RedirectToAction("Index");
        }

        //
        // POST: /Buku/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Message msg = db.Messages.Find(id);
            db.Messages.Remove(msg);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}