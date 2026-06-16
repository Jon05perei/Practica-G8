using Microsoft.AspNetCore.Mvc;
using Practica_1.BLL;
using Practica_1.DAL;
using Practica_1.Models;
using System.Linq;

namespace Practica_1.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteService _service;

        public ClienteController(IClienteService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            var clientes = _service.GetAll()
                .Select(c => new ClienteViewModel
                {
                    Id = c.Id,
                    Nombre = c.Nombre,
                    Apellidos = c.Apellidos,
                    Email = c.Email,
                    Telefonos = c.Telefonos.Select(t => t.Numero)
                })
                .ToList();

            return View(clientes);
        }

        public IActionResult Detalle(int id)
        {
            var c = _service.GetById(id);
            if (c == null) return NotFound();

            var vm = new ClienteViewModel
            {
                Id = c.Id,
                Nombre = c.Nombre,
                Apellidos = c.Apellidos,
                Email = c.Email,
                Telefonos = c.Telefonos.Select(t => t.Numero)
            };

            return View(vm);
        }

        [HttpGet]
        public IActionResult Crear()
        {
            var vm = new ClienteFormViewModel();
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(ClienteFormViewModel modelo)
        {
            if (!ModelState.IsValid)
            {
                return View(modelo);
            }

            var cliente = new Cliente
            {
                Nombre = modelo.Nombre,
                Apellidos = modelo.Apellidos,
                Email = modelo.Email,
                Telefonos = modelo.Telefonos
                    .Where(t => !string.IsNullOrWhiteSpace(t))
                    .Select(t => new Telefono { Numero = t })
                    .ToList()
            };

            var resultado = _service.Create(cliente);

            if (!resultado.EsExitoso)
            {
                ModelState.AddModelError(string.Empty, resultado.Mensaje);
                return View(modelo);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            var cliente = _service.GetById(id);
            if (cliente == null) return NotFound();

            var vm = new ClienteFormViewModel
            {
                Id = cliente.Id,
                Nombre = cliente.Nombre,
                Apellidos = cliente.Apellidos,
                Email = cliente.Email,
                Telefonos = cliente.Telefonos
                    .Select(t => t.Numero)
                    .ToList()
            };

            if (!vm.Telefonos.Any())
            {
                vm.Telefonos.Add(string.Empty);
            }

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(ClienteFormViewModel modelo)
        {
            if (!ModelState.IsValid)
            {
                return View(modelo);
            }

            var cliente = new Cliente
            {
                Id = modelo.Id,
                Nombre = modelo.Nombre,
                Apellidos = modelo.Apellidos,
                Email = modelo.Email,
                Telefonos = modelo.Telefonos
                    .Where(t => !string.IsNullOrWhiteSpace(t))
                    .Select(t => new Telefono { Numero = t })
                    .ToList()
            };

            var resultado = _service.Update(cliente);

            if (!resultado.EsExitoso)
            {
                ModelState.AddModelError(string.Empty, resultado.Mensaje);
                return View(modelo);
            }

            return RedirectToAction(nameof(Detalle), new { id = cliente.Id });
        }

        // GET: muestra la página de confirmación
        [HttpGet]
        public IActionResult Eliminar(int id)
        {
            var c = _service.GetById(id);
            if (c == null) return NotFound();

            var vm = new ClienteViewModel
            {
                Id = c.Id,
                Nombre = c.Nombre,
                Apellidos = c.Apellidos,
                Email = c.Email,
                Telefonos = c.Telefonos.Select(t => t.Numero)
            };

            return View(vm);
        }

        // POST: ejecuta el borrado de verdad
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public IActionResult EliminarConfirmado(int id)
        {
            var resultado = _service.Delete(id);

            if (!resultado.EsExitoso)
            {
                TempData["Error"] = resultado.Mensaje;
            }

            return RedirectToAction(nameof(Index));
        }
    }
}