using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaDemo.boltProblem
{
    class BoltProblemSolver
    {
        private int Size;
        private Bolt[] ProblemBolts;
        private Nut[] ProblemNuts;
        private Random rand;

        private Func<Bolt, Nut, int> comparitor = (bolt, nut) =>
          {
              if (bolt.Size > nut.Size)
                  return 1;
              if (bolt.Size < nut.Size)
                  return -1;
              return 0;
          };

        public BoltProblemSolver(int size)
        {
            this.Size = size;
            this.ProblemBolts = new Bolt[Size];
            this.ProblemNuts = new Nut[Size];
            this.rand = new Random();

            for (int i=0; i<Size;i++)
            {
                ProblemBolts[i] = new Bolt(i);
                ProblemNuts[i] = new Nut(i);
            }

            // Randomize Lists
            ProblemNuts = ProblemNuts.OrderBy(x => rand.Next()).ToArray();
            ProblemBolts = ProblemBolts.OrderBy(x => rand.Next()).ToArray();
        }

        public void solve()
        {
            BoltNode root = assembleTree(ProblemNuts.ToList(),ProblemBolts.ToList());

            //printTree(root);
        }



        private Nut findMatchingNut(Bolt bolt, List<Nut> nuts)
        {
            return nuts.Where(nut => nut.Size == bolt.Size).ToArray()[0];
        }


        private BoltNode assembleTree(List<Nut> nuts, List<Bolt> bolts)
        {
            // Termination condition
            if (nuts.Count == 0)
                return null;
            if (nuts.Count == 1)
            {
                return new BoltNode(bolts[0], nuts[0]);
            }

            Bolt pivotBolt = bolts[0];
            Nut pivotNut = nuts.Where(nut => nut.Size == pivotBolt.Size).ToArray()[0];

            nuts.Remove(pivotNut);
            bolts.Remove(pivotBolt);

            List<Nut> smallerNuts = nuts.Where(nut => nut.Size < pivotBolt.Size).ToList();
            List<Nut> largerNuts = nuts.Where(nut => nut.Size > pivotBolt.Size).ToList();
            List<Bolt> smallerBolts = bolts.Where(bolt => bolt.Size < pivotNut.Size).ToList();
            List<Bolt> largerBolts = bolts.Where(bolt => bolt.Size > pivotNut.Size).ToList();


            BoltNode node = new BoltNode(pivotBolt, pivotNut);

            node.left = assembleTree(smallerNuts, smallerBolts);
            node.right = assembleTree(largerNuts, largerBolts);


            return node;
        }

        private void printTree(BoltNode node)
        {
            if (node != null)
            {
                printTree(node.left);
                Console.WriteLine(node.bolt.ToString() + " "  + node.nut.ToString());
                printTree(node.right);
            }
        }

    }
}
