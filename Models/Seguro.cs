//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PruebaLafise.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    public partial class Seguro
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Seguro()
        {
            this.Poliza = new HashSet<Poliza>();
        }
        [DisplayName("Seguro")]
        public int IdSeguro { get; set; }
        [DisplayName("Tipo de Seguro")]
        public string DescripcionSeguro { get; set; }
        [DisplayName("Costo")]
        public decimal CostoSeguro { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Poliza> Poliza { get; set; }
    }
}
