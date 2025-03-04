using System.Reflection;
using PlugInSystem;
using SixLabors.ImageSharp;
using Pastel;

public class Program
{
    static void Main()
    {
        Console.WriteLine("Welcome....\n".Pastel(ConsoleColor.Magenta));
        string pluginPath = "../../../../Plugins/";
        string[] dllPaths = Directory.GetFiles(pluginPath, "*.dll");

        List<Assembly> assemblies = new List<Assembly>();

        foreach (string path in dllPaths)
        {
            assemblies.Add(Assembly.LoadFrom(path));
        }

        var processorTypes = assemblies
            .SelectMany(a => a.GetTypes())
            .Where(t => typeof(IImageProcessor).IsAssignableFrom(t) && !t.IsInterface)
            .ToList();

        Console.Write("Input the path of the image : ".Pastel(ConsoleColor.Yellow));
        // Image Path : ../../../../VS Keyboard Shortcuts.png
        string imagePath = Console.ReadLine();

        if (File.Exists(imagePath))
        {
            Image inputImage = Image.Load(imagePath);
            Console.WriteLine();
            for (int count = 0; count < processorTypes.Count(); count++)
            {
                Console.WriteLine($"[{count}] {(processorTypes[count]).Name}");
            }

            Console.Write("Choose the action to be performed : ".Pastel(ConsoleColor.Yellow));

            if (int.TryParse(Console.ReadLine(), out int processingAction) && processingAction >= 0 && processingAction < processorTypes.Count())
            {
                if (Activator.CreateInstance(processorTypes[processingAction]) is IImageProcessor imageProcessor)
                {
                    Image outputImage = imageProcessor.ProcessImage(inputImage);

                    string imageName = imagePath.Split('/').LastOrDefault();
                    string imageDirectory = imagePath.Replace(imageName, "");
                    string outputPath = Path.Combine(imageDirectory, $"{imageProcessor.ProcessorName}_Processed_{imageName}");
                    Console.WriteLine("\nProcessing the image.....".Pastel(ConsoleColor.Cyan));
                    outputImage.Save(outputPath);

                    Console.WriteLine($"\nProcessed image saved: {outputPath}".Pastel(ConsoleColor.Magenta));
                }
            }
            else
            {
                Console.WriteLine("\nInvalid Action Performed !!! \nExiting....".Pastel(ConsoleColor.Red));
            }
        }
        else
        {
            Console.WriteLine("\nImage not found....".Pastel(ConsoleColor.Red));
            Console.WriteLine("Exiting....".Pastel(ConsoleColor.Red));
        }

        Console.ReadKey();
    }
}
