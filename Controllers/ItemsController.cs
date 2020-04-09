using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using style.Models;
using System.IO;





namespace style.Controllers
{
    
    public class ItemsController : Controller
    {
        private DataBaseEntities db = new DataBaseEntities();

       // GET: Items
       [HttpGet]
       [ActionName("Index")]
        public ActionResult Index_get()
        {
            

            return View(db.Items.ToList());
        }
        [HttpPost]
        [ActionName("Index")]
        public ActionResult Index_post(int search)

        {

            var res = db.Items.Where(x => x.Code == search).ToList();


            return View(res);


        }

       

        // GET: Items/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // GET: Items/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Items/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Code,ItemName,ItemDescription,ItemPrice,Department,logo")] Item item , HttpPostedFileBase imgFile)
        {
        
            string path = "";

            if (imgFile.FileName.Length>0)
            {
                path = "~/images/" + Path.GetFileName(imgFile.FileName);
                imgFile.SaveAs(Server.MapPath(path));

            }

            item.logo = path;



            if (ModelState.IsValid)
            {
                db.Items.Add(item);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(item);

            

        }

        // GET: Items/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: Items/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Code,ItemName,ItemDescription,ItemPrice,Department,logo")] Item item)
        {
            if (ModelState.IsValid)
            {
                db.Entry(item).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(item);
        }

        // GET: Items/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Item item = db.Items.Find(id);
            db.Items.Remove(item);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        
        [ActionName("getmanyrows")]
        public ActionResult getmanyrows_get()

        {
           


            Session["search"] = null;
            var res = db.Items.ToList();


            return View(res);

        }


        [HttpPost]
        
        public ActionResult getmanyrows_post(int search)
        {

            search = ViewBag.search;



            var res = db.Items.Where(x => x.Code ==search).ToList();



            return View(res);
        }

        public ActionResult HomePage()
        {

        var res = db.Items.ToList();


            return View(res);

        }
        
        public ActionResult boy()
        {

            var res = db.Items.Where(x => x.Department == "boy");

            return View(res);
        }
        public ActionResult man()
        {

            var res = db.Items.Where(x => x.Department == "man");

            return View(res);
        }

        public ActionResult women()
        {

            var res = db.Items.Where(x => x.Department == "women");

            return View(res);
        }

        public ActionResult girl()
        {

            var res = db.Items.Where(x => x.Department == "girl");

            return View(res);
        }

        public ActionResult baby()
        {

            var res = db.Items.Where(x => x.Department == "baby");

            return View(res);
        }


    }
   

}
