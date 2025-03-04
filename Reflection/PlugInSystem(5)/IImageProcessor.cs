using SixLabors.ImageSharp;

namespace PlugInSystem
{
    /// <summary>
    /// Interface which is implemented in the plugins
    /// </summary>
    public interface IImageProcessor
    {
        /// <summary>
        /// Name of the process
        /// </summary>
        string ProcessorName { get; }

        /// <summary>
        /// Method to process the image
        /// </summary>
        /// <param name="image">The image which is to be processed</param>
        /// <returns></returns>
        Image ProcessImage(Image image);
    }
}
