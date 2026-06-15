using System.Collections.Generic;

namespace Practica_1.DAL
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellidos { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public List<Telefono> Telefonos { get; set; } = new List<Telefono>();
    }
}
