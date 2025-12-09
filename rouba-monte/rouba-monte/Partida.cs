using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace rouba_monte
{
    internal class Partida
    {
        private FilaCircularJogadores filaCircular;
        private Baralho baralho;
        private AreaDescarte areaDescarte;

        public Partida(Baralho baralho, FilaCircularJogadores fila)
        {
            this.filaCircular = fila;
            this.baralho = baralho;
            this.areaDescarte = new AreaDescarte();
        }


        public string IniciarPartida()
        {   

            while (baralho.Cartas.Count > 0)
            {
                StreamWriter arq = new StreamWriter("LogDasAções.txt", true, Encoding.UTF8);
                Jogador jogadorDaVez = filaCircular.GetAtual();
                arq.WriteLine($"Vez de {jogadorDaVez.Nome}");

                Carta carta = ComprarCarta();
                arq.WriteLine($"{jogadorDaVez.Nome} comprou a carta {carta}");
                arq.Close();


                bool jogou = false;

                Jogador jogadorRoubado;
                Carta cartaDoDescarte;
                if (RoubarMonte(jogadorDaVez, carta, out jogadorRoubado))
                {
                    jogou = true;
                    arq = new StreamWriter("LogDasAções.txt", true, Encoding.UTF8);
                    arq.WriteLine($"{jogadorDaVez.Nome} roubou o monte de {jogadorRoubado.Nome}");
                    arq.Close();
                    filaCircular.ImprimirMonteTodosJogadores();
                }
                else if (RoubarDoDescarte(jogadorDaVez, carta, out cartaDoDescarte))
                {
                    jogou = true;
                    arq = new StreamWriter("LogDasAções.txt", true, Encoding.UTF8);
                    arq.WriteLine($"{jogadorDaVez.Nome} roubou a carta {cartaDoDescarte} da área de descarte");
                    arq.Close();
                    filaCircular.ImprimirMonteTodosJogadores();
                }
                else if (EmpilharNoProprioMonte(jogadorDaVez, carta))
                {
                    arq = new StreamWriter("LogDasAções.txt", true, Encoding.UTF8);
                    jogou = true;
                    arq.WriteLine($"{jogadorDaVez.Nome} empilhou a carta {carta} no próprio monte");
                    arq.Close();
                    filaCircular.ImprimirMonteTodosJogadores();
                }

                if (!jogou)
                {
                    areaDescarte.AdicionarCarta(carta);
                    filaCircular.Proximo();
                }
            }

                int n = filaCircular.Tamanho();
            Jogador[] vetorJogadores = new Jogador[n];

            for (int i = 0; i < n; i++)
            {
                vetorJogadores[i] = filaCircular.GetAtual();
                filaCircular.Proximo();
            }
                


            OrdenarPorQuantidadeCartas(vetorJogadores);

            string textoRanking = vetorJogadores[0].Nome + " Foi o ganhador" +"\nRanking da partida:\n";

            for (int i = 0; i < n; i++)
            {
                textoRanking += (i + 1) + "º - " +
                                vetorJogadores[i].Nome +
                                " com " + vetorJogadores[i].GetMonte().GetQuantidade() +
                                " carta(s)\n";
            }

            for (int i = 0; i < n; i++)
            {
                vetorJogadores[i].AtualizarRanking(i + 1);
                vetorJogadores[i].GetMonte().Limpar();
            }
                

            return textoRanking;
        }

        private void OrdenarPorQuantidadeCartas(Jogador[] vetorJogadores)
        {
            int n = vetorJogadores.Length;

            for (int i = 0; i < n - 1; i++)
            {
                int indiceMaior = i;

                for (int j = i + 1; j < n; j++)
                {
                    if (vetorJogadores[j].GetMonte().GetQuantidade() >
                        vetorJogadores[indiceMaior].GetMonte().GetQuantidade())
                    {
                        indiceMaior = j;
                    }
                }

                if (indiceMaior != i)
                {
                    Jogador aux = vetorJogadores[i];
                    vetorJogadores[i] = vetorJogadores[indiceMaior];
                    vetorJogadores[indiceMaior] = aux;
                }
            }
        }
        public Carta ComprarCarta()
        {
            Carta carta = baralho.Cartas[0];
            baralho.Cartas.RemoveAt(0);
            return carta;
        }
        public bool RoubarMonte(Jogador jogador, Carta carta, out Jogador alvo)
        {
            alvo = null;

            for (int i = 0; i < filaCircular.Tamanho(); i++)
            {
                Jogador j = filaCircular.GetAtual();

                if (j == jogador)
                    continue;

                if (j.GetMonte().GetQuantidade() == 0)
                    continue;

                Carta topo = j.GetMonte().Topo;

                if (topo.Num == carta.Num)
                {
                    alvo = j;
                    break;
                }
            }

            if (alvo == null)
                return false;

           

            while (alvo.GetMonte().GetQuantidade() > 0)
            {
                Carta c = alvo.GetMonte().Remover();
                jogador.GetMonte().AdicionarCarta(c);
            }
            jogador.GetMonte().AdicionarCarta(carta);
            return true;
        }

        public bool RoubarDoDescarte(Jogador jogador, Carta carta, out Carta cartaDoDescarte)
        {
            cartaDoDescarte = areaDescarte.EncontrarRemoverCarta(carta);

            if (cartaDoDescarte == null)
                return false;

            
            jogador.GetMonte().AdicionarCarta(cartaDoDescarte);
            jogador.GetMonte().AdicionarCarta(carta);

            return true;
        }

        public bool EmpilharNoProprioMonte(Jogador jogador, Carta carta)
        {
            Monte monte = jogador.GetMonte();

            if (monte.GetQuantidade() == 0)
                return false;

            Carta topo = monte.Topo;

            if (topo.Num == carta.Num)
            {
                monte.AdicionarCarta(carta);
                return true;
            }

            return false;
        }



    }
}
