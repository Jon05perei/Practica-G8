using System.Collections.Generic;

namespace Practica_1.Models
{
    public class ClienteViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellidos { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public IEnumerable<string> Telefonos { get; set; } = new List<string>();
    }
}
