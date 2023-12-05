using Helmer.ImageResize.Domain.Extensions;
using PhotoSauce.MagicScaler;

namespace Helmer.ImageResize.Domain;

public class ResizeMagicScaler
{
	public void ImageResize(int size, string sourcePath, string destinationPath, int quality)
	{
		var scaled = SizeLogic.ScaledSize(image.Width, image.Height, size);
        var settings = new ProcessImageSettings()
		{
			Width = size,
			Height = size,
			ResizeMode = CropScaleMode.Max,
			SaveFormat = FileFormat.Jpeg,
			JpegQuality = quality,
			JpegSubsampleMode = ChromaSubsampleMode.Subsample420
		};

		using (var output = new FileStream(FileNameLogic.OutputPath(sourcePath, destinationPath, "MagicScaler"), FileMode.Create))
		{
			MagicImageProcessor.ProcessImage(sourcePath, output, settings);
		}
	}
}