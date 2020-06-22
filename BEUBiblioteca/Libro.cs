//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BEUBiblioteca
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Libro
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        [ScaffoldColumn(false)]
        public int idLibro { get; set; }
        [DataType(DataType.Text)]
        [Required(ErrorMessage = " El título es requerido"), MaxLength(100)]
        [Display(Name = "Título del Libro")]
        public string titulo { get; set; }
        [DataType(DataType.Text)]
        [Required(ErrorMessage = " El autor o los autores son requeridos"), MaxLength(100)]
        [Display(Name = "Autor(es)")]
        public string autores { get; set; }
        [DataType(DataType.Duration)]
        [Required(ErrorMessage = " El ISBN es requerido"), MinLength(13)]
        [Display(Name = "ISBN")]
        public string isbn { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha de Publicacion")]
        public System.DateTime fecha_publi { get; set; }
        [DataType(DataType.Duration)]
        [Range(1, 9999999, ErrorMessage = "La número de ejemplares debe ser un número")]
        [Required(ErrorMessage = "Los números de ejemplares son requeridos")]
        [Display(Name = "Número de Ejemplares")]
        public int nro_ejem { get; set; }
        [Display(Name = "Categoría")]
        public int categoria { get; set; }
    
        public virtual Categoria Categoria1 { get; set; }
    }
}