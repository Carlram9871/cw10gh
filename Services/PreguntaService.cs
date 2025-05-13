using CuestionarioWeb10.Models;

namespace CuestionarioWeb10.Services
{
    public class PreguntaService
    {
        private readonly HttpClient _http;

        public PreguntaService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<Pregunta>> CargarPreguntasAsync()
        {
            var preguntas = new List<Pregunta>();

            // Usamos un parámetro dinámico para evitar la caché del navegador
            var csvUrl = $"data/preguntas.csv?v={DateTime.UtcNow.Ticks}";
            var csvContent = await _http.GetStringAsync(csvUrl);

            var lines = csvContent.Split('\n', StringSplitOptions.RemoveEmptyEntries);

            foreach (var line in lines)
            {
                var parts = line.Split('ɯ', 7);
                if (parts.Length >= 7)
                {
                    preguntas.Add(new Pregunta
                    {
                        Numero = parts[0].Trim(),
                        Dificultad = parts[1].Trim(),
                        Tema = parts[2].Trim(),
                        Respuesta = parts[3].Trim('"'),
                        Vista = parts[4].Trim(),
                        Marcada = parts[5].Trim(),
                        Notas = parts[6].Trim(),
                    });
                }
            }

            return preguntas;
        }
        public async Task<List<string>> ObtenerTemasAsync()
        {
            var preguntas = await CargarPreguntasAsync();
            return preguntas
                .Select(p => p.Tema)
                .Where(t => !string.IsNullOrWhiteSpace(t))
                .Distinct()
                .OrderBy(t => t)
                .ToList();
        }

        public async Task<List<Pregunta>> ObtenerPreguntasPorTemaAsync(string tema)
        {
            var preguntas = await CargarPreguntasAsync();
            if (string.IsNullOrEmpty(tema) || tema == "Todos los temas")
                return preguntas;

            return preguntas
     .Where(p => p.Tema.Trim().Equals(tema.Trim(), StringComparison.OrdinalIgnoreCase))
     .ToList();

        }

    }

}
