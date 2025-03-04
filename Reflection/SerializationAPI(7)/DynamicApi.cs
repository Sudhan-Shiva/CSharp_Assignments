using System.Diagnostics;
using System.Reflection;
using System.Reflection.Emit;

namespace SerializationAPI
{
    /// <summary>
    /// Class which handles the serialization api using reflection emit
    /// </summary>
    internal class DynamicApi
    {
        /// <summary>
        /// To test the serialization api
        /// </summary>
        /// <param name="obj"></param>
        public static void TestDynamicApi(object obj)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            AssemblyBuilder assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(new AssemblyName("DynamicAssembly"), AssemblyBuilderAccess.Run);
            ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule("DynamicModule");
            TypeBuilder typeBuilder = moduleBuilder.DefineType("ObjectSerializer");

            MethodBuilder methodBuilder = typeBuilder.DefineMethod(
                "Serialize",
                MethodAttributes.Public | MethodAttributes.Static,
                typeof(string),
                new Type[] { typeof(object) });

            var ilGenerator = methodBuilder.GetILGenerator();

            if (!obj.GetType().IsPrimitive)
            {
                ilGenerator.Emit(OpCodes.Ldstr, "");

                foreach (var property in obj.GetType().GetProperties())
                {
                    //To load the property name
                    ilGenerator.Emit(OpCodes.Ldstr, property.Name + "= ");
                    ilGenerator.Emit(OpCodes.Call, typeof(string).GetMethod("Concat", new Type[] { typeof(string), typeof(string) }));

                    //To get the value of the properties in the object
                    ilGenerator.Emit(OpCodes.Ldarg_0);
                    ilGenerator.Emit(OpCodes.Callvirt, property.GetGetMethod());

                    //To box the value type properties so that it can be concatenated
                    if (property.PropertyType.IsValueType)
                    {
                        ilGenerator.Emit(OpCodes.Box, property.PropertyType);
                    }

                    //Convert the property values to string
                    ilGenerator.Emit(OpCodes.Callvirt, typeof(object).GetMethod("ToString", Type.EmptyTypes));

                    //Concatenate the property name and the value
                    ilGenerator.Emit(OpCodes.Call, typeof(string).GetMethod("Concat", new Type[] { typeof(string), typeof(string) }));

                    //Concatenate all the properties in the object
                    ilGenerator.Emit(OpCodes.Ldstr, ", ");
                    ilGenerator.Emit(OpCodes.Call, typeof(string).GetMethod("Concat", new Type[] { typeof(string), typeof(string) }));

                }
            }

            //To handle the primitive datatypes
            else if (obj.GetType().IsPrimitive)
            {
                ilGenerator.Emit(OpCodes.Ldarg_0);
                ilGenerator.Emit(OpCodes.Callvirt, typeof(object).GetMethod("ToString", Type.EmptyTypes));
            }

            ilGenerator.Emit(OpCodes.Ret);
            Type objectSerializer = typeBuilder.CreateType();

            var serializeMethod = typeBuilder.GetMethod("Serialize");

            var serializedResult = (string)serializeMethod.Invoke(null, new object[] { obj });

            stopwatch.Stop();
            Console.WriteLine("Time for conversion by Reflection Emit : " + stopwatch.ElapsedMilliseconds + " ms");
            Console.WriteLine("Serialized Result by Reflection Emit : " + serializedResult);
            Console.WriteLine();
        }
    }
}
