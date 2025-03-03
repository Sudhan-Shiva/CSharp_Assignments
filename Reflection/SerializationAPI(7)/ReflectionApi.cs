using System.Diagnostics;
using System.Reflection;

namespace SerializationAPI
{
    internal class ReflectionApi
    {
        public static void TestReflectionSerializer(object obj)
        {
            Stopwatch stopwatch = new Stopwatch();
            string assemblyPath = "../../../../Serializer.dll";
            stopwatch.Start();

            var reqAssembly = Assembly.LoadFrom(assemblyPath);

            var reqType = reqAssembly.GetType("Serializer.ObjectSerializer");
           
            var objectSerializer = Activator.CreateInstance(reqType);

            var SerializeToString = reqType.GetMethod("Serialize");
            var serializedProducts = "";
            if (!obj.GetType().IsPrimitive)
            {
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
        }
    }
}
