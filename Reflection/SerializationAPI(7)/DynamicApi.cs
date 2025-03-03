using System;
using System.Diagnostics;
using System.Reflection;
using System.Reflection.Emit;

namespace SerializationAPI
{
    internal class DynamicApi
    {
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
                    ilGenerator.Emit(OpCodes.Ldstr, property.Name + "= ");
                    ilGenerator.Emit(OpCodes.Call, typeof(string).GetMethod("Concat", new Type[] { typeof(string), typeof(string) }));

                    ilGenerator.Emit(OpCodes.Ldarg_0);
                    ilGenerator.Emit(OpCodes.Callvirt, property.GetGetMethod());

                    if (property.PropertyType.IsValueType)
                    {
                        ilGenerator.Emit(OpCodes.Box, property.PropertyType);
                    }

                    ilGenerator.Emit(OpCodes.Callvirt, typeof(object).GetMethod("ToString", Type.EmptyTypes));

                    ilGenerator.Emit(OpCodes.Call, typeof(string).GetMethod("Concat", new Type[] { typeof(string), typeof(string) }));

                    ilGenerator.Emit(OpCodes.Ldstr, ", ");
                    ilGenerator.Emit(OpCodes.Call, typeof(string).GetMethod("Concat", new Type[] { typeof(string), typeof(string) }));

                }
            }

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
        }
    }
}