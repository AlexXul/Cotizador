using System.Collections;
using System.Collections.Generic;
using Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Negocios.CrudFactura;
using Negocios.CrudViewFacturaProducto;
using Negocios.Utilerias;

namespace Cotizador.Controllers
{
    public class ViewFacturaProductoController : Controller
    {
        private readonly LeerViewFacturaProductoPorFacturaId LeerViewFacturaProductoPorFacturaId;
        private readonly CrearViewFacturaProducto CrearViewFacturaProducto;
        private readonly LeerViewFacturaProducto LeerViewFacturaProducto;
        private readonly ObtenerProductosPorIdFactura ObtenerProductosPorIdFactura;
        public ViewFacturaProductoController() {
            LeerViewFacturaProductoPorFacturaId = new LeerViewFacturaProductoPorFacturaId();
            LeerViewFacturaProducto = new LeerViewFacturaProducto();
            CrearViewFacturaProducto = new CrearViewFacturaProducto();
            ObtenerProductosPorIdFactura = new ObtenerProductosPorIdFactura();
        }
        // GET: ViewFacturaProductoController
        public ActionResult Index(int id)
        {
            IEnumerable<ViewFacturaProducto> datos;
            if (id == 0)
            {
                datos = LeerViewFacturaProducto.Leer();
            }
            else
            {
                datos = LeerViewFacturaProductoPorFacturaId.Leer(id);
            }

            return View(datos);
        }

        // GET: ViewFacturaProductoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ViewFacturaProductoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ViewFacturaProductoController/Create
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

        // GET: ViewFacturaProductoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ViewFacturaProductoController/Edit/5
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

        // GET: ViewFacturaProductoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ViewFacturaProductoController/Delete/5
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

        public JsonResult AddProductsToView(int id)
        {
            IEnumerable<Cotizacion> productos = ObtenerProductosPorIdFactura.Obtener(id);

            foreach(Cotizacion c in productos)
            {
                ViewFacturaProducto fP = new ViewFacturaProducto
                {
                    Cantidad = c.Cantidad,
                    DescripcionProducto = c.Producto.Descripcion,
                    Descuento = AplicarDescuento.ObtenerDescuento(),
                    FacturaId = c.FacturaId,
                    FechaCreacion = c.Factura.FechaCreacion,
                    FechaImpresion = c.Factura.FechaImpresion,
                    IVA = AplicarIVA.ObtenerIVA(),
                    NombreProducto = c.Producto.Nombre,
                    ProductoId= c.Producto.Id,
                    TotalPorProducto = c.SubTotal,
                    PrecioProducto = c.Producto.Precio
                };
                CrearViewFacturaProducto.Crear(fP);
            }

            return Json(new { succes = true, data = "" });
        }
    }
}
