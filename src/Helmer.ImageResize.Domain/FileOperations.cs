namespace Helmer.ImageResize.Domain;

public class FileOperations
{
	/// <summary>
	/// Loads filenames from the images directory //ToDo validation which is now in FindClosestDirectory
	/// </summary>
	/// <returns></returns>
	/// <exception cref="FileNotFoundException"></exception>
	public IEnumerable<string> Load(string imageDirectory)
	{
		return Directory.EnumerateFiles(imageDirectory);
	}

	/// <summary>
	/// Crete Output directory //ToDo change it to take an input path later
	/// </summary>
	/// <param name="imageDirectory"></param>
	public void CreateOutput(string imageDirectory)
	{
		// Create the output directory next to the images directory
		var outputDirectory = Path.Combine(Path.GetDirectoryName(imageDirectory), "output");
		if (!Directory.Exists(outputDirectory))
		{
			Directory.CreateDirectory(outputDirectory);
		}
	}

	/// <summary>
	/// 
	/// </summary>
	/// <returns></returns>
	/// <exception cref="FileNotFoundException"></exception>
	public string FindClosestDirectory()
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