using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rouba_monte
{
    internal class Program
    {
        //cadastrarJogador();
        //criarBaralho();
        //inciarNovaPartida();
        //mostrarRankingPartida();
        //mostrarHIstoricoJogador();
        static void Main(string[] args)
        {
             Baralho baralho = new Baralho();
            baralho.CriarCartas(1800);
            baralho.Embaralhar();
            baralho.Cartas.ForEach(c =>
            {
                Console.WriteLine(c.Naipe + c.Num);
            });
            Console.WriteLine(baralho.Cartas.Count);
        }
    }
}
