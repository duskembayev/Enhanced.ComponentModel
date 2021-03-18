using BenchmarkDotNet.Running;

namespace Enhanced.ComponentModel.Benchmarks
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            BenchmarkRunner.Run(typeof(Program).Assembly);
        }
    }
}