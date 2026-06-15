using System.Collections.Generic;
using Practica_1.DAL;

namespace Practica_1.BLL
{
    public interface IClienteService
    {
        IEnumerable<Cliente> GetAll();
        Cliente? GetById(int id);
        ResultadoOperacion Create(Cliente cliente);
        ResultadoOperacion Update(Cliente cliente);

    }
}