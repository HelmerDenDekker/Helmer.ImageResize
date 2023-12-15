using BenchmarkDotNet.Attributes;
using Helmer.ImageResize.Domain.Resize;

namespace Helmer.ImageResize.Benchmark;

public class ImageResizeBenchmark
{
	private int size = 150;
	private int quality = 75;

	[Benchmark]
	public void ResizeDrawing() => new ImageService().SystemDrawingBenchmark(size, quality);

    [Benchmark]
	public void ResizeImageSharp() => new ImageService().ImageSharpBenchmark(size, quality);


    [Benchmark]
	public void ResizeMagickNet() => new ImageService().MagickNetBenchmark(size, quality);

    [Benchmark]
	public void ResizeMagicScaler() => new ImageService().MagicScalerBenchmark(size, quality);

    [Benchmark]
	public void ResizeSkiaSharp() => new ImageService().SkiaSharpBenchmark(size, quality);
}