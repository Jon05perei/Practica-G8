using System.Collections.Generic;
using System.Linq;

namespace Practica_1.DAL
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly List<Cliente> _clientes;

        public ClienteRepository()
        {
            _clientes = new List<Cliente>
            {
                new Cliente
                {
                    Id = 1,
                    Nombre = "Juan",
                    Apellidos = "Pérez",
                    Email = "juan.perez@example.com",
                    Telefonos = new List<Telefono>
                    {
                        new Telefono { Id = 1, Numero = "555-1234", ClienteId = 1 },
                        new Telefono { Id = 2, Numero = "555-5678", ClienteId = 1 }
                    }
                },
                new Cliente
                {
                    Id = 2,
                    Nombre = "María",
                    Apellidos = "Gómez",
                    Email = "maria.gomez@example.com",
                    Telefonos = new List<Telefono>
                    {
                        new Telefono { Id = 3, Numero = "555-8765", ClienteId = 2 }
                    }
                }
            };
        }

        public IEnumerable<Cliente> GetAll() => _clientes;

        public Cliente? GetById(int id) => _clientes.FirstOrDefault(c => c.Id == id);

        public void Add(Cliente cliente)
        {
            var nextId = _clientes.Any() ? _clientes.Max(c => c.Id) + 1 : 1;
            cliente.Id = nextId;
            _clientes.Add(cliente);
        }
    }
}
