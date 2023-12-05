namespace Helmer.ImageResize.Domain;

public class ImageService
{
	public void Resize()
	{
		// Inputs are Quality, Size


		//Load

		var fileOperations = new FileOperations();
		var imageDirectory = fileOperations.FindClosestDirectory();
		var files = fileOperations.Load(imageDirectory);
		fileOperations.CreateOutput(imageDirectory);


		//Resize


		//Save

	}
}