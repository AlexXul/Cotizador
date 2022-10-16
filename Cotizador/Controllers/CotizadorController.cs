
using Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Negocios;
using Negocios.CrudCotizacion;
using Negocios.CrudFactura;
using Negocios.CrudProducto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cotizador.Controllers
{
    public class CotizadorController : Controller
    {
        private readonly LeerProducto Lector;
        private readonly CrearCotizacion CrearFactura;
        private readonly LeerCotizacion LectorFactura;
        private readonly ObtenerExistenciaProductoEnCotizacion ObtenerExistenciaProducto;
        private readonly EditarCotizacion EditarFactura;
        private readonly EliminarCotizacion EliminarFactura;
        private readonly ObtenerCotizacion ObtenerFactura;
        private readonly ObtenerCotizacionPorIdProducto ObtenerFacturaPorIdProducto;
        private readonly BuscadorProducto BuscadorProducto;
        private readonly ObtenerUltimaFactura ObtenerUltimaFactura;
        public CotizadorController()
        {
            Lector = new LeerProducto();
            CrearFactura = new CrearCotizacion();
            LectorFactura = new LeerCotizacion();
            ObtenerExistenciaProducto = new ObtenerExistenciaProductoEnCotizacion();
            EditarFactura = new EditarCotizacion();
            EliminarFactura = new EliminarCotizacion();
            ObtenerFactura = new ObtenerCotizacion();
            ObtenerFacturaPorIdProducto = new ObtenerCotizacionPorIdProducto();
            BuscadorProducto = new BuscadorProducto();
            ObtenerUltimaFactura = new ObtenerUltimaFactura();
        }
        // GET: Cotizar
        public ActionResult Index()
        {
            return View(Lector.Leer());
        }

        // GET: Cotizar/Details/5
        public ActionResult Agregar(int cantidad, int id)
        {
            int idFactura = ObtenerUltimaFactura.Obtener().Id;

            bool existeProductoEnFactura = ObtenerExistenciaProducto.ObtenerExistencia(id);
            Cotizacion factura = new Cotizacion { Cantidad = cantidad, ProductoId = id };

            if (existeProductoEnFactura)
            {
                factura = ObtenerFacturaPorIdProducto.Obtener(id);
                factura.Cantidad += cantidad;
                EditarFactura.Editar(factura);
            }
            else
            {
                factura.FacturaId = idFactura;
                CrearFactura.Crear(factura);
            }
            return RedirectToAction("Index");
        }

        // GET: Cotizar/Create
        public ActionResult Cotizacion()
        {
            return View(LectorFactura.Leer());
        }

         

        // GET: Cotizar/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

       
 
        public ActionResult Delete(int id)
        {
            EliminarFactura.Eliminar(ObtenerFactura.Obtener(id));
            return RedirectToAction("VerFactura");
        }

        public JsonResult BuscarProducto (string buscado)
        {
            Producto pBuscado = BuscadorProducto.Buscar(buscado);
            return Json(new{ succes=pBuscado!=null,data=pBuscado});
        }
        public JsonResult AgregarProducto(int cantidad, int id)
        {
            int idFactura = ObtenerUltimaFactura.Obtener().Id;

            if (cantidad == 0 || id == 0)
            {
                return Json(new { succes = false,mensaje="Verifique los datos." });
            }
           
            bool existeProductoEnFactura = ObtenerExistenciaProducto.ObtenerExistencia(id);
            Cotizacion factura = new Cotizacion { Cantidad = cantidad, ProductoId = id };

            if (existeProductoEnFactura)
            {
                factura = ObtenerFacturaPorIdProducto.Obtener(id);
                factura.Cantidad += cantidad;
                EditarFactura.Editar(factura);
            }
            else
            {
                factura.FacturaId = idFactura;
                CrearFactura.Crear(factura);
            }
     
            return Json(new { succes = true });
        }

    }
}
