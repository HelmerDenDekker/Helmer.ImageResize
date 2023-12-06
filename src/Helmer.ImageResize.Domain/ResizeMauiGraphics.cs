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
        using (var output = File.Open(FileNameLogic.OutputPath(sourcePath, destinationPath, "Maui"), FileMode.Create))
        {
            image = PlatformImage.FromStream(output);

            var scaled = SizeLogic.ScaledSize(image.Width, image.Height, size);
            //Resize

            IImage newImage = image.Resize(scaled.width, scaled.height, ResizeMode.Stretch, true);
            //Displayed
            //canvas.DrawImage(newImage, 10, 10, newImage.Width, newImage.Height);

            newImage.Save(output);
        }
    }

    public void ImageDownsize(IImage image)
    {
        IImage newImage = image.Downsize(100, true);
    }
}