
namespace Domain.Entities
{
    public class Jugador
    {
        private readonly string _nombre;
        private readonly string _id;
        public Token Token { get; set; }

        public Jugador(string nombre)
        {
            _nombre = nombre;
            _id = Guid.NewGuid().ToString();
            Token = new Token();
        }

        public string ObtenerNombre()
        {
            return _nombre;
        }

        public string ObtenerId()
        {
            return _id;
        }
    }
}
