
using Domain.Entities;
using Domain.Enums;

namespace Infrastructure.Core
{
    public class Tablero
    {
        private const int TAMANO_POR_DEFECTO_TABLERO = 100;
        private const int POSICION_INICIO_JUGADA = 1;
        public SnakeAndLadderBoard SnakeAndLadderBoard;
        private List<Jugador> _jugadores;
        internal bool _juegoTerminado = false;

        public Tablero()
        {
            SnakeAndLadderBoard = new SnakeAndLadderBoard(TAMANO_POR_DEFECTO_TABLERO);  //Optional Rule 2
            _jugadores = new List<Jugador>();
        }

        public void UbicarJugadores(List<Jugador> jugadores)
        {
            _jugadores = new List<Jugador>();
            Dictionary<string, int> datosJugador = new();
            foreach (Jugador jugador in jugadores)
            {
                _jugadores.Add(jugador);
                datosJugador.Add(jugador.ObtenerId(), POSICION_INICIO_JUGADA); // Cada jugador tiene un ficha(token) que inicialmente se mantiene fuera del tablero (es decir, en la posición 0-1 ).
            }
            SnakeAndLadderBoard.AgregarDatosJugador(datosJugador); //  Agrega las piesas al tablero
        }

        public void UbicarComponentes(List<Componente> componentes)
        {
            SnakeAndLadderBoard.UbicarComponentes(componentes);
        }
        
        public Token GenerarMovimiento(Jugador player, int cantidadSaltos)
        {
            var response = new Token
            {
                PosicionAnterior = SnakeAndLadderBoard.ObtenerDatosJugador()[player.ObtenerId()]
            };
            response.PosicionActual = response.PosicionAnterior + cantidadSaltos;
            response.CantidadSaltos = cantidadSaltos;

            var mov = SnakeAndLadderBoard.ObtenerComponentes().Find(x => x.Inicio == response.PosicionActual);
            response.GeneraMovimientoAdicional = mov != null;
            response.ValorMovimientoAdicional = (mov != null) ? mov.ObtenerFin() : 0;

            if (response.GeneraMovimientoAdicional) response.PosicionActual = response.ValorMovimientoAdicional;
            if (mov != null) response.TipoMovimiento = mov.Tipo.Equals(TipoComponenteJuego.Snake) ? "-" : "+";
            if (response.PosicionActual > SnakeAndLadderBoard.ObtenerTamanio())
            {
                response.ExcedeTamanioTablero = true;
                response.PosicionActual = response.PosicionAnterior;
            }
            if (response.PosicionActual == SnakeAndLadderBoard.ObtenerTamanio())
                response.JuegoGanado = true;
            return response;
        }

        /// <summary>
        /// Lanza el dado para obtener el valor
        /// </summary>
        /// <returns></returns>
        public int ObtenerValorDado()
        {
            return Dado.Lanzar();
        }

        // Se mueve la posiciòn del jugador
        // private void MovePlayer(Player player, int positions)
        private Token MoverJugador(Jugador jugador, int valorDado)
        {
            var movimiento = GenerarMovimiento(jugador, valorDado);
            SnakeAndLadderBoard.ObtenerDatosJugador()[jugador.ObtenerId()] = movimiento.PosicionActual;
            Thread.Sleep(800);
            return movimiento;
        }

        public Jugador GenerarJugada(Jugador jugadorEnCurso, int valorDado = 0)
        {
            int diceValue = (valorDado == 0) ? ObtenerValorDado() : valorDado;
            var token = MoverJugador(jugadorEnCurso, diceValue);
            jugadorEnCurso.Token = token;
            return jugadorEnCurso;
        }

        public void IniciarJuego()
        {
            while (!_juegoTerminado)
            {
                Jugador jugadorEnCurso = _jugadores[0];
                _jugadores.RemoveAt(0);
                var jugador = GenerarJugada(jugadorEnCurso);
                Console.WriteLine(jugador.ObtenerNombre() + " obtuvo " + jugador.Token.CantidadSaltos + " con el dado, movió de la posición " + jugador.Token.PosicionAnterior + " a la " + (jugador.Token.CantidadSaltos + jugador.Token.PosicionAnterior) + " " + ((jugador.Token.GeneraMovimientoAdicional) ? ". Genera movimiento adicional " + jugador.Token.TipoMovimiento + ". " + jugador.Token.PosicionActual : "") + ((jugador.Token.ExcedeTamanioTablero) ? ". Este movimiento excede tamaño del tablero" : ""));
                if (jugador.Token.JuegoGanado)
                {
                    Console.WriteLine(jugadorEnCurso.ObtenerNombre() + " ganó el juego.");
                    break;
                }
                _jugadores.Add(jugadorEnCurso);
            }
        }

    }
}
