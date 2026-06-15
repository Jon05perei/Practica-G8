namespace Practica_1.BLL
{
    public class ResultadoOperacion
    {
        public bool EsExitoso { get; set; }
        public string Mensaje { get; set; } = string.Empty;

        public static ResultadoOperacion Exito() =>
            new ResultadoOperacion { EsExitoso = true, Mensaje = "Operación realizada correctamente" };

        public static ResultadoOperacion Error(string mensaje) =>
            new ResultadoOperacion { EsExitoso = false, Mensaje = mensaje };
    }
}