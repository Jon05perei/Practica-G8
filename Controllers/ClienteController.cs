using Microsoft.AspNetCore.Mvc;
using Practica_1.BLL;
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
    }
}
