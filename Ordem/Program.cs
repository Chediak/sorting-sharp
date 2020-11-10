using System;
using System.Diagnostics;

namespace Ordem
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            for (var i = 0; i < 5; i++)
            {
                Console.WriteLine($"=== Rodada {i + 1} ===");
                Sort.Method1();
                Sort.Method2();
                Sort.Method3();
                Console.WriteLine($"==================\n");
            }

            sw.Stop();
            Console.WriteLine($"Rodadas finalizadas. Tempo total: {sw.ElapsedMilliseconds}ms");

            Console.ReadLine();
        }
    }
}
