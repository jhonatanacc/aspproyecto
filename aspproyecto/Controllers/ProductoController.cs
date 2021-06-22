using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using aspproyecto.Models;

namespace aspproyecto.Controllers
{
    public class ProductoController : Controller
    {
        // GET: Producto
        public ActionResult Index()
        {
            using (var db = new inventario2021Entities())

                return View(db.producto.ToList());

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
    }
}