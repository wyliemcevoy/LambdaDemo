using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaDemo.boltProblem
{

    class BoltNode
    {
        public BoltNode(Bolt bolt , Nut nut)
        {
            this.bolt = bolt;
            this.nut = nut;
        }

        public Bolt bolt { get; set; }
        public Nut nut { get; set; }

        public BoltNode left { get; set; }
        public BoltNode right { get; set; }

    }
}
