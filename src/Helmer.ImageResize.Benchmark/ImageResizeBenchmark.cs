using BenchmarkDotNet.Attributes;

namespace Helmer.ImageResize.Benchmark;

public class ImageResizeBenchmark
{
	//ToDo List of images you want to resize.

	private int height = 450; //ToDo should be maxwidth, think about how you want the images to be resized!!
	private int width = 450;
	private string sourcePath = "";
	private string destinationPath = "";

	[Benchmark]
	public void ResizeDrawing() => new Domain.ResizeDrawing().ImageResize(width, height, sourcePath, destinationPath);

	[Benchmark]
	public void ResizeImageSharp() => new Domain.ResizeImageSharp().ImageResize(width, height, sourcePath, destinationPath);


	[Benchmark]
	public void ResizeMagickNet() => new Domain.ResizeMagickNet().ImageResize(width, height, sourcePath, destinationPath);

	[Benchmark]
	public void ResizeMagicScaler() => new Domain.ResizeMagicScaler().ImageResize(width, height, sourcePath, destinationPath);

	[Benchmark]
	public void ResizeMauiGraphics() => new Domain.ResizeMauiGraphics().ImageResize(width, height, sourcePath, destinationPath);

	[Benchmark]
	public void ResizeSkiaSharp() => new Domain.ResizeSkiaSharp().ImageResize(width, height, sourcePath, destinationPath);
}