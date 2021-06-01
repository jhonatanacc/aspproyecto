using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using aspproyecto.Models;


namespace aspproyecto.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Index()
        {
            using (var db = new inventario2021Entities () )
            {
                return View(db.usuario.ToList());
            }
              
        }
    public ActionResult create()
        {
            return View () ;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult create (usuario usuario)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                using (var db = new inventario2021Entities())
                {
                    db.usuario.Add(usuario);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

            }catch(Exception ex)
            {
                ModelState.AddModelError("", "Error" + ex);
                return View();
            }


        }


    }


}