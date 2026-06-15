using System.Collections.Generic;

namespace Practica_1.DAL
{
    public interface IClienteRepository
    {
        IEnumerable<Cliente> GetAll();
        Cliente? GetById(int id);
        void Add(Cliente cliente);
        void Update(Cliente cliente);
    }
}
