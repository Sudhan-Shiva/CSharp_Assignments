using System.Diagnostics;
using System.Reflection;

namespace SerializationAPI
{
    /// <summary>
    /// Class which handles the serialization api using reflection
    /// </summary>
    internal class ReflectionApi
    {
        /// <summary>
        /// To test the serialization api
        /// </summary>
        /// <param name="obj"></param>
        public static void TestReflectionSerializer(object obj)
        {
            Stopwatch stopwatch = new Stopwatch();
            string assemblyPath = "../../../../Serializer.dll";
            stopwatch.Start();

            //Load the assembly and create the instance of the type
            var reqAssembly = Assembly.LoadFrom(assemblyPath);
            var reqType = reqAssembly.GetType("Serializer.ObjectSerializer");          
            var objectSerializer = Activator.CreateInstance(reqType);

            //Get the serializing method
            var SerializeToString = reqType.GetMethod("Serialize");
            var serializedProducts = "";

            if (!obj.GetType().IsPrimitive)
            {
                //Concatenate all the property name and values
                foreach (var property in obj.GetType().GetProperties())
                {
                    serializedProducts += SerializeToString.Invoke(objectSerializer, new object[] { $"{property.Name} = {property.GetValue(obj)}, " });
                }
            }
            else
            {
                serializedProducts = (string) SerializeToString.Invoke(objectSerializer, new object[] { obj });
            }
    
            stopwatch.Stop();
            Console.WriteLine("Time for conversion by Reflection : " + stopwatch.ElapsedMilliseconds + " ms");
            Console.WriteLine("Serialized Result by Reflection : " + serializedProducts);
            Console.WriteLine();
        }
    }
}
