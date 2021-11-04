using PruebaTecnicaProteccion.Models.ViewModel;
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.text;

namespace PruebaTecnicaProteccion.Logic
{
    public class ProcesadoDeImagen
    {
        public static MemoryStream ProcesaImagenA4 (ArchivosViewModel model)
        {           
            string[] anchoPorLargo = model.Hoja.Split(',');
            byte[] datos;

            using (Stream inputStream = model.Imagen.InputStream)
            {
                MemoryStream memoryStream = inputStream as MemoryStream;
                if (memoryStream == null)
                {
                    memoryStream = new MemoryStream();
                    inputStream.CopyTo(memoryStream);
                }
                datos = memoryStream.ToArray();
            }

            Document documento = new Document(new Rectangle(float.Parse(anchoPorLargo[0]), float.Parse(anchoPorLargo[1])), 0f, 0f, 0f, 0f);
            iTextSharp.text.Image imagenProcesada = iTextSharp.text.Image.GetInstance(datos);

            if (imagenProcesada.Width > imagenProcesada.Height)
            {
                documento.SetPageSize(new Rectangle(float.Parse(anchoPorLargo[0]), float.Parse(anchoPorLargo[1])).Rotate());
            }
            if (imagenProcesada.Width > documento.PageSize.Width)
            {
                imagenProcesada.ScaleToFit(documento.PageSize);                
            }
            if (imagenProcesada.Height > documento.PageSize.Height)
            {
                imagenProcesada.ScaleToFit(documento.PageSize);                
            }

            MemoryStream archivoImprimir = new MemoryStream();
            PdfWriter writer = PdfWriter.GetInstance(documento, archivoImprimir);
            documento.AddTitle("Imagen Optimizada A4");
            documento.Open();
                       
            imagenProcesada.Alignment = Element.ALIGN_MIDDLE;
            imagenProcesada.Alignment = Element.ALIGN_CENTER;
            documento.Add(imagenProcesada);
            documento.Close();

            return archivoImprimir;
        }
    }
}