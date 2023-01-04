using Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Negocios.CrudCotizacion;
using Negocios.CrudIVA;

namespace Cotizador.Controllers
{
    public class IVAController : Controller
    {
        private readonly CrearIVA CrearIVA;
        private readonly EditarIVA EditarIVA;
        private readonly EliminarIVA EliminarIVA;
        private readonly BuscadorIVAPorId BuscadorIVAPorId;
        private readonly LectorIVA LectorIVA;
        public IVAController() {
            CrearIVA = new CrearIVA();
            EditarIVA = new EditarIVA();
            EliminarIVA = new EliminarIVA();
            BuscadorIVAPorId = new BuscadorIVAPorId();
            LectorIVA = new LectorIVA();
        }
        // GET: IVAController1
        public ActionResult Index()
        {
            IVA d = LectorIVA.Leer();
            if(d == null)
            {
                d = new IVA { Valor = 0};
            }
            return View(d);
        }
        // GET: IVAController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: IVAController1/Create
        [HttpPost]
        public ActionResult Create(IVA d)
        {
            CrearIVA.Crear(d);
            return RedirectToAction("Index");
        }

        // GET: IVAController1/Edit/5
        public ActionResult Edit(int id)
        {

            return View(BuscadorIVAPorId.Buscar(id));
        }

        // POST: IVAController1/Edit/5
        [HttpPost]
        public ActionResult Edit(IVA d)
        {
            EditarIVA.Editar(d);
            return RedirectToAction("Index");
        }

        // GET: IVAController1/Delete/5
        public ActionResult Delete(int id)
        {

            EliminarIVA.Eliminar(BuscadorIVAPorId.Buscar(id));
            return RedirectToAction("Index");
        }
    }
}
