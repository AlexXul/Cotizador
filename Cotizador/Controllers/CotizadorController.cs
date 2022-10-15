
using Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Negocios;
using Negocios.CrudFactura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cotizador.Controllers
{
    public class CotizadorController : Controller
    {
        private readonly LeerProducto Lector;
        private readonly CrearFactura CrearFactura;
        private readonly LeerFactura LectorFactura;
        private readonly ObtenerExistenciaProducto ObtenerExistenciaProducto;
        private readonly EditarFactura EditarFactura;
        private readonly EliminarFactura EliminarFactura;
        private readonly ObtenerFactura ObtenerFactura;
        private readonly ObtenerFacturaPorIdProducto ObtenerFacturaPorIdProducto;

        public CotizadorController()
        {
            Lector = new LeerProducto();
            CrearFactura = new CrearFactura();
            LectorFactura = new LeerFactura();
            ObtenerExistenciaProducto = new ObtenerExistenciaProducto();
            EditarFactura = new EditarFactura();
            EliminarFactura = new EliminarFactura();
            ObtenerFactura = new ObtenerFactura();
            ObtenerFacturaPorIdProducto = new ObtenerFacturaPorIdProducto();
        }
        // GET: Cotizar
        public ActionResult Index()
        {
            return View(Lector.Leer());
        }

        // GET: Cotizar/Details/5
        public ActionResult Agregar(int cantidad, int id)
        {
            bool existeProductoEnFactura = ObtenerExistenciaProducto.ObtenerExistencia(id);
            Factura factura = new Factura { Cantidad = cantidad, ProductoId = id };

            if (existeProductoEnFactura)
            {
                factura = ObtenerFacturaPorIdProducto.Obtener(id);
                factura.Cantidad += cantidad;
                EditarFactura.Editar(factura);
            }
            else
            {
                CrearFactura.Crear(factura);
            }
            return RedirectToAction("Index");
        }

        // GET: Cotizar/Create
        public ActionResult VerFactura()
        {
            return View(LectorFactura.Leer());
        }

        // POST: Cotizar/Create
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

        // GET: Cotizar/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Cotizar/Edit/5
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

        // GET: Cotizar/Delete/5
        public ActionResult Delete(int id)
        {
            EliminarFactura.Eliminar(ObtenerFactura.Obtener(id));
            return RedirectToAction("VerFactura");
        }

        // POST: Cotizar/Delete/5
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
