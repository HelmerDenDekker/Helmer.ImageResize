using BenchmarkDotNet.Running;
using Helmer.ImageResize.Benchmark;

public class Program
{
	public static void Main(string[] args) => BenchmarkRunner.Run<ImageResizeBenchmark>();
	//BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
}
