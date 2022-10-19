
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
        private readonly CrearCotizacion CrearCotizacion;
        private readonly LeerCotizacion LectorCotizacion;
        private readonly ObtenerExistenciaProductoEnCotizacion ObtenerExistenciaProducto;
        private readonly EditarCotizacion EditarCotizacion;
        private readonly EliminarCotizacion EliminarCotizacion;
        private readonly ObtenerCotizacion ObtenerCotizacion;
        private readonly ObtenerCotizacionPorIdProducto ObtenerCotizacionPorIdProducto;
        private readonly BuscadorProducto BuscadorProducto;
        private readonly ObtenerUltimaFactura ObtenerUltimaFactura;
        public CotizadorController()
        {
            Lector = new LeerProducto();
            CrearCotizacion = new CrearCotizacion();
            LectorCotizacion = new LeerCotizacion();
            ObtenerExistenciaProducto = new ObtenerExistenciaProductoEnCotizacion();
            EditarCotizacion = new EditarCotizacion();
            EliminarCotizacion = new EliminarCotizacion();
            ObtenerCotizacion = new ObtenerCotizacion();
            ObtenerCotizacionPorIdProducto = new ObtenerCotizacionPorIdProducto();
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
                factura = ObtenerCotizacionPorIdProducto.Obtener(id);
                factura.Cantidad += cantidad;
                EditarCotizacion.Editar(factura);
            }
            else
            {
                factura.FacturaId = idFactura;
                CrearCotizacion.Crear(factura);
            }
            return RedirectToAction("Index");
        }

        // GET: Cotizar/Create
        public ActionResult Cotizacion()
        {
            return View(LectorCotizacion.Leer());
        }

         

        // GET: Cotizar/Edit/5
        public ActionResult Edit(int id, int cantidad)
        {
            Cotizacion c = ObtenerCotizacion.Obtener(id);
            c.Cantidad = cantidad;
            EditarCotizacion.Editar(c);
            return RedirectToAction("Cotizacion");
        }

       
 
        public ActionResult Delete(int id)
        {
            EliminarCotizacion.Eliminar(ObtenerCotizacion.Obtener(id));
            return RedirectToAction("Cotizacion");
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
                factura = ObtenerCotizacionPorIdProducto.Obtener(id);
                factura.Cantidad += cantidad;
                EditarCotizacion.Editar(factura);
            }
            else
            {
                factura.FacturaId = idFactura;
                CrearCotizacion.Crear(factura);
            }
     
            return Json(new { succes = true });
        }

    }
}
