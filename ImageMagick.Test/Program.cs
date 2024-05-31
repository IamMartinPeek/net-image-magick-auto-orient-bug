using ImageMagick;
using ImageMagick.Test;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

ResourceLimits.Memory = 1073741824;
ResourceLimits.MaxMemoryRequest = 20000000;//20 Megabyte
ResourceLimits.Throttle = 50;
ResourceLimits.Thread = 1;
ResourceLimits.Time = 120;

app.MapGet("/", async () =>
{
    var imageProcessor = new ImageProcessor();
    var fileStream = new FileStream("Assets/DSCF7482.jpg", FileMode.Open);
    //NOTE: add height parameter here to make it work
    var compressed = imageProcessor.Compress(fileStream, ".jpg", 75, MagickFormat.WebP, 1920, useWaterMark: false);
    return await imageProcessor.SaveCompressed(compressed);
});

app.Run();