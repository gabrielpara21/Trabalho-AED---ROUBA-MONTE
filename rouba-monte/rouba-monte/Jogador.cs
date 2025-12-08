using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rouba_monte
{
    internal class Jogador
    {
        private int posicao;
        private string nome;
        private int quantCartasMonte;
        private Queue<int> ranking;
        public Queue<int> Ranking
        {
            get { return ranking; }
            set { ranking = value; }
        }

        public int QuantCartasMonte
        {
            get { return quantCartasMonte; }
            set { quantCartasMonte = value; }
        }

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

        public Jogador(string nome)
        {
            this.nome = nome;
            this.posicao = 0;
            this.quantCartasMonte = 0;
            this.ranking = new Queue<int>(5);
        }

        public void AtualizarRanking(int posicao)
        {
            if (ranking.Count < 5)
            {
                ranking.Enqueue(posicao);
            }
            else
            {
                ranking.Dequeue();
                ranking.Enqueue(posicao);
            }
        }
        public void MostrarHistorico()
        {
            Console.WriteLine($"Histórico de posições do jogador {nome} nas últimas partidas:");
            foreach (int pos in ranking)
            {
                /*
                 IMPRIME EM ORDEM DE INSERÇÃO, OU SEJA DA PARTIDA MAIS ANTIGA PARA A MAIS RECENTE
                 */
                Console.WriteLine($" -{pos}° lugar");
            }
            StreamWriter arq = new StreamWriter("LogDasAções.txt", true, Encoding.UTF8);
            arq.WriteLine($"Histórico de {nome} solicitado"); // log da ação
            arq.Close();
        }
    }
}

