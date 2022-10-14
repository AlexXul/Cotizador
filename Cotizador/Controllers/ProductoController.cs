using Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Negocios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cotizador.Controllers
{
    public class ProductoController : Controller
    {
        private readonly CrearProducto Registrador;
        private readonly LeerProducto Lector;
        private readonly ObtenerProducto Recuperador;
        private readonly EditarProducto Actualizador;
        private readonly EliminarProducto Eliminador;
        public ProductoController()
        {
            Registrador = new CrearProducto();
            Lector = new LeerProducto();
            Recuperador = new ObtenerProducto();
            Actualizador = new EditarProducto();
            Eliminador = new EliminarProducto();
        }
        // GET: ProductoController
        public ActionResult Index()
        {
            
            return View(Lector.Leer());
        }

     
    

        // GET: ProductoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductoController/Create
        [HttpPost]

        public ActionResult Create( Producto producto)
        {
            Registrador.Crear(producto);
            return RedirectToAction("Index");
        }

        // GET: ProductoController/Edit/5
        public ActionResult Edit(int id)
        {
           
            return View(Recuperador.Obtener(id));
        }

        // POST: ProductoController/Edit/5
        [HttpPost]
        public ActionResult Edit(Producto producto)
        {
            Actualizador.Editar(producto);
            return RedirectToAction("Index");
        }

        // GET: ProductoController/Delete/5
        public ActionResult Delete(int id)
        {
            Producto productoEliminar = Recuperador.Obtener(id);
            Eliminador.Eliminar(productoEliminar);
            return RedirectToAction("Index");
        }

      
        
    }
}
