using Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Negocios.CrudCotizacion;
using Negocios.CrudDescuento;

namespace Cotizador.Controllers
{
    public class DescuentoController : Controller
    {
        private readonly CrearDescuento CrearDescuento;
        private readonly EditarIVA EditarDescuento;
        private readonly EliminarDescuento EliminarDescuento;
        private readonly BuscadorIVAPorId BuscadorDescuentoPorId;
        private readonly LectorDescuento LectorDescuento;
        public DescuentoController() {
            CrearDescuento = new CrearDescuento();
            EditarDescuento = new EditarIVA();
            EliminarDescuento = new EliminarDescuento();
            BuscadorDescuentoPorId = new BuscadorIVAPorId();
            LectorDescuento = new LectorDescuento();
        }
        // GET: DescuentoController1
        public ActionResult Index()
        {
            Descuento d = LectorDescuento.Leer();
            if(d == null)
            {
                d = new Descuento { Valor = 0};
            }
            return View(d);
        }
        // GET: DescuentoController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DescuentoController1/Create
        [HttpPost]
        public ActionResult Create(Descuento d)
        {
            CrearDescuento.Crear(d);
            return RedirectToAction("Index");
        }

        // GET: DescuentoController1/Edit/5
        public ActionResult Edit(int id)
        {

            return View(BuscadorDescuentoPorId.Buscar(id));
        }

        // POST: DescuentoController1/Edit/5
        [HttpPost]
        public ActionResult Edit(Descuento d)
        {
            EditarDescuento.Editar(d);
            return RedirectToAction("Index");
        }

        // GET: DescuentoController1/Delete/5
        public ActionResult Delete(int id)
        {

            EliminarDescuento.Eliminar(BuscadorDescuentoPorId.Buscar(id));
            return RedirectToAction("Index");
        }
    }
}
