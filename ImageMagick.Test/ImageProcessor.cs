namespace ImageMagick.Test;

public class ImageProcessor
{
    
    private const string WATER_MARK_FILE_PATH = "Assets/watermark.png";

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
        
        if (useWaterMark)
        {
            WaterMark(image);
        }

        originalImage.Position = 0;
        return image;
    }
    
    private void WaterMark(MagickImage image)
    {
        using var watermark = new MagickImage(WATER_MARK_FILE_PATH);
        watermark.Evaluate(Channels.Opacity, EvaluateOperator.Divide, 3);
        var waterMarkSize = image.Height / 3;
        if (image.Width > image.Height)
        {
            waterMarkSize = image.Width / 3;
        }
        watermark.Resize(waterMarkSize, waterMarkSize);
        image.Composite(watermark, Gravity.Center, CompositeOperator.Blend);
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