
using Domain.Enums;

namespace Domain.Entities
{
    public class SnakeAndLadderBoard
    {
        private readonly int _tamanio;
        private List<Snake> _snakes;
        private List<Ladder> _ladders;
        public List<Componente> _componentes;
        private Dictionary<string, int> _datosJugador;
        
        public SnakeAndLadderBoard(int tamanio)
        {
            _tamanio = tamanio;
            _snakes = new List<Snake>();
            _ladders = new List<Ladder>();
            _componentes = new List<Componente>();
            _datosJugador = new Dictionary<string, int>();
        }

        public int ObtenerTamanio()
        {
            return _tamanio;
        }

        public void UbicarComponentes(List<Componente> components)
        {
            _componentes = components;
            UbicarSnakes();
            UbicarLadders();
        }

        public List<Componente> ObtenerComponentes()
        {
            return _componentes;
        }

        public List<Snake> ObtenerSnakes()
        {
            return _snakes;
        }

        public void UbicarSnakes()
        {
            List<Snake> snakes = new();
            var data = _componentes.FindAll(c => c.Tipo.Equals(TipoComponenteJuego.Snake));
            data.ForEach(x =>
            {
                snakes.Add(new Snake(x.Inicio, x.Fin));
            });
            _snakes = snakes;
        }

        public List<Ladder> ObtenerLadders()
        {
            return _ladders;
        }

        public void UbicarLadders()
        {
            List<Ladder> ladders = new();
            var data = _componentes.FindAll(c => c.Tipo.Equals(TipoComponenteJuego.Ladder));
            data.ForEach(x =>
            {
                ladders.Add(new Ladder(x.Inicio, x.Fin));
            });

            _ladders = ladders;
        }

        public Dictionary<string, int> ObtenerDatosJugador()
        {
            return _datosJugador;
        }

        public void AgregarDatosJugador(Dictionary<string, int> playerPieces)
        {
            _datosJugador = playerPieces;
        }
    }
}
