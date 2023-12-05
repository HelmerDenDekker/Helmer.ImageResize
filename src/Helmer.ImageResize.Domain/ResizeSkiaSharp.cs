namespace Helmer.ImageResize.Domain;

public class ResizeSkiaSharp
{
	public void ImageResize(int width, int height, string sourcePath, string destinationPath)
	{
		using (var input = File.OpenRead(inputPath))
		{
			using (var inputStream = new SKManagedStream(input))
			{
				using (var original = SKBitmap.Decode(inputStream))
				{
					int width, height;
					if (original.Width > original.Height)
					{
						width = size;
						height = original.Height * size / original.Width;
					}
					else
					{
						width = original.Width * size / original.Height;
						height = size;
					}

					using (var resized = original
								.Resize(new SKImageInfo(width, height), SKBitmapResizeMethod.Lanczos3))
					{
						if (resized == null) return;

						using (var image = SKImage.FromBitmap(resized))
						{
							using (var output =
									File.OpenWrite(OutputPath(path, outputDirectory, SkiaSharpBitmap)))
							{
								image.Encode(SKImageEncodeFormat.Jpeg, Quality)
									.SaveTo(output);
							}
						}
					}
				}
			}
		}
	}
}