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
            arq.Write($"Jogadores da partida: ");
            for (int i = 0; i < tam; i++)
            {
                arq.Write($"{jogadores[i].Nome} ");
            }
            arq.WriteLine();
            arq.Close();
        }
        public Jogador Proximo()
        {
            indiceAtual = (indiceAtual + 1) % jogadores.Length;
            Jogador jogadorAtual = jogadores[indiceAtual];
            
            return jogadorAtual;
        }

        public void ImprimirMonteTodosJogadores()
        {
            StreamWriter arq = new StreamWriter("LogDasAções.txt", true, Encoding.UTF8);
            foreach (Jogador jogador in jogadores)
            {
                arq.Write($"|Topo do monte de {jogador.Nome}: {jogador.GetMonte().Topo}| ") ;
            }
            arq.Close();
        }


 
    }
}