using SixLabors.ImageSharp;

namespace PlugInSystem
{
    public interface IImageProcessor
    {
        string ProcessorName { get; }
        Image ProcessImage(Image image);
    }
}
