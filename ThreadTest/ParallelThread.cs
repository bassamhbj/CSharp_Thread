using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ThreadTest {
    public class ParallelThread {
        public ParallelThread() {

        }

        public void StartParallelThread(int threadCount) {
            StartParallelThread(() => {
                for (int i = 0; i < 10; i++) {
                    Console.WriteLine($"Thread Name: {Thread.CurrentThread.Name} Loop Iteration: {i}");
                    Thread.Sleep(1000);
                }
            }, threadCount);
        }

        public void StartParallelThread(ThreadStart action, int threadCount) {
            for (int i = 0; i < threadCount; i++) {
                CreateThread(action, $"Thread_{i}");
            }
        }

        private void CreateThread(ThreadStart action, string threadName = "", bool isJoin = false) {
            var thread = new Thread(action);

            thread.Name = !string.IsNullOrEmpty(threadName.Trim()) ? threadName : GetRandomThreadName();

            thread.Start();

            if (isJoin) { thread.Join(); }
        }

        private string GetRandomThreadName() =>
            $"Thread_{new Random().Next(0, 999)}";
    }
}
