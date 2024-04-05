using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Practica_Razor_HTML_Helpers.Models;

namespace Practica_Razor_HTML_Helpers.Controllers
{
    public class EquiposController : Controller
    {
        private readonly equiposContext _equiposDBContext;
        public EquiposController(equiposContext equiposDBContext)
        {
            _equiposDBContext = equiposDBContext;
        }

        public IActionResult Index()
        {
            var listaDeMarcas = (from m in _equiposDBContext.marcas
                                 select m).ToList();
            ViewData["listadoDeMarcas"] = new SelectList(listaDeMarcas, "id_marcas", "nombre_marca");

            var listadoDeEquipos = (from e in _equiposDBContext.equipos
                                    join m in _equiposDBContext.marcas on e.marca_id equals m.id_marcas
                                    select new
                                    {
                                        nombre = e.nombre,
                                        descripcion = e.descripcion,
                                        marca_id = e.marca_id,
                                        marca_nombre = m.nombre_marca
                                    }).ToList();
            ViewData["listadoEquipo"] = listadoDeEquipos;

            return View();
        }

        public IActionResult Usuario()
        {
            var listaDeUsuarios = (from u in _equiposDBContext.usuarios
                                 select u).ToList();
            ViewData["listadoDeUsuarios"] = listaDeUsuarios;

            return View();
        }

        public IActionResult CrearEquipos(equipos nuevoEquipo)
        {
            _equiposDBContext.Add(nuevoEquipo);
            _equiposDBContext.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult CrearUser(usuarios nuevoUser)
        {
            _equiposDBContext.Add(nuevoUser);
            _equiposDBContext.SaveChanges();

            return RedirectToAction("Usuario");
        }
    }
}
