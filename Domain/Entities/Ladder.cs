
using Newtonsoft.Json;

namespace Domain.Entities
{
    public class Ladder
    {
        [JsonProperty("startLadder")]
        public int Inicio;

        [JsonProperty("endLadder")]
        public int Fin;

        public Ladder(int _inicio, int _fin)
        {
            Inicio = _inicio;
            Fin = _fin;
        }

        public int ObtenerInicio()
        {
            return Inicio;
        }

        public int ObtenerFin()
        {
            return Fin;
        }
    }
}
