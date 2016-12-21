using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Security;
using System.Web.Security;
//untuk keamanan

/*untuk identitas pengguna*/
using Microsoft.AspNet.Identity;

using System.Data;
using System.Data.Entity;
using System.Net;
using System.IO;
using PagedList;
using TAS_SIUKDWStore.Models;
using TAS_SIUKDWStore.ViewModels;

namespace TAS_SIUKDWStore.Controllers
{
    [Authorize(Users =("admin"))]
    public class AdminPageController : Controller
    {
        private TAS_SIUKDWStoreContext db = new TAS_SIUKDWStoreContext();
        //
        // GET: /AdminPage/

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
        // GET: /AdminPage/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /AdminPage/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /AdminPage/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /AdminPage/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /AdminPage/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /AdminPage/Delete/5

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Message gstbk = db.Messages.Find(id);
            if (gstbk == null)
            {
                return HttpNotFound();
            }
            return View(gstbk);
        }

        //
        // POST: /AdminPage/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Message gstbk = db.Messages.Find(id);
            db.Messages.Remove(gstbk);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
