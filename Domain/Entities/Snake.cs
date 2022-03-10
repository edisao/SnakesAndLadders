
using Newtonsoft.Json;

namespace Domain.Entities
{
    public class Snake
    {
        [JsonProperty("startSnakes")]
        public int Inicio;

        [JsonProperty("endSnakes")]
        public int Fin;

        public Snake(int inicio, int fin)
        {
            Inicio = inicio;
            Fin = fin;
        }
        
        public int GetStart()
        {
            return Inicio;
        }

        public int GetEnd()
        {
            return Fin;
        }
    }
}
