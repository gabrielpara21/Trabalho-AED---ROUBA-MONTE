using System;
using System.Collections.Generic;

namespace rouba_monte
{
    internal class Jogador
    {
        private string nome;
        private int posicao;
        private Queue<int> ranking;
        private Monte monte;

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        public int Posicao
        {
            get { return posicao; }
            set { posicao = value; }
        }

        public Queue<int> Ranking
        {
            get { return ranking; }
            set { ranking = value; }
        }

        public Jogador(string nome)
        {
            this.nome = nome;
            this.posicao = 0;
            this.ranking = new Queue<int>(5);
            this.monte = new Monte();
        }

        public Monte GetMonte()
        {
            return monte;
        }

        public void ReiniciarMonte()
        {
            monte = new Monte();
        }

        public void AtualizarRanking(int posicao)
        {
            if (ranking.Count < 5)
                ranking.Enqueue(posicao);
            else
            {
                ranking.Dequeue();
                ranking.Enqueue(posicao);
            }
        }

        public void MostrarHistorico()
        {
            Console.WriteLine($"Histórico de posições do jogador {nome}:");
            foreach (int pos in ranking)
                Console.WriteLine($" - {pos}º lugar");
        }
    }
}

