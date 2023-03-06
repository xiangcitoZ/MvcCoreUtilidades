using Microsoft.AspNetCore.Mvc;
using MvcCoreUtilidades.Helpers;
using System.Net;
using System.Net.Mail;

namespace MvcCoreUtilidades.Controllers
{
    public class MailsController : Controller
    {
        private HelperUploadFiles helperUploadFiles;
        private HelperMail helperMail;

        public MailsController(HelperUploadFiles helperUploadFiles
            , HelperMail helperMail)
        {
            this.helperUploadFiles = helperUploadFiles;
            this.helperMail = helperMail;
        }

        public IActionResult SendMail()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SendMail
            (string para, string asunto, string mensaje
            , List<IFormFile> files)
        {
            if (files.Count != 0)
            {
                if (files.Count > 1)
                {
                    List<string> paths =
                        await this.helperUploadFiles.UploadFileAsync
                        (files, Folders.Temporal);
                    await this.helperMail.SendMailAsync(para, asunto, mensaje, paths);
                }
                else
                {
                    string path =
                        await this.helperUploadFiles.UploadFileAsync
                        (files[0], Folders.Temporal);
                    await this.helperMail.SendMailAsync(para, asunto, mensaje, path);
                }
            }
            else
            {
                await this.helperMail.SendMailAsync(para, asunto, mensaje);
            }
            ViewData["MENSAJE"] = "Email enviado correctamente";
            return View();
        }


    }


}

