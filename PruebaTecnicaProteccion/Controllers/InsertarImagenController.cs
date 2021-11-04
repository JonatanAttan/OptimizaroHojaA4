using PruebaTecnicaProteccion.Models.ViewModel;
using PruebaTecnicaProteccion.Logic;
using System.Web.Mvc;
using System;

namespace PruebaTecnicaProteccion.Controllers
{
    public class InsertarImagenController : Controller
    {
        // GET: InsertarImagen
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult InsertarImagen(ArchivosViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("Index", model);
                }

                return this.File(ProcesadoDeImagen.ProcesaImagenA4(model).ToArray(), "application/pdf");

            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(550, "Hay un problema" + ex.Message);
                //return RedirectToAction ("Index", "InsertarImagenController");
            }          
        }
    }
}