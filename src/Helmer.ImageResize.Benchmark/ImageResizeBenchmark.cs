using BenchmarkDotNet.Attributes;
using Helmer.ImageResize.Domain;

namespace Helmer.ImageResize.Benchmark;

public class ImageResizeBenchmark
{
    //ToDo List of images you want to resize.

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
	public void ResizeMauiGraphics() => new ImageService().MauiGraphicsBenchmark(size, quality);

    [Benchmark]
	public void ResizeSkiaSharp() => new ImageService().SkiaSharpBenchmark(size, quality);
}