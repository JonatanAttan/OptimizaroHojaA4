using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using PruebaTecnicaProteccion.Controllers;
using PruebaTecnicaProteccion.Models.ViewModel;
using System.Web.Mvc;

namespace PruebasUnitariasProteccion
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            InsertarImagenController controller = new InsertarImagenController();

            // Actuar
            ArchivosViewModel model = new ArchivosViewModel();

            model.Hoja = null;
            model.Imagen = null;

            ViewResult result = controller.InsertarImagen(model) as ViewResult;

            // Declarar           
            Assert.IsNotNull(result);
            
        }

        public void RedirectionTest()
        {
            InsertarImagenController controlador = new InsertarImagenController();

            ArchivosViewModel model = new ArchivosViewModel();

            model.Hoja = null;
            model.Imagen = null;

            HttpStatusCodeResult result = controlador.InsertarImagen(model) as HttpStatusCodeResult;

            Assert.AreEqual("")
        }
    }
}
