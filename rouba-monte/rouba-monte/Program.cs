using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rouba_monte
{
    internal class Program
    {
        public static void CadastrarJogador(int numeroDoJogador)
        {

        }
        //criarBaralho();
        //inciarNovaPartida();
        //mostrarRankingPartida();
        //mostrarHIstoricoJogador();
        static void Main(string[] args)
        {
            Console.WriteLine("----------------Rouba-Montes----------------");
            Console.WriteLine("Digite o número de jogadores: ");
            int quantidadeJogadores = int.Parse(Console.ReadLine());

            Partida partida;
            int numeroPartida = 0;
            do
            {
                numeroPartida++;
                partida = new Partida(quantidadeJogadores, numeroPartida());

            } while (partida.ContinuarJogando())
        }
    }
}
