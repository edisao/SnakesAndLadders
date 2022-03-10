
using Domain.Entities;
using Newtonsoft.Json;

namespace Infrastructure.Data
{
    public class ConfiguracionInicial
    {
        public static Configuracion ObtenerConfiguracionInicial()
        {
            string startupPath = Directory.GetCurrentDirectory();
            var uriFile = startupPath + @"\Files\board2.json";
            var json = File.ReadAllText(uriFile);
            return JsonConvert.DeserializeObject<Configuracion>(json);
        }
    }
}
