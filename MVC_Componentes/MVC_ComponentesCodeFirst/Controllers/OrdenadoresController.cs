using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC_ComponentesCodeFirst.App_Data;
using MVC_ComponentesCodeFirst.Models;
using MVC_ComponentesCodeFirst.Models.ViewModels;
using MVC_ComponentesCodeFirst.Services;

namespace MVC_ComponentesCodeFirst.ControllersW
{
    public class OrdenadoresController : Controller
    {
        private readonly IRepositorioOrdenador _ordenadorRepositorio;
        private readonly IComponenteRepositorio _componenteRepositorio;
        public OrdenadoresController(IRepositorioOrdenador ordenadorRepositorio, IComponenteRepositorio componenteRepositorio)
        {
            _ordenadorRepositorio = ordenadorRepositorio;
            _componenteRepositorio = componenteRepositorio;


        }


        // GET: Ordenadors
        public ActionResult Index()
        {

            return View("Index", _ordenadorRepositorio.GetOrdenadorList());
        }

        // GET: Ordenadors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null )
            {
                return NotFound();
            }

            Ordenador? ordenador = _ordenadorRepositorio.GetOrdenador((int)id);

            ComponentesEnOrdenadoresViewModel viewModel = new ComponentesEnOrdenadoresViewModel
            {
                Ordenador = ordenador,
                ComponentesAgregados = ordenador!.Componentes!.ToList()
            };

            return View("Details", viewModel);
        }

        // GET: Ordenadors/Create
        public IActionResult Create()
        {


            var procesadores = 
                from componentes in _componenteRepositorio.All() where componentes.Categoria == CategoriasComponentes.Procesador select componentes;

            var memorizadores =
                from componentes in _componenteRepositorio.All() where componentes.Categoria == CategoriasComponentes.Memorizador select componentes;

            var almacenadores = 
                from componentes in _componenteRepositorio.All() where componentes.Categoria == CategoriasComponentes.Almacenador select componentes;

            ViewData["Procesadores"] = new SelectList(procesadores, "Id", "NumeroDeSerie");
            ViewData["Memorizadores"] = new SelectList(memorizadores, "Id", "NumeroDeSerie");
            ViewData["Almacenadores"] = new SelectList(almacenadores, "Id", "NumeroDeSerie");

            return View();
        }

        // POST: Ordenadors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Ordenador ordenador)
        {
            if (ModelState.IsValid)
            {
                _ordenadorRepositorio.AddOrdenador(ordenador);
                return RedirectToAction(nameof(Index));
            }
            return View(ordenador);
        }

        // GET: Ordenadors/Edit/5
        public ActionResult Edit(int? id)
        {
			//if (id == null)
			//{
			//	return NotFound();
			//}

			//var ordenador = _ordenadorRepositorio.GetOrdenador((int)id);
            
   //         if (ordenador == null)
   //         {
   //             return NotFound();
            /*}*/
            return View(_ordenadorRepositorio.GetOrdenador((int)id));
        }
        

        // POST: Ordenadors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Ordenador ordenador)
        {

            if (ModelState.IsValid)
            {
               
                    _ordenadorRepositorio.Update(ordenador, id);
               
                return RedirectToAction(nameof(Index));
            }
            return View(ordenador);
        }


        //GET: Ordenadors/Delete/5

        public ActionResult Delete(int? id)
        {
            if (id == null || _ordenadorRepositorio.GetOrdenador((int)id) == null)
            {
                return NotFound();
            }

            var ordenador = _ordenadorRepositorio.GetOrdenador((int)id);
            if (ordenador == null)
            {
                return NotFound();
            }

            return View(ordenador);
        }
        //#1#

         //POST: Ordenadors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (_ordenadorRepositorio.GetOrdenador(id) == null)
            {
                return Problem("Entity set 'ComponentesCodeFirstContext.Ordenador'  is null.");
            }

            var ordenador = _ordenadorRepositorio.GetOrdenador((int)id);

			if (ordenador != null)
            {
                _ordenadorRepositorio.DeleteOrdenador(id);
            }

            
            return RedirectToAction(nameof(Index));
        }


    }
}
