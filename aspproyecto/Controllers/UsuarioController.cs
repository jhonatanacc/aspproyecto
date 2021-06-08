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
            using (var db = new inventario2021Entities())
            {
                return View(db.usuario.ToList());
            }

        }
        public ActionResult create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult create(usuario usuario)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                using (var db = new inventario2021Entities())
                {
                    usuario.password = UsuarioController.HashSHA1(usuario.password);
                    db.usuario.Add(usuario);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error" + ex);
                return View();
            }


        }

        public static string HashSHA1(string value)
        {
            var sha1 = System.Security.Cryptography.SHA1.Create();
            var inputBytes = Encoding.ASCII.Getbytes(value);
            var hash = sha1.ComputeHash(inputBytes);

            var sb = new stringBuilder();
            for (var i = 0; i < hash.Length; i++)

            {
                sb.Append(hash[i].ToString("x2"));
            }
            return sb.Tostring();

        }

        public ActionResult Edit(int id)
        {

            try
            {
                using(var  db = new inventario2021Entities())
                {
                    usuario fundUser = db.usuario.Where(a => a.id == id).FirstOrdefault();
                    return View(findUser);
                }
            }
            catch  (Exception ex)
            {
                ModelState.AddModelError("", "error" + ex);
                return View();
            }
        }
    }
}