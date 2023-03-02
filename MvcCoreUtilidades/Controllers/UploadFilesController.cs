using Microsoft.AspNetCore.Mvc;
using MvcCoreUtilidades.Helpers;

namespace MvcCoreUtilidades.Controllers
{
    public class UploadFilesController : Controller
    {

        private HelperPathProvider helperPath;
        public UploadFilesController(HelperPathProvider helperPath)
        {
            this.helperPath = helperPath;
        }

        public IActionResult SubirFichero()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> SubirFichero
            (IFormFile fichero)
        {
            
            string fileName = fichero.FileName;
            //NUESTRA RUTA SERA UNA COMBINACION DE LOS DOS
            //LAS RUTAS SIEMPRE SE ESCRIBEN CON Path.Combine
            //QUE SE ADAPTA A CADA SERVER CORE
            string path = this.helperPath.MapPath(fileName, Folders.Uploads);
            using(Stream stream = new FileStream(path, FileMode.Create))
            {
                await fichero.CopyToAsync(stream);
            }
            ViewData["MENSAJE"] = "Fichero subido a " + path;
            return View();
        }

    }
}

     