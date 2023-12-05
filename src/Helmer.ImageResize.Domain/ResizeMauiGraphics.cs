using Helmer.ImageResize.Domain.Extensions;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Graphics.Platform;

namespace Helmer.ImageResize.Domain;

public class ResizeMauiGraphics
{
	// inputs width, height, resizemode, disposeOriginal

	public void ImageResize(int size, string sourcePath, string destinationPath, int quality)
	{
		
        //Load
        IImage image;
		//Assembly assembly = GetType().GetTypeInfo().Assembly;
		using (Stream stream = assembly.GetManifestResourceStream("GraphicsViewDemos.Resources.Images.dotnet_bot.png"))
		{
			image = PlatformImage.FromStream(stream);
		}
		var scaled = SizeLogic.ScaledSize(image.Width, image.Height, size);
		//Resize
		if (image != null)
		{
			IImage newImage = image.Resize(scaled.width, scaled.height, ResizeMode.Stretch, true);
			//Displayed
			//canvas.DrawImage(newImage, 10, 10, newImage.Width, newImage.Height);
		}

		// Save image to a memory stream
		if (image != null)
		{
			IImage newImage = image.Downsize(150, true);
			using (MemoryStream memStream = new MemoryStream())
			{
				newImage.Save(memStream);
			}
		}
	}

	public void ImageDownsize(IImage image)
	{
		IImage newImage = image.Downsize(100, true);
	}
}