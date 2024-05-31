using ImageMagick;
using ImageMagick.Test;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", async () =>
{
    var imageProcessor = new ImageProcessor();
    var fileStream = new FileStream("Assets/DSCF7482.jpg", FileMode.Open);
    var compressed = imageProcessor.Compress(fileStream, ".jpg", 75, MagickFormat.WebP, 1080, 1920);
    return await imageProcessor.SaveCompressed(compressed);
});

app.Run();