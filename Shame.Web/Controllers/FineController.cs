using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shame.Web.Models.Fine;

namespace Shame.Web.Controllers
{
    public class FineController : Controller
    {
        //
        // GET: /Fine/
        public ActionResult Index()
        {
            var model = new FineNominationModel
            {
                Title = "Nominate an offender",
                Followers = new List<string>
                {
                    "@Ruan",
                    "@Farzana",
                    "@Rayno",
                    "@Sean",
                    "@Leon",
                    "@Jonathan"
                }
            };
            return View(model);
        }


        public ActionResult _FineFeed()
        {
            var model = new List<string>
            {
                "Fine",
                "Fine",
                "Fine",
                "Fine",
                "Fine",
                "Fine",
                "Fine",
                "Fine"
            };
            return View(model);
        }
        //
        // GET: /Fine/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Fine/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Fine/Create
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
        // GET: /Fine/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Fine/Edit/5
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
        // GET: /Fine/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Fine/Delete/5
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
