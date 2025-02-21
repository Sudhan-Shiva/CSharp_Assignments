using System.Text;

public class Program
{
    static void Main()
    {
        string path = "path-to-your-file";
        string data = "This is some test data";

        //Writing to file using MemoryStream
        using (MemoryStream memoryStream = new MemoryStream())
        {
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            memoryStream.Write(buffer, 0, buffer.Length);
            
            using (FileStream fileStream = new FileStream(path, FileMode.Create))
            {
                byte[] writeBuffer = memoryStream.ToArray();
                fileStream.Write(writeBuffer, 0, writeBuffer.Length);
            }
        }

        // Reading from file using FileStream
        using (FileStream fileStream = new FileStream(path, FileMode.Open))
        {
            byte[] buffer = new byte[1024];
            int bytesRead;

            while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) > 0)
            {
                //Simulate memory inefficiency
                for (int i=0; i< bytesRead; i++)
                {
                    Console.Write((char)buffer[i]);
                }
                Console.WriteLine();
            }
        }
        Console.ReadKey();
    }
}
