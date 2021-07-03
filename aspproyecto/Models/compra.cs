//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace aspproyecto.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public partial class compra
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public compra()
        {
            this.producto_compra = new HashSet<producto_compra>();
        }
    
        public int id { get; set; }
        [Required(ErrorMessage = "Este campo no puede ir vacio")]
        public System.DateTime fecha { get; set; }
        [Required(ErrorMessage = "Este campo no puede ir vacio")]
        public int total { get; set; }
        [Required(ErrorMessage = "Este campo no puede ir vacio")]
        public int id_usuario { get; set; }
        [Required(ErrorMessage = "Este campo no puede ir vacio")]
        public int id_cliente { get; set; }
    
        public virtual cliente cliente { get; set; }
        [Required(ErrorMessage = "Este campo no puede ir vacio")]
        public virtual usuario usuario { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<producto_compra> producto_compra { get; set; }
    }
}
