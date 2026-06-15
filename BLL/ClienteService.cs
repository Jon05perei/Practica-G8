using System.Collections.Generic;
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
    }
}
