using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rouba_monte
{
    internal class Baralho
    {
        private List<Carta> cartas;

        public Baralho()
        {
            cartas = new List<Carta>();
        }

        public List<Carta> Cartas{ 
            get { return cartas; }
            set { cartas = value; }
        }
       

        public void CriarCartas(int quantidadeCartasEscolhidas)
        {
            string[] naipes = { "Copas", "Espadas", "Ouros", "Paus" };
            int[] numeros = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };
            do // esse loop serve para quando completar 1 baralho completo, as cartas continuem a ser geradas
            {
                foreach (string naipe in naipes) //para cada naipe, cria uma carta por numero, desde que não tenha ultrapassado a quantidade de cartas escolhidas
                {
                    foreach (int numero in numeros)
                    {
                        if (cartas != null) //verifica se o atributo cartas é null, para acessar a quantidade
                        {
                            if (cartas.Count >= quantidadeCartasEscolhidas) //ponto de parada para gerar somente até a quantidade de cartas escolhida
                                break;
                        }
                        Carta carta = new Carta(numero, naipe);
                        cartas.Add(carta);
                    }
                    if (cartas != null)
                    {
                        if (cartas.Count >= quantidadeCartasEscolhidas) //verifica novamente para sair do 2o loop
                            break;
                    }
                }
                if (cartas != null)
                {
                    if (cartas.Count >= quantidadeCartasEscolhidas) //verifica novamente para sair 3o loop
                        break;
                }
            } while (cartas.Count <= quantidadeCartasEscolhidas);
            StreamWriter arq = new StreamWriter("LogDasAções.txt", true, Encoding.UTF8);
            arq.WriteLine($"Baralho com {cartas.Count} cartas criado."); // log da ação
            arq.Close();
        }
        
        public void Embaralhar()
        {
            Random rnd = new Random();
            Carta[] vetTemp = new Carta[cartas.Count];  //cria um vetor temporario para auxiliar no embaralhamento
            for (int i = 0; i < vetTemp.Length; i++)
            {
                vetTemp[i] = cartas[rnd.Next(0, cartas.Count)]; //copia as cartas de posições aleatórias da lista de cartas para o vetor
                
            }
            cartas.Clear(); //limpa a lista
            foreach (Carta carta in vetTemp) {
                cartas.Add(carta); //aqui adiciona cada carta do vetor à nova lista embaralhada
            }
            StreamWriter arq = new StreamWriter("LogDasAções.txt", true, Encoding.UTF8);
            arq.WriteLine($"o baralho foi embaralhado."); // log da ação
            arq.Close();
        }
    }
}
