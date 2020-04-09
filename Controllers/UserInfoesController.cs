using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using style.Models;

namespace style.Controllers
{
    public class UserInfoesController : Controller
    {
        private DataBaseEntities db = new DataBaseEntities();

        // GET: UserInfoes
        public ActionResult Index()
        {
            return View(db.UserInfoes.ToList());
        }

        // GET: UserInfoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserInfo userInfo = db.UserInfoes.Find(id);
            if (userInfo == null)
            {
                return HttpNotFound();
            }
            return View(userInfo);
        }

        // GET: UserInfoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserID,UserName,UserEmail,UserPassowrd,UserAddress,UserBalance,UserType")] UserInfo userInfo)
        {
            if (ModelState.IsValid)
            {
                db.UserInfoes.Add(userInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userInfo);
        }

        // GET: UserInfoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserInfo userInfo = db.UserInfoes.Find(id);
            if (userInfo == null)
            {
                return HttpNotFound();
            }
            return View(userInfo);
        }

        // POST: UserInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserID,UserName,UserEmail,UserPassowrd,UserAddress,UserBalance,UserType")] UserInfo userInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userInfo);
        }

        // GET: UserInfoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserInfo userInfo = db.UserInfoes.Find(id);
            if (userInfo == null)
            {
                return HttpNotFound();
            }
            return View(userInfo);
        }

        // POST: UserInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserInfo userInfo = db.UserInfoes.Find(id);
            db.UserInfoes.Remove(userInfo);
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

        public ActionResult login()
        {
            Session["UserName"] = null;

            Session["UserType"] = null;

            return View();
        }

        [HttpPost]
        public ActionResult login([Bind(Include =("UserName,UserEmail,UserPassowrd,UserType"))] UserInfo User)
        {
            var res = db.UserInfoes.Where(x => x.UserEmail == User.UserEmail && x.UserPassowrd == User.UserPassowrd).ToList().FirstOrDefault();
            if (res !=null)
            {
                
                Session["UserName"] = res.UserName;

                Session["UserType"] = res.UserType;

                if (Session["UserName"] != null)
                {

                    return RedirectToAction("HomePage", "Items");
                }
                else
                    return View();

            }
            else
            {
                ViewBag.error = "The User Name or Password is Incorrect";
                    return View(User);


            }

            
        }

        public ActionResult logout()
        {
            Session["UserName"] = null;
            Session["UserType"] = null;


            return RedirectToAction("HomePage", "Items");
        }

    }
}
