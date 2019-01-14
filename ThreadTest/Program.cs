using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ThreadTest {
    class Program {
        static void Main(string[] args) {
            var prog = new Program();

            prog.DoParallelThread();

            Console.ReadLine();
        }

        public void DoParallelThread() {
            var parallel = new ParallelThread();

            parallel.StartParallelThread(10);

            for (int i = 0; i < 10; i++) {
                Console.WriteLine("Main Thread Iteration: " + i);
                Thread.Sleep(500);
            }
        }
    }
}
