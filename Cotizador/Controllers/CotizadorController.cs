
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
        private readonly BuscadorProducto BuscadorProducto;
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
            BuscadorProducto = new BuscadorProducto();
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
            if (cantidad == 0 || id == 0)
            {
                return Json(new { succes = false,mensaje="Verifique los datos." });
            }
           
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
     
            return Json(new { succes = true });
        }

    }
}
