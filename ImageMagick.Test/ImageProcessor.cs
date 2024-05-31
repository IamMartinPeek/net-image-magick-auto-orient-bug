namespace ImageMagick.Test;

public class ImageProcessor
{
    public MagickImage Compress(Stream originalImage, string originalFileExtension, int quality, MagickFormat convertTo, int? width = null, int height = 0, bool useWaterMark = false)
    {
        var format = ImageFormat.ConvertToMagickFormat(originalFileExtension);
            
        MagickImage image;
        originalImage.Seek(0, SeekOrigin.Begin);
        if (format.HasValue)
        {
            var readSettings = new MagickReadSettings { Format = format.Value };
            image = new MagickImage(originalImage, readSettings);
        }
        else
        {
            image = new MagickImage(originalImage);
        }
            
        image.AutoOrient();
            
        if (width.HasValue && width < image.Width)
            image.Thumbnail(width.Value, height);
            
        image.Quality = quality;
        image.Format = convertTo;

        originalImage.Position = 0;
        return image;
    }
    
    public async Task<string> SaveCompressed(MagickImage image)
    {
        var tempFilePath = Path.GetTempFileName();
        await using (var fs = new FileStream(tempFilePath, FileMode.Create))
        {
            await image.WriteAsync(fs);
            fs.Position = 0;
        }

        return tempFilePath;
    }
}