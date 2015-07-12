using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaDemo
{
    class Bolt
    {
        public int Size { get; set; }

        public Bolt (int size)
        {
            this.Size = size;
        }

        public override string ToString()
        {
            return "Bolt : " + Size;
        }
    }
}
