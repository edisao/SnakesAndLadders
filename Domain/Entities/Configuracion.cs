
using Newtonsoft.Json;

namespace Domain.Entities
{
    public class Configuracion
    {
        [JsonProperty("nombre")]
        public string Nombre { get; set; }

        [JsonProperty("totalSaltos")]
        public int totalSaltos { get; set; }

        [JsonProperty("componentes")]
        public List<Componente> Componentes { get; set; }

    }
    
}
