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
            AreaDescarte areaDescarte = new AreaDescarte();
            areaDescarte.AdicionarCarta(new Carta(2, "paus"));
            areaDescarte.AdicionarCarta(new Carta(8, "ouros"));
            areaDescarte.AdicionarCarta(new Carta(6, "copas"));
            areaDescarte.AdicionarCarta(new Carta(13, "espadas"));
            areaDescarte.AdicionarCarta(new Carta(11, "ouros"));
            areaDescarte.AdicionarCarta(new Carta(7, "paus"));
            areaDescarte.MostrarAreaDescarte();
            areaDescarte.EncontrarRemoverCarta(new Carta(6, "copas"));
            areaDescarte.MostrarAreaDescarte();
        }
    }
}
