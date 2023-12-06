using BenchmarkDotNet.Attributes;

namespace Helmer.ImageResize.Benchmark;

public class ImageResizeBenchmark
{
	//ToDo List of images you want to resize.

	private int size = 150;
	private string sourcePath = "";
	private string destinationPath = "";
	private int quality = 75;

	[Benchmark]
	public void ResizeDrawing() => new Domain.ResizeDrawing().ImageResize(size, sourcePath, destinationPath, quality);

	[Benchmark]
	public void ResizeImageSharp() => new Domain.ResizeImageSharp().ImageResize(size, sourcePath, destinationPath, quality);


	[Benchmark]
	public void ResizeMagickNet() => new Domain.ResizeMagickNet().ImageResize(size, sourcePath, destinationPath, quality);

	[Benchmark]
	public void ResizeMagicScaler() => new Domain.ResizeMagicScaler().ImageResize(size, sourcePath, destinationPath, quality);

	[Benchmark]
	public void ResizeMauiGraphics() => new Domain.ResizeMauiGraphics().ImageResize(size, sourcePath, destinationPath, quality);

	[Benchmark]
	public void ResizeSkiaSharp() => new Domain.ResizeSkiaSharp().ImageResize(size, sourcePath, destinationPath, quality);
}