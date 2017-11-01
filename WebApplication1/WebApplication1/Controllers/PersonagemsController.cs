using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Models.Contexto;

namespace WebApplication1.Controllers
{
    public class PersonagemsController : Controller
    {
        private PrimeiroContexto db = new PrimeiroContexto();

        // GET: Personagems
        public ActionResult Index()
        {
            return View(db.Personagems.ToList());
        }

        // GET: Personagems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personagem personagem = db.Personagems.Find(id);
            if (personagem == null)
            {
                return HttpNotFound();
            }
            return View(personagem);
        }

        // GET: Personagems/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Personagems/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PersonagemID,Nome,Descricao,ComidaFavorita,Altura")] Personagem personagem)
        {
            if (ModelState.IsValid)
            {
                db.Personagems.Add(personagem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(personagem);
        }

        // GET: Personagems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personagem personagem = db.Personagems.Find(id);
            if (personagem == null)
            {
                return HttpNotFound();
            }
            return View(personagem);
        }

        // POST: Personagems/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PersonagemID,Nome,Descricao,ComidaFavorita,Altura")] Personagem personagem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personagem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(personagem);
        }

        // GET: Personagems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personagem personagem = db.Personagems.Find(id);
            if (personagem == null)
            {
                return HttpNotFound();
            }
            return View(personagem);
        }

        // POST: Personagems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Personagem personagem = db.Personagems.Find(id);
            db.Personagems.Remove(personagem);
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
    }
}
