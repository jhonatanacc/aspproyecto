using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using aspproyecto.Models;

namespace aspproyecto.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
      
        public ActionResult Index()
        {
            using (var db = new inventario2021Entities())
            {
                return View(db.cliente.ToList());
            }
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(cliente cliente)
        {
            if (!ModelState.IsValid)
                return View();
            try
            {
                using (var db = new inventario2021Entities())
                {
                    db.cliente.Add(cliente);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "error " + ex);
                return View();
            }

        }
        public ActionResult Edit(int id)
        {
            try
            {
                using (var db = new inventario2021Entities())
                {
                    cliente findUser = db.cliente.Where(a => a.id == id).FirstOrDefault();
                    return View(findUser);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "error " + ex);

                return View();
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(cliente clienteEdit)
        {
            try
            {
                using (var db = new inventario2021Entities())
                {
                    cliente user = db.cliente.Find(clienteEdit.id);

                    user.nombre = clienteEdit.nombre;
                    user.documento = clienteEdit.documento;
                    user.email = clienteEdit.email;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "error " + ex);
                return View();
            }
        }

        public ActionResult Details(int id)
        {
            using (var db = new inventario2021Entities())
            {
                cliente user = db.cliente.Find(id);
                return View(user);
            }
        }

        public ActionResult Delete(int id)
        {
            using (var db = new inventario2021Entities())
            {
                var cliente = db.cliente.Find(id);
                db.cliente.Remove(cliente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
}