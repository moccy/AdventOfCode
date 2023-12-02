using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Day4.Tests.Benchmark
{
    public class Benchmark
    {
        private readonly string[] _lines;

        public Benchmark()
        {
            _lines = File.ReadAllLines("input.txt");
        }

        [Benchmark]
        public void Part1() => Solver.SolvePart1(_lines);

        [Benchmark]
        public void Part2() => Solver.SolvePart2(_lines);
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<Benchmark>();
        }
    }
}