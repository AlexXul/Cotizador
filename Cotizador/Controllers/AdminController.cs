using Entidades;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Negocios;
 
using System.Collections.Generic;
using System.IO;
using System.Linq;
 

namespace CotizadorDatacom.Controllers
{
    public class AdminController : Controller
    {
        private readonly LeerProducto Lector;
        private readonly CrearRangoProducto RegistradorRango;
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly LectorArchivo LectorExcel;


        public AdminController(IWebHostEnvironment hostEnvironment)
        {
            Lector = new LeerProducto();
            RegistradorRango = new CrearRangoProducto();
            _hostEnvironment = hostEnvironment;
            LectorExcel = new LectorArchivo();

        }
        // GET: AdminController
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SubirExcel()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SubirExcel(string name)
        {
            var f = (from files in Request.Form.Files select files).FirstOrDefault();

            bool exito = (f != null) ? UploadedFile(f)!=null : false;

            if (exito)
            {
                ViewBag.MensajeExito = "Archivo subido";
            }
            else
            {
                ViewBag.MensajeError = "Error al subir archivo";
            }
            return View();
        }
        
        public ActionResult VerDatosExcel()
        {
            string wwwRootPath = _hostEnvironment.WebRootPath;
            string Path = "productos.xlsx";
           
            if(!System.IO.File.Exists(wwwRootPath + "/" + Path)){
                ViewBag.Mensaje = $"No existe el archivo: {Path}";
                return View();
            }
            IEnumerable<Producto> DatosLeidos = LectorExcel.Leer(wwwRootPath + "/" + Path);
            return View(DatosLeidos);
        }

        public ActionResult ExportarDatos()
        {
            string wwwRootPath = _hostEnvironment.WebRootPath;
            string Path = "productos.xlsx";

            if (!System.IO.File.Exists(wwwRootPath + "/" + Path))
            {
                ViewBag.MensajeError = $"No existe el archivo: {Path}";
                return View();
            }
            
            IEnumerable<Producto> DatosLeidos = LectorExcel.Leer(wwwRootPath + "/" + Path);
            RegistradorRango.Crear(DatosLeidos);

            ViewBag.MensajeExito = $"Se agregaron {DatosLeidos.Count()} productos ala BD del archivo: {Path}";
            return View();
        }


        public JsonResult Ejemplo()
        {
            return Json(Lector.Leer());
        }
        private string UploadedFile(IFormFile file)
        {
            string fileName = null;
     
            string wwwRootPath = _hostEnvironment.WebRootPath;
            string extension = Path.GetExtension(file.FileName);
            fileName = "productos"+ extension;

            string path = Path.Combine(wwwRootPath + "/", fileName);
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }

            return fileName;
        }
    }
}
