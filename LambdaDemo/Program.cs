using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using LambdaDemo.boltProblem;

namespace LambdaDemo
{

    delegate int del(int i);
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch timer;
            TimeSpan timeSpan;

            Func<int, bool> myFunc = x => x == 5;
            bool result = myFunc(4);

            int[] numbers = new int[100000000];

            for (int i = 0; i< numbers.Length; i++)
            {
                numbers[i] = i;
            }

            timer = Stopwatch.StartNew();
            int oddNumberCount = numbers.Count(n => n %2 == 1);
            timer.Stop();
            timeSpan = timer.Elapsed;
            String lambdaTimeElapsed = String.Format("{0:00}:{1:00}:{2:00}", timeSpan.Minutes, timeSpan.Seconds, timeSpan.Milliseconds / 10);

            timer = Stopwatch.StartNew();
            int count = 0;
            foreach(int i in numbers)
            {
                if(i % 2 == 1)
                {
                    count++;
                }
            }
            timer.Stop();
            timeSpan = timer.Elapsed;
            String forLoopTimeElapsed = String.Format("{0:00}:{1:00}:{2:00}", timeSpan.Minutes, timeSpan.Seconds, timeSpan.Milliseconds / 10);

            Console.WriteLine("for loop : " + forLoopTimeElapsed + " " + oddNumberCount);
            Console.WriteLine("lambda   : " + lambdaTimeElapsed + " " + count);



            BoltProblemSolver problem = new BoltProblemSolver(10000000);

            timer = Stopwatch.StartNew();
            problem.solve();
            timer.Stop();
            timeSpan = timer.Elapsed;
            Console.WriteLine(String.Format("{0:00}:{1:00}:{2:00}", timeSpan.Minutes, timeSpan.Seconds, timeSpan.Milliseconds / 10));
            Console.WriteLine("Finished.");
            Console.ReadKey();
        }
    }
}
