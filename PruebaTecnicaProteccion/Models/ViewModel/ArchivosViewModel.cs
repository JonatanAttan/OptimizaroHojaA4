using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PruebaTecnicaProteccion.Models.ViewModel
{
    public class ArchivosViewModel
    {
        [Required]
        [DisplayName ("Imagen que desesas agregar:")]
        public HttpPostedFileBase Imagen { get; set; }
        [Required]
        [DisplayName("Hoja que deseas agregar")]
        public string Hoja { get; set; }
    }
}