using System;
using System.IO;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Day3.Benchmark
{
    public class Benchmark
    {
        private readonly string[] _lines;
        private readonly Solver _solver;

        public Benchmark()
        {
            _lines = File.ReadAllLines("input.txt");
            _solver = new Solver();
        }

        [Benchmark]
        public void Part1() => _solver.SolvePart1(_lines);

        [Benchmark]
        public void Part2() => _solver.SolvePart2(_lines);
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<Benchmark>();
        }
    }
}