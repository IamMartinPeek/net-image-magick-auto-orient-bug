namespace ImageMagick.Test;

public static class ImageFormat
{
    
    //x3f not working: https://github.com/ImageMagick/ImageMagick/issues/4753
    public static readonly string[] SUPPORTED_FILE_FORMATS = new[]
    {
        ".jpg", ".jpeg", ".png", ".cr2", ".cr3", ".heic", ".raw", ".rw2", ".raf", ".nrw", ".arw", ".dng", ".nef",
        ".dds", ".srw", ".orf", ".pict", ".raf", ".3fr", ".tiff", ".tif", ".gif", ".crw", ".sr2", ".mrw", ".erf", ".avif", ".srf",
        ".dcr", ".dcs", ".k25", ".drf", ".kdc", ".pef", ".mef", ".mos", ".webp"
    };
    
    public static MagickFormat? ConvertToMagickFormat(string format)
    {
        format = format.ToLower();

        return format switch
        {
            ".gif" => MagickFormat.Gif,
            ".orf" => MagickFormat.Orf,
            ".nrw" => MagickFormat.Nrw,
            ".raf" => MagickFormat.Raf,
            ".rw2" => MagickFormat.Rw2,
            ".nef" => MagickFormat.Nef,
            ".heic" => MagickFormat.Heic,
            ".heif" => MagickFormat.Heif,
            ".cr2" => MagickFormat.Cr2,
            ".cr3" => MagickFormat.Cr3,
            ".arw" => MagickFormat.Arw,
            ".crw" => MagickFormat.Crw,
            ".sr2" => MagickFormat.Sr2,
            ".dng" => MagickFormat.Dng,
            ".png" => MagickFormat.Png,
            ".dds" => MagickFormat.Dds,
            ".jpeg" => MagickFormat.Jpeg,
            ".jpg" => MagickFormat.Jpg,
            ".3fr" => MagickFormat.ThreeFr,
            ".srw" => MagickFormat.Raw,
            ".srf" => MagickFormat.Srf,
            ".raw" => MagickFormat.Raw,
            ".pict" => MagickFormat.Pict,
            ".tiff" => MagickFormat.Tiff,
            ".tif" => MagickFormat.Tif,
            ".mrw" => MagickFormat.Mrw,
            ".erf" => MagickFormat.Erf,
            ".avif" => MagickFormat.Avif,
            ".dcr" => MagickFormat.Dcr,
            ".dcs" => MagickFormat.Raw,
            ".drf" => MagickFormat.Raw,
            ".k25" => MagickFormat.K25,
            ".mef" => MagickFormat.Mef,
            ".webp" => MagickFormat.WebP,
            ".kdc" => MagickFormat.Kdc,
            ".pef" => MagickFormat.Pef,
            ".mos" => MagickFormat.Raw,
            _ => null
        };
    }
}