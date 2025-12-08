using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rouba_monte
{
    internal class Carta
    {
        private int num;
        private string naipe;

        public string Naipe
        {
            get { return naipe; }
            set { naipe = value; }
        }

        public int Num
        {
            get { return num; }
            set { num = value; }
        }
        public Carta(int num, string naipe)
        {
            this.num = num;
            this.naipe = naipe;
        }

        public override string ToString()
        {
            return $"{num} - {naipe}";
        }

    }
}
