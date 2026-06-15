using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Practica_1.DAL.Practica_1.DAL.Data;

namespace Practica_1.DAL
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ApplicationDbContext _context;

        public ClienteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Cliente> GetAll() =>
            _context.Clientes
                .Include(c => c.Telefonos)
                .ToList();

        public Cliente? GetById(int id) =>
            _context.Clientes
                .Include(c => c.Telefonos)
                .FirstOrDefault(c => c.Id == id);

        public void Add(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            _context.SaveChanges();
        }


        public void Update(Cliente cliente)
        {
            var existente = _context.Clientes
                .Include(c => c.Telefonos)
                .FirstOrDefault(c => c.Id == cliente.Id);

            if (existente == null) return;

            existente.Nombre = cliente.Nombre;
            existente.Apellidos = cliente.Apellidos;
            existente.Email = cliente.Email;

            _context.Telefonos.RemoveRange(existente.Telefonos);
            existente.Telefonos.Clear();

            foreach (var telefono in cliente.Telefonos)
            {
                existente.Telefonos.Add(new Telefono { Numero = telefono.Numero });
            }

            _context.SaveChanges();
        }
    }
}