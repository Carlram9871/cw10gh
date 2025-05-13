namespace CuestionarioWeb10.Models
{
    public class Pregunta
    {
        public string Numero { get; set; } = "";
        public string Dificultad { get; set; } = "";
        public string Tema { get; set; } = "";
        public string Respuesta { get; set; } = "";
        public string Vista { get; set; } = "";
        public string Marcada { get; set; } = "";
        public string Notas { get; set; } = "";

        public string ImagenUrl => $"imgPreguntas/Pregunta_{Numero}.jpg";
    }
}
