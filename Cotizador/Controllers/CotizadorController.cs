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
        private readonly LeerFactura LeerFactura;
        private readonly ObtenerExistenciaProducto ObtenerExistenciaProducto;
        private readonly EditarFactura EditarFactura;
        private readonly EliminarFactura EliminarFactura;
        private readonly ObtenerFactura ObtenerFactura;
        private readonly ObtenerFacturaPorIdProducto ObtenerFacturaPorIdProducto;
        public CotizadorController()
        {
            Lector = new LeerProducto();
            CrearFactura = new CrearFactura();
            LeerFactura = new LeerFactura();
            ObtenerExistenciaProducto = new ObtenerExistenciaProducto();
            EditarFactura = new EditarFactura();
            EliminarFactura = new EliminarFactura();
            ObtenerFactura = new ObtenerFactura();
            ObtenerFacturaPorIdProducto = new ObtenerFacturaPorIdProducto();
            
        }
        
        public ActionResult Index()
        {
            return View(Lector.Leer());
        }

        // GET: CotizadorController/Details/5
        public ActionResult Agregar(int cantidad, int id) 
        {
            bool existeProductoFactura = ObtenerExistenciaProducto.ObtenerExistencia(id);
            Factura factura = new Factura { Cantidad = cantidad, ProductoId = id };
            if (existeProductoFactura)
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

        // GET: CotizadorController/Create
        public ActionResult VerFactura()
        {
            return View(LeerFactura.Leer());
        }

        // POST: CotizadorController/Create
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

        // GET: CotizadorController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CotizadorController/Edit/5
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

        // GET: CotizadorController/Delete/5
        public ActionResult Delete(int id)
        {
            EliminarFactura.Eliminar(ObtenerFactura.Obtener(id));
            return RedirectToAction("VerFactura");
        }

        // POST: CotizadorController/Delete/5
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
