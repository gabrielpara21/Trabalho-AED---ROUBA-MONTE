using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rouba_monte
{
    internal class AreaDescarte
    {
        private List<Carta> cartas;

        public List<Carta> Cartas
        {
            get { return cartas; }
            set { cartas = value; }
        }


        public AreaDescarte()
        {
            cartas = new List<Carta>();
        }
        public void AdicionarCarta(Carta carta)
        {
            cartas.Add(carta);
            StreamWriter arq = new StreamWriter("LogDasAções.txt", true, Encoding.UTF8);
            arq.WriteLine($"\nCarta {carta} adicionada à área de descarte"); 
            arq.Close();

        }

        public void MostrarAreaDescarte()
        {
            StreamWriter arq = new StreamWriter("LogDasAções.txt", true, Encoding.UTF8);
            arq.WriteLine($"\nÁrea de descarte: ");
            if (cartas != null)
            {
                if (cartas.Count == 0)
                {
                    arq.Write($"\nÁrea de descarte vazia. ");
                }
                else
                {
                    for (int i = 0; i < cartas.Count; i++) 
                    {
                        arq.Write($"{cartas[i]} ");

                        if ((i + 1) % 5 == 0) 
                        {
                            arq.WriteLine();
                        }
                    }
                }
            }
            else
            {
                throw new Exception("area de descarte == null");
            }
                arq.Close();
        }

        public Carta EncontrarRemoverCarta(Carta carta) 
        {
            if (cartas == null)
                throw new Exception("area de descarte == null");
            else if(cartas.Count == 0)
                return null;
            else
            {
                foreach(Carta c in cartas)
                {
                    if(carta.Num == c.Num)
                    {
                        Carta temp = c;
                        cartas.Remove(c);
                        StreamWriter arq = new StreamWriter("LogDasAções.txt", true, Encoding.UTF8);
                        arq.WriteLine($"\n{c} removida da área de descarte ");
                        arq.Close();
                        return temp;
                    }
                }
                return null;
            }
        }

        public void ReiniciarAreaDescarte()
        {
            cartas = null;
        }


    }
}
