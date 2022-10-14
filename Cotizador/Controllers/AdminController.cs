using Entidades;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Negocios;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CotizadorDatacom.Controllers
{
    public class AdminController : Controller
    {
        private readonly IWebHostEnvironment _hostEnvironment;
        private readonly LectorArchivo LectorExcel;


        public AdminController(IWebHostEnvironment hostEnvironment)
        {
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
                ViewBag.Mensaje = "Archivo subido";
            }
            else
            {
                ViewBag.Mensaje = "Error al subir archivo";
            }
            return View();
        }
        
        public ActionResult VerDatosExcel()
        {
            string wwwRootPath = _hostEnvironment.WebRootPath;
            string Path = "productos.xlsx";

            IEnumerable<Producto> DatosLeidos =  LectorExcel.Leer(wwwRootPath+"/"+Path);

         

            return View(DatosLeidos);
        }

        
        // GET: AdminController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

 
        public ActionResult ExportarDatos()
        {
                return View();
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
