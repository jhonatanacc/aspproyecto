using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace aspproyecto.Models
{
    public class ReporteCompra
    {
       
        public String nombreProducto { get; set; }

        public String descripcionProducto { get; set; }
        public DateTime fechaCompra { get; set; }

        public int percio_unitarioProducto { get; set; }

    }
}