using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Practica_1.Models
{
    public class ClienteFormViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "Los apellidos son obligatorios")]
        [Display(Name = "Apellidos")]
        public string Apellidos { get; set; } = string.Empty;

        [Required(ErrorMessage = "El email es obligatorio")]
        [EmailAddress(ErrorMessage = "El formato del email no es válido")]
        public string Email { get; set; } = string.Empty;

        [Display(Name = "Teléfonos")]
        public List<string> Telefonos { get; set; } = new List<string> { string.Empty };
    }
}