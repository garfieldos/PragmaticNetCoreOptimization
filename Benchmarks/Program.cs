using System;
using System.Linq;
using System.Reflection;
using BenchmarkDotNet.Running;

namespace Benchmarks
{
    class Program
    {
        static void Main(string[] args)
        {
            if ( args.Length != 1 || string.IsNullOrWhiteSpace(args[0]))
            {
                Console.WriteLine("Please provide benchmark name");
                return;
            }
                
            var benchMarkName = args[0];

            var benchmarkType = Assembly.GetAssembly(typeof(Program))
                .GetTypes().FirstOrDefault(x => x.Name == benchMarkName);
            
            if (benchmarkType == null)
            {
                Console.Write($"Could not find benchmark: {benchmarkType}");
                return;
            }
            
            BenchmarkRunner.Run(benchmarkType);
        }
    }
}
