using System.Text;

public class Program
{
    static void Main()
    {
        string path = "path-to-your-file.txt";
        string data = "This is some test data";

        //Writing to file using FileStream
        using (FileStream fileStream = new FileStream(path, FileMode.Create))
        {
            byte[] writeBuffer = Encoding.ASCII.GetBytes(data);
            fileStream.Write(writeBuffer, 0, writeBuffer.Length);
        }

        //Reading from file using FileStream
        using (FileStream fileStream = new FileStream(path, FileMode.Open))
        {
            byte[] buffer = new byte[1024];

            while (fileStream.Read(buffer, 0, buffer.Length) > 0)
            {
                string outputData = Encoding.UTF8.GetString(buffer);
                Console.Write(outputData);
            }
        }

        Console.ReadKey();
    }
}
