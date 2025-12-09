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
            do 
            {
                foreach (string naipe in naipes) 
                {
                    foreach (int numero in numeros)
                    {
                        if (cartas != null) 
                        {
                            if (cartas.Count >= quantidadeCartasEscolhidas) 
                                break;
                        }
                        Carta carta = new Carta(numero, naipe);
                        cartas.Add(carta);
                    }
                    if (cartas != null)
                    {
                        if (cartas.Count >= quantidadeCartasEscolhidas) 
                            break;
                    }
                }
                if (cartas != null)
                {
                    if (cartas.Count >= quantidadeCartasEscolhidas) 
                        break;
                }
            } while (cartas.Count <= quantidadeCartasEscolhidas);
            StreamWriter arq = new StreamWriter("LogDasAções.txt", true, Encoding.UTF8);
            arq.WriteLine($"Baralho com {cartas.Count} cartas criado."); 
            arq.Close();
        }
        
        public void Embaralhar()
        {
            Random rnd = new Random();
            Carta[] vetTemp = new Carta[cartas.Count]; 
            for (int i = 0; i < vetTemp.Length; i++)
            {
                vetTemp[i] = cartas[rnd.Next(0, cartas.Count)]; 
                
            }
            cartas.Clear(); 
            foreach (Carta carta in vetTemp) {
                cartas.Add(carta); 
            }
            StreamWriter arq = new StreamWriter("LogDasAções.txt", true, Encoding.UTF8);
            arq.WriteLine($"o baralho foi embaralhado."); 
            arq.Close();
        }
    }
}
