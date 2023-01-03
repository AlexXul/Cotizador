using Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Negocios.CrudFactura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Negocios.Utilerias;

namespace Cotizador.Controllers
{
    public class FacturaController : Controller
    {
        private readonly CrearFactura CrearFactura;
        private readonly ObtenerUltimaFactura ObtenerUltimaFactura;
        private readonly EditarFactura EditarFactura;
        private readonly ObtenerFacturaPorId ObtenerFacturaPorId;

        public FacturaController()
        {
            CrearFactura = new CrearFactura();
            ObtenerUltimaFactura = new ObtenerUltimaFactura();
            EditarFactura = new EditarFactura();
            ObtenerFacturaPorId = new ObtenerFacturaPorId();
        }
        public JsonResult Crear()
        {
            Factura f = new Factura { Fecha = DateTime.Now};
            CrearFactura.Crear(f);
            return Json(new { succes = true });
        }
        public JsonResult ObtenerInfoUltimaFactura()
        {
            Factura ul = ObtenerUltimaFactura.Obtener();
            if(ul == null)
            {
                return Json(new { succes = false });
            }
            ul.Folio = GeneradorFolio.Generar(ul.Id);
       
            return Json(new { succes = true,factura=ul });
        }
        public JsonResult FinalizarUltimaFactura()
        {
            Factura f = ObtenerUltimaFactura.Obtener();
            f.Finalizado = true;
            EditarFactura.Editar(f);

            return Json(new { succes = true });
        }
        // GET: FacturaController
        public ActionResult Index()
        {
            return View();
        }

        // GET: FacturaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FacturaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FacturaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FacturaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FacturaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FacturaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FacturaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
