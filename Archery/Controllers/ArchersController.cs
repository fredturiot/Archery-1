﻿using Archery.Models;
using Archery.Data;

using System.Web.Mvc;


namespace Archery.Controllers
{
    public class ArchersController : Controller 
    {
        private ArcheryDbContext db = new ArcheryDbContext();
        // GET: Players
        public ActionResult Subscribe()
        {
            return View();
        }

        public ActionResult List( )
        {
            var dbArchers = db.Archers;
            Archer archer = new Archer
            {
                Email = dbArchers.Find(1).Email,
                FirstName = dbArchers.Find(1).FirstName,
                LastName = dbArchers.Find(1).LastName,
                BirthDate = dbArchers.Find(1).BirthDate,
                LicenseNumber = dbArchers.Find(1).LicenseNumber,
                Password = dbArchers.Find(1).Password
            };
            
            return View(archer);
        }

        // POST: Players
        [HttpPost]  // restreint la méthode Subscribe à la méhtode Htttp de type POST
        public ActionResult Subscribe(Archer archer )
        {
            
            //if(DateTime.Now.AddYears(-9) <= archer.BirthDate)
            //{
            //    // ViewBag.Erreur = "L'age n'est pas bon";
            //    // return View();
            //    ModelState.AddModelError("Birthdate", "Date de Naissance invalide: l'âge doit être au minimu de 9 ans"); // et l'erreur apparaitra dans la view car on valide sur la BirthDate
            //}

            if (ModelState.IsValid)
            {
                db.Archers.Add(archer);
                db.SaveChanges();
                ViewData["message"] = "Enregistrment réussi";
                // return RedirectToAction("index", "home");
            }
            else
            {
                return ViewBag.Error = "L'enregistrement du Tireur n'a pas pu être effectuée";
            }
            return View();
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (!disposing)
                this.db.Dispose();
        }










    }
}