
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rouba_monte
{
    internal class Monte
    {

        private Stack<Carta> cartas;
        private Carta topo;

        public Carta Topo
        {
            get { return topo; }
            set { topo = value; }
        }
        public Stack<Carta> Cartas
        {
            get { return cartas; }
            set { cartas = value; }
        }
        public Monte()
        {
            cartas = new Stack<Carta>();
            topo = null;
        }
        public void AdicionarCarta(Carta carta)
        {
            cartas.Push(carta);
            topo = carta;
        }
        public Carta ComprarCarta()
        {
            if (cartas.Count > 0)
            {
                Carta removida = cartas.Pop();
                if (cartas.Count > 0)
                    topo = cartas.Peek();
                else
                    topo = null;
                return removida;
            }
            topo = null;
            return null;
        }
        public Carta Remover()
        {
            return cartas.Pop();
        }
        public int GetQuantidade()
        {
            return cartas.Count;
        }
        public void Limpar()
        {
            //não sei se realmente será usado
            cartas.Clear();
            topo = null;
        }
    }
}


