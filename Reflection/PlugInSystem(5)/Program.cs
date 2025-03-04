using System.Reflection;
using PlugInSystem;
using SixLabors.ImageSharp;
using Pastel;

/// <summary>
/// Entry class of the application
/// </summary>
public class Program
{
    /// <summary>
    /// Main method which acts as the Entry point to the program
    /// </summary>
    static void Main()
    {
        //Get all the plugin .dll files
        Console.WriteLine("Welcome....\n".Pastel(ConsoleColor.Magenta));
        string pluginPath = "../../../../Plugins/";
        string[] dllPaths = Directory.GetFiles(pluginPath, "*.dll");

        List<Assembly> assemblies = new List<Assembly>();

        //Load all the assemblies
        foreach (string path in dllPaths)
        {
            assemblies.Add(Assembly.LoadFrom(path));
        }

        //Select all the types in the assemblies which has implemented the interface
        var processorTypes = assemblies
            .SelectMany(a => a.GetTypes())
            .Where(t => typeof(IImageProcessor).IsAssignableFrom(t) && !t.IsInterface)
            .ToList();

        //Choose the image path
        Console.Write("Input the path of the image : ".Pastel(ConsoleColor.Yellow));
        // Eg : 'F:\C#_Assignments\Reflection\VS Keyboard Shortcuts.png'
        string? imagePath = Console.ReadLine();

        //Check if plugins are present
        if (processorTypes.Count() > 0)
        {
            //Check if the image exists
            if (File.Exists(imagePath))
            {
                //Load the image
                Image inputImage = Image.Load(imagePath);
                Console.WriteLine();

                //Print all the available processing options through the .dll name
                for (int count = 0; count < processorTypes.Count(); count++)
                {
                    Console.WriteLine($"[{count}] {(processorTypes[count]).Name}");
                }

                Console.Write("Choose the action to be performed : ".Pastel(ConsoleColor.Yellow));

                //Check if the input processing option is valid
                if (int.TryParse(Console.ReadLine(), out int processingAction) && processingAction >= 0 && processingAction < processorTypes.Count())
                {
                    if (Activator.CreateInstance(processorTypes[processingAction]) is IImageProcessor imageProcessor)
                    {
                        //Process the image
                        Image outputImage = imageProcessor.ProcessImage(inputImage);

                        //Create the path of the output image
                        string? imageName = imagePath.Split('\\').LastOrDefault();
                        string? imageDirectory = imagePath.Replace(imageName, "");
                        string? outputPath = Path.Combine(imageDirectory, $"{imageProcessor.ProcessorName}_Processed_{imageName}");
                        Console.WriteLine("\nProcessing the image.....".Pastel(ConsoleColor.Cyan));
                        outputImage.Save(outputPath);

                        Console.WriteLine($"\nProcessed image saved at : {outputPath}".Pastel(ConsoleColor.Magenta));
                    }
                }
                //If user provides an invalid processing option
                else
                {
                    Console.WriteLine("\nInvalid Action Performed !!! \nExiting....".Pastel(ConsoleColor.Red));
                }
            }
            //If the image is not present
            else
            {
                Console.WriteLine("\nImage not found....".Pastel(ConsoleColor.Red));
                Console.WriteLine("Exiting....".Pastel(ConsoleColor.Red));
            }
        }
        //f no plugins are present
        else
        {
            Console.WriteLine("No plugins found !!!!\nExiting....".Pastel(ConsoleColor.Red));
        }

        Console.ReadKey();
    }
}
