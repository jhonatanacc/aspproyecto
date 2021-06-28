using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using aspproyecto.Models;


namespace aspproyecto.Controllers
{
    public class ProductoCompraController : Controller
    {
        // GET: Producto
        public ActionResult Index()
        {
            using (var db = new inventario2021Entities())
            {
                return View(db.producto_compra.ToList());
            }
        }

        public static string NombreProveedor(int idProveedor)
        {
            using (var db = new inventario2021Entities())
            {
                return db.proveedor.Find(idProveedor).nombre;
            }
        }

        public ActionResult ListarProveedores()
        {
            using (var db = new inventario2021Entities())
            {
                return PartialView(db.proveedor.ToList());
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(producto_compra newProductoCompra)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                using (var db = new inventario2021Entities())
                {
                    db.producto_compra.Add(newProductoCompra);
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
                producto_compra productoCompraDetalle = db.producto_compra.Where(a => a.id == id).FirstOrDefault();
                return View(productoCompraDetalle);
            }
        }

        public ActionResult Delete(int id)
        {
            using (var db = new inventario2021Entities())
            {
                var productoCompraDelete = db.producto_compra.Find(id);
                db.producto_compra.Remove(productoCompraDelete);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(int id)
        {
            try
            {
                using (var db = new inventario2021Entities())
                {
                    producto_compra productoCompra = db.producto_compra.Where(a => a.id == id).FirstOrDefault();
                    return View(productoCompra);
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
        public ActionResult Edit(producto_compra productoCompraEdit)
        {
            if (!ModelState.IsValid)
                return View();
            try
            {
                using (var db = new inventario2021Entities())
                {
                    var producto_compra = db.producto_compra.Find(productoCompraEdit.id);
                    producto_compra.id_compra = productoCompraEdit.id_compra;
                    producto_compra.id_producto = productoCompraEdit.id_producto;
                    producto_compra.cantidad = productoCompraEdit.cantidad;

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