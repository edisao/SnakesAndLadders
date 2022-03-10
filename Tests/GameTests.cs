using Domain.Entities;
using Infrastructure.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Tests
{
    [TestClass]
    public class GameTests
    {
        [TestMethod]
        public void Board_US1_CrearConfiguracionJuego()
        {
            /* AAA */

            // 1. Arrange: Inicializar variables
            int expectedBoardSize = 100;
            int expectedSnakeCount = 10;
            int expectedLadderCount = 11;

            // Crear lista de jugadores
            List<Jugador> jugadores = new();
            var jugadorA = new Jugador("Jugador 1");
            var jugadorB = new Jugador("Jugador 2");
            jugadores.Add(jugadorA);
            jugadores.Add(jugadorB);

            // Obtener la configuración inicial
            var configuracion = Infrastructure.Data.ConfiguracionInicial.ObtenerConfiguracionInicial();

            // 2. Act: Usar el metodo a probar
            var tablero = new Tablero(); // Crear una instancia del tablero
            tablero.UbicarJugadores(jugadores);
            tablero.UbicarComponentes(configuracion.Componentes);

            // 3. Assert: Validar lo que necesitamos que se cumpla
            Assert.AreEqual(expectedBoardSize, tablero.SnakeAndLadderBoard.ObtenerTamanio());
            Assert.AreEqual(expectedSnakeCount, tablero.SnakeAndLadderBoard.ObtenerSnakes().Count);
            Assert.AreEqual(expectedLadderCount, tablero.SnakeAndLadderBoard.ObtenerLadders().Count);
            Assert.AreEqual(jugadores.Count, tablero.SnakeAndLadderBoard.ObtenerDatosJugador().Count);
        }

        [TestMethod]
        public void Board_US1_UAT1_SnakesAndLadders()
        {
            // 1. Arrange: Inicializar variables

            int expectedInitialPosition = 1;
            
            // Crear lista de jugadores
            List<Jugador> jugadores = new();
            var jugadorA = new Jugador("Jugador 1");
            var jugadorB = new Jugador("Jugador 2");
            jugadores.Add(jugadorA);
            jugadores.Add(jugadorB);

            // Obtener la configuración inicial
            var configuracion = Infrastructure.Data.ConfiguracionInicial.ObtenerConfiguracionInicial();


            // 2. Act: Usar el metodo a probar
            var tablero = new Tablero(); // Crear una instancia del tablero
            tablero.UbicarJugadores(jugadores);
            tablero.UbicarComponentes(configuracion.Componentes);
            var jugada = tablero.GenerarJugada(jugadorA);

            // 3. Assert: Validar lo que necesitamos que se cumpla
            Assert.AreEqual(expectedInitialPosition, jugada.Token.PosicionAnterior);
            
        }

        [TestMethod]
        public void Board_US1_UAT2_SnakesAndLadders()
        {
            // 1. Arrange: Inicializar variables

            int roll = 3;
            int expectedFinalPosition = 4;

            // Crear lista de jugadores
            List<Jugador> jugadores = new();
            var jugadorA = new Jugador("Jugador 1");
            var jugadorB = new Jugador("Jugador 2");
            jugadores.Add(jugadorA);
            jugadores.Add(jugadorB);

            // Obtener la configuración inicial
            var configuracion = Infrastructure.Data.ConfiguracionInicial.ObtenerConfiguracionInicial();


            // 2. Act: Usar el metodo a probar
            var tablero = new Tablero(); // Crear una instancia del tablero
            tablero.UbicarJugadores(jugadores);
            tablero.UbicarComponentes(configuracion.Componentes);
            var jugada = tablero.GenerarJugada(jugadorA, roll);

            // 3. Assert: Validar lo que necesitamos que se cumpla
            Assert.AreEqual(expectedFinalPosition, jugada.Token.PosicionActual);

        }

        [TestMethod]
        public void Board_US1_UAT3_SnakesAndLadders()
        {
            // 1. Arrange: Inicializar variables

            int firstRoll = 3;
            int aditionalRoll = 4;
            int expectedFinalPosition = 8;

            // Crear lista de jugadores
            List<Jugador> jugadores = new();
            var jugadorA = new Jugador("Jugador 1");
            var jugadorB = new Jugador("Jugador 2");
            jugadores.Add(jugadorA);
            jugadores.Add(jugadorB);

            // Obtener la configuración inicial
            var configuracion = Infrastructure.Data.ConfiguracionInicial.ObtenerConfiguracionInicial();


            // 2. Act: Usar el metodo a probar
            var tablero = new Tablero(); // Crear una instancia del tablero
            tablero.UbicarJugadores(jugadores);
            tablero.UbicarComponentes(configuracion.Componentes);


            var jugada1 = tablero.GenerarJugada(jugadorA, firstRoll);
            var jugada2 = tablero.GenerarJugada(jugadorA, aditionalRoll);

            // 3. Assert: Validar lo que necesitamos que se cumpla
            Assert.AreEqual(expectedFinalPosition, jugada2.Token.PosicionAnterior + aditionalRoll);

        }

        [TestMethod]
        public void Board_US2_UAT1_SnakesAndLadders()
        {
            // 1. Arrange: Inicializar variables
            int firstRoll = 96;
            int additionalRoll = 3;
            int expectedFinalPosition = 100;

            // Crear lista de jugadores
            List<Jugador> jugadores = new();
            var jugadorA = new Jugador("Jugador 1");
            var jugadorB = new Jugador("Jugador 2");
            jugadores.Add(jugadorA);
            jugadores.Add(jugadorB);

            // Obtener la configuración inicial
            var configuracion = Infrastructure.Data.ConfiguracionInicial.ObtenerConfiguracionInicial();

            // 2. Act: Usar el metodo a probar
            var tablero = new Tablero(); // Crear una instancia del tablero
            tablero.UbicarJugadores(jugadores);
            tablero.UbicarComponentes(configuracion.Componentes);

            var jugada = tablero.GenerarJugada(jugadorA, firstRoll);
            var jugada2 = tablero.GenerarJugada(jugadorA, additionalRoll);

            // 3. Assert: Validar lo que necesitamos que se cumpla
            Assert.AreEqual(expectedFinalPosition, jugada2.Token.PosicionActual);
            Assert.AreEqual(true, jugada2.Token.JuegoGanado);
        }

        [TestMethod]
        public void Board_US2_UAT2_SnakesAndLadders()
        {
            // 1. Arrange: Inicializar variables

            int firstRoll = 96;
            int additionalRoll = 4;
            int expectedFinalPosition = 97;


            // Crear lista de jugadores
            List<Jugador> jugadores = new();
            var jugadorA = new Jugador("Jugador 1");
            var jugadorB = new Jugador("Jugador 2");
            jugadores.Add(jugadorA);
            jugadores.Add(jugadorB);

            // Obtener la configuración inicial
            var configuracion = Infrastructure.Data.ConfiguracionInicial.ObtenerConfiguracionInicial();

            // 2. Act: Usar el metodo a probar
            var tablero = new Tablero(); // Crear una instancia del tablero
            tablero.UbicarJugadores(jugadores);
            tablero.UbicarComponentes(configuracion.Componentes);

            var jugada = tablero.GenerarJugada(jugadorA, firstRoll);
            var jugada2 = tablero.GenerarJugada(jugadorA, additionalRoll);

            // 3. Assert: Validar lo que necesitamos que se cumpla
            Assert.AreEqual(expectedFinalPosition, jugada2.Token.PosicionActual);
            Assert.AreEqual(false, jugada2.Token.JuegoGanado);
        }

        [TestMethod]
        public void Board_US3_UAT1_SnakesAndLadders()
        {
            // 1. Arrange: Inicializar variables
            var expected = new List<int>();
            expected.AddRange(new[] { 1, 2, 3, 4, 5, 6 });

            // Crear lista de jugadores
            List<Jugador> jugadores = new();
            var jugadorA = new Jugador("Jugador 1");
            var jugadorB = new Jugador("Jugador 2");
            jugadores.Add(jugadorA);
            jugadores.Add(jugadorB);

            // Obtener la configuración inicial
            var configuracion = Infrastructure.Data.ConfiguracionInicial.ObtenerConfiguracionInicial();

            // 2. Act: Usar el metodo a probar
            var tablero = new Tablero(); // Crear una instancia del tablero
            tablero.UbicarJugadores(jugadores);
            tablero.UbicarComponentes(configuracion.Componentes);

            var getRoll = tablero.ObtenerValorDado();

            // 3. Assert: Validar lo que necesitamos que se cumpla
            CollectionAssert.Contains(expected, getRoll);
        }

        [TestMethod]
        public void Board_US3_UAT2_SnakesAndLadders()
        {
            // 1. Arrange: Inicializar variables

            int roll = 4;
            int expectedFinalPosition = 5;

            // Crear lista de jugadores
            List<Jugador> jugadores = new();
            var jugadorA = new Jugador("Jugador 1");
            jugadores.Add(jugadorA);

            // Obtener la configuración inicial
            var configuracion = Infrastructure.Data.ConfiguracionInicial.ObtenerConfiguracionInicial();


            // 2. Act: Usar el metodo a probar
            var tablero = new Tablero(); // Crear una instancia del tablero
            tablero.UbicarJugadores(jugadores);
            tablero.UbicarComponentes(configuracion.Componentes);
            var jugada = tablero.GenerarJugada(jugadorA, roll);

            // 3. Assert: Validar lo que necesitamos que se cumpla
            Assert.AreEqual(expectedFinalPosition, jugada.Token.PosicionActual);

        }

    }
}
