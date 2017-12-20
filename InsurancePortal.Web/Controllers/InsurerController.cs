using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InsurancePortal.Web.Controllers
{
    public class InsurerController : Controller
    {
        // GET: Insurer
        public ActionResult Index()
        {
            return View();
        }

        // GET: Insurer/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Insurer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Insurer/Create
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

        // GET: Insurer/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Insurer/Edit/5
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

        // GET: Insurer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Insurer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
