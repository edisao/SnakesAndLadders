
using Domain.Entities;
using Infrastructure.Core;

namespace Bayteq.SnakeAndLaddersGame
{
    class Program
    {
        static void Main(string[] args)
        {
            // Carga la configuración inicial del tablero
            Console.WriteLine("Cargando el tablero...");
            var configuracionInicial = Infrastructure.Data.ConfiguracionInicial.ObtenerConfiguracionInicial();

            /*
            Carga el número de jugadores
            */
            List<Jugador> jugadores = new();
            Console.WriteLine("Ingrese el número de jugadores");
            int numeroJugadores = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < numeroJugadores; i++)
            {
                Console.WriteLine($"Ingresa el nombre del jugador {i + 1}: ");
                jugadores.Add(new Jugador(Console.ReadLine()));
            }

            /*
             Ejecuta el juego.
             */
            Tablero snakeAndLadder = new Tablero();
            snakeAndLadder.UbicarJugadores(jugadores);
            snakeAndLadder.UbicarComponentes(configuracionInicial.Componentes);
            
            snakeAndLadder.IniciarJuego();

        }
    }
}
