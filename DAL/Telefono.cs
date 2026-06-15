namespace Practica_1.DAL
{
    public class Telefono
    {
        public int Id { get; set; }
        public string Numero { get; set; } = string.Empty;
        public int ClienteId { get; set; }
    }
}
