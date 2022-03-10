using Domain.Enums;
using Newtonsoft.Json;

namespace Domain.Entities
{
    public class Componente
    {
        [JsonProperty("start")]
        public int Inicio;

        [JsonProperty("end")]
        public int Fin;

        [JsonProperty("type")]
        public TipoComponenteJuego Tipo;
        
        public Componente(int inicio, int fin, TipoComponenteJuego tipo)
        {
            Inicio = inicio;
            Fin = fin;
            Tipo = tipo;
        }

        public int ObtenerInicio()
        {
            return Inicio;
        }

        public int ObtenerFin()
        {
            return Fin;
        }

        public TipoComponenteJuego ObtenerTipo()
        {
            return Tipo;
        }
    }
}
