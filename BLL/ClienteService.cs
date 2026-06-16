using System.Collections.Generic;
using System.Linq;
using Practica_1.DAL;

namespace Practica_1.BLL
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _repository;

        public ClienteService(IClienteRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Cliente> GetAll() => _repository.GetAll();

        public Cliente? GetById(int id) => _repository.GetById(id);

        public ResultadoOperacion Create(Cliente cliente)
        {
            if (cliente == null)
                return ResultadoOperacion.Error("El cliente no puede ser nulo");

            if (string.IsNullOrWhiteSpace(cliente.Nombre))
                return ResultadoOperacion.Error("El nombre es obligatorio");

            if (string.IsNullOrWhiteSpace(cliente.Apellidos))
                return ResultadoOperacion.Error("Los apellidos son obligatorios");

            if (string.IsNullOrWhiteSpace(cliente.Email))
                return ResultadoOperacion.Error("El email es obligatorio");

            cliente.Telefonos = cliente.Telefonos
                .Where(t => !string.IsNullOrWhiteSpace(t.Numero))
                .ToList();

            if (!cliente.Telefonos.Any())
                return ResultadoOperacion.Error("Debe agregar al menos un número de teléfono");

            _repository.Add(cliente);
            return ResultadoOperacion.Exito();
        }

        public ResultadoOperacion Update(Cliente cliente)
        {
            if (cliente == null)
                return ResultadoOperacion.Error("El cliente no puede ser nulo");

            var existente = _repository.GetById(cliente.Id);
            if (existente == null)
                return ResultadoOperacion.Error("El cliente no existe");

            if (string.IsNullOrWhiteSpace(cliente.Nombre))
                return ResultadoOperacion.Error("El nombre es obligatorio");

            if (string.IsNullOrWhiteSpace(cliente.Apellidos))
                return ResultadoOperacion.Error("Los apellidos son obligatorios");

            if (string.IsNullOrWhiteSpace(cliente.Email))
                return ResultadoOperacion.Error("El email es obligatorio");

            cliente.Telefonos = cliente.Telefonos
                .Where(t => !string.IsNullOrWhiteSpace(t.Numero))
                .ToList();

            if (!cliente.Telefonos.Any())
                return ResultadoOperacion.Error("Debe agregar al menos un número de teléfono");

            _repository.Update(cliente);
            return ResultadoOperacion.Exito();
        }

        public ResultadoOperacion Delete(int id)
        {
            var existente = _repository.GetById(id);
            if (existente == null)
                return ResultadoOperacion.Error("El cliente no existe");

            _repository.Delete(id);
            return ResultadoOperacion.Exito();
        }
    }
}