using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rouba_monte
{
    internal class FilaCircularJogadores
    {
        
        private int indiceAtual;

        public int IndiceAtual
        {
            get { return indiceAtual; }
            set { indiceAtual = value; }
        }
        private Jogador[] jogadores;

        public Jogador[] Jogadores
        {
            get { return jogadores; }
            set { jogadores = value; }
        }
        public Jogador GetAtual()
        {
            return jogadores[indiceAtual];
        }
        public int Tamanho()
        {
            return jogadores.Length;
        }
        public FilaCircularJogadores(int tam)
        {
            this.Jogadores = new Jogador[tam];
            this.indiceAtual = 0;
            for (int i = 0; i < tam; i++)
            {
                Console.Write("Digite o nome do jogador " + (i + 1) + ": ");
                string nome = Console.ReadLine();
                Jogadores[i] = new Jogador(nome);
            }
            StreamWriter arq = new StreamWriter("LogDasAções.txt", true, Encoding.UTF8);
            arq.Write($"Jogadores da partida: "); // log da ação
            for (int i = 0; i < tam; i++)
            {
                arq.Write($"{jogadores[i].Nome} ");
            }
            arq.WriteLine();
            arq.Close();
        }
        public Jogador Proximo()
        {
            //sempre que chegar no ultimo volta para o primeiro
            //na primeira chamada vai retornar o primeiro jogador
            indiceAtual = (indiceAtual + 1) % jogadores.Length;
            Jogador jogadorAtual = jogadores[indiceAtual];
            //StreamWriter arq = new StreamWriter("LogDasAções.txt", true, Encoding.UTF8);
            //arq.WriteLine($"Vez de {jogadores[indiceAtual].Nome}"); // log da ação
           // arq.Close();
            
            return jogadorAtual;
        }


        //proximoJogador();
        //getAtual();
    }
}