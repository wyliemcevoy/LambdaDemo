using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaDemo
{
    class Nut
    {
        public int Size { get; set; }

        public Nut(int size)
        {
            this.Size = size;
        }

        public override string ToString()
        {
            return "Nut : " + Size;
        }
    }
}
