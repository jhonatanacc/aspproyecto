using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using aspproyecto.Models;

namespace aspproyecto.Controllers { 
    public class CompraController : Controller
{
    // GET: Producto
    public ActionResult Index()
    {
        using (var db = new inventario2021Entities())
        {

            return View(db.compra.ToList());
        }
    }
        public static string NombreUsuario(int idUsuario)
        {
            using (var db = new inventario2021Entities())
            {
                return db.usuario.Find(idUsuario).nombre;
            }
        }
        public ActionResult ListarCompra()
    {
        using (var db = new inventario2021Entities())
        {
            return PartialView(db.compra.ToList());
        }
    }
    public ActionResult Create()
    {
        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(producto newCompra)
    {
        if (!ModelState.IsValid)
            return View();

        try
        {
            using (var db = new inventario2021Entities())
            {
                db.producto.Add(newCompra);
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
            compra compraDetalle = db.compra.Where(a => a.id == id).FirstOrDefault();
            return View(compraDetalle);
        }
    }
    public ActionResult Delete(int id)
    {
        using (var db = new inventario2021Entities())
        {
            var productDelete = db.compra.Find(id);
            db.compra.Remove(productDelete);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }

    public ActionResult Edit(int id)
    {
            if (!ModelState.IsValid)
                return View();
            try
        {
            using (var db = new inventario2021Entities())
            {
                producto compra= db.producto.Where(a => a.id == id).FirstOrDefault();
                return View(compra);
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
    public ActionResult Edit(compra compraEdit)
    {
        try
        {
            using (var db = new inventario2021Entities())
            {
                var producto = db.compra.Find(compraEdit.id);
                producto. fecha= compraEdit.fecha;
                producto.total = compraEdit.total;
                producto.id_cliente = compraEdit.id_cliente;
                producto.id_usuario = compraEdit.id_usuario;
                

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



}
}