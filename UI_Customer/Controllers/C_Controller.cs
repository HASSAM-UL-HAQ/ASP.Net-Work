using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UI_Customer.Models;
using System.Data.Entity;

namespace UI_Customer.Controllers
{
    public class C_Controller : Controller
    {
        // GET: C_
        public ActionResult Index()
        {
            using(POSSystemEntities DBM=new POSSystemEntities())
            return View(DBM.users.ToList());
        }

        // GET: C_/Details/5
        public ActionResult Details(int id)
        {
            using (POSSystemEntities DBM=new POSSystemEntities())
            {
                return View(DBM.users.Where(x=>x.Id==id).First());
            }
            
        }

        // GET: C_/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: C_/Create
        [HttpPost]
        public ActionResult Create(user Udata)
        {
            try
            {
                // TODO: Add insert logic here
                using (POSSystemEntities DBM = new POSSystemEntities())
                {
                    DBM.users.Add(Udata);
                    DBM.SaveChanges();
                    
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: C_/Edit/5
        public ActionResult Edit(int id)
        {
            using(POSSystemEntities DBM=new POSSystemEntities())
            {
                return View(DBM.users.Where(x => x.Id == id).First());
            }
        }

        // POST: C_/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, user Udata)
        {
            try
            {
                // TODO: Add update logic here
                using (POSSystemEntities DBM = new POSSystemEntities())
                {
                    DBM.Entry(Udata).State = EntityState.Modified;
                    DBM.SaveChanges();
                
                }

                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: C_/Delete/5
        public ActionResult Delete(int id)
        {
            using (POSSystemEntities DBM = new POSSystemEntities())
            {
                return View(DBM.users.Where(x => x.Id == id).First());
            }
        }

        // POST: C_/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                using(POSSystemEntities DBM=new POSSystemEntities())
                {
                    user Udata = DBM.users.Where(x => x.Id == id).First();
                    DBM.users.Remove(Udata);
                    DBM.SaveChanges();

                }


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
