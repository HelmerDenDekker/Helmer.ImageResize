namespace Helmer.ImageResize.Domain;

public class ImageService
{
	private IEnumerable<string> _images;
	private string _imageDirectory;
	private string _outputDirectory;

	public ImageService()
	{
		_imageDirectory = FindClosestDirectory();
		_images = Load(_imageDirectory);
		_outputDirectory = CreateOutput(_imageDirectory);
    }


	public void SystemDrawingBenchmark(int size, int quality)
	{
		foreach (string image in _images)
		{
			new Domain.ResizeDrawing().ImageResize(size, image, _outputDirectory, quality);
        }
	}

	public void ImageSharpBenchmark(int size, int quality)
	{
		foreach (string image in _images)
		{
			new Domain.ResizeImageSharp().ImageResize(size, image, _outputDirectory, quality);
		}
	}

	public void MagickNetBenchmark(int size, int quality)
	{
		foreach (string image in _images)
		{
			new Domain.ResizeMagickNet().ImageResize(size, image, _outputDirectory, quality);
		}
	}
	public void MagicScalerBenchmark(int size, int quality)
	{
		foreach (string image in _images)
		{
			new Domain.ResizeMagicScaler().ImageResize(size, image, _outputDirectory, quality);
		}
	}
	public void MauiGraphicsBenchmark(int size, int quality)
	{
		foreach (string image in _images)
		{
			new Domain.ResizeMauiGraphics().ImageResize(size, image, _outputDirectory, quality);
		}
	}
	public void SkiaSharpBenchmark(int size, int quality)
	{
		foreach (string image in _images)
		{
			new Domain.ResizeSkiaSharp().ImageResize(size, image, _outputDirectory, quality);
		}
	}



    /// <summary>
    /// Loads filenames from the images directory //ToDo validation which is now in FindClosestDirectory
    /// </summary>
    /// <returns></returns>
    /// <exception cref="FileNotFoundException"></exception>
    private static IEnumerable<string> Load(string imageDirectory)
	{
		return Directory.EnumerateFiles(imageDirectory);
	}

    /// <summary>
    /// Crete Output directory //ToDo change it to take an input path later
    /// </summary>
    /// <param name="imageDirectory"></param>
	private static string CreateOutput(string imageDirectory)
	{
		// Create the output directory next to the images directory
		var outputDirectory = Path.Combine(Path.GetDirectoryName(imageDirectory), "output");
		if (!Directory.Exists(outputDirectory))
		{
			Directory.CreateDirectory(outputDirectory);
		}
		return outputDirectory;
	}

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    /// <exception cref="FileNotFoundException"></exception>
	private static string FindClosestDirectory()
	{
		// Find the closest images directory
		string imageDirectory = Path.GetFullPath(".");
		while (!Directory.Exists(Path.Combine(imageDirectory, "images")))
		{
			imageDirectory = Path.GetDirectoryName(imageDirectory);
			if (imageDirectory == null)
			{
				throw new FileNotFoundException("Could not find an image directory.");
			}
		}

		return Path.Combine(imageDirectory, "images");
	}
}