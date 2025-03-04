using MockFramework;
using System.Reflection.Emit;
using System.Reflection;

/// <summary>
/// Class to create dynamic entities
/// </summary>
public class InstanceCreator
{
    /// <summary>
    /// To return the instance of the dynamic type created
    /// </summary>
    /// <returns>The instance of the dynamic type</returns>
    public object CreateDynamicTypeInstance()
    {
        //Create the dynamic assembly, module and type which implements the interface.
        AssemblyBuilder? assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(new AssemblyName("DynamicAssembly"), AssemblyBuilderAccess.Run);
        Console.WriteLine($"Assembly : {assemblyBuilder.FullName?.Split(',').FirstOrDefault()} is created.\n");
        ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule("DynamicModule");
        TypeBuilder typeBuilder = moduleBuilder.DefineType("DynamicType");
        typeBuilder.AddInterfaceImplementation(typeof(IMockInterface));
        Console.WriteLine($"Type : {typeBuilder.FullName} is created with the implementation of IMockInterface.\n");

        //To define all the methods in the interface
        foreach (var method in typeof(IMockInterface).GetMethods())
        {
            var parameterArguments = method.GetParameters().Select(i => i.ParameterType);

            //To build the method of the interface in the dynamic type.
            MethodBuilder methodBuilder = typeBuilder.DefineMethod(method.Name, MethodAttributes.Public | MethodAttributes.Virtual, method.ReturnType, parameterArguments.ToArray());
            ILGenerator ilGenerator = methodBuilder.GetILGenerator();

            //Return the default value according to the return type of the method.
            switch (method.ReturnType.Name)
            {
                case "String":
                    ilGenerator.Emit(OpCodes.Ldstr, "Default");
                    break;
                case "Int32":
                    ilGenerator.Emit(OpCodes.Ldc_I4, 10);
                    break;
                case "Double":
                    ilGenerator.Emit(OpCodes.Ldc_R8, 10.50);
                    break;
                case "Single":
                    ilGenerator.Emit(OpCodes.Ldc_R4, (float) 12.50);
                    break;
                case "Int64":
                    ilGenerator.Emit(OpCodes.Ldc_I8, 123445678890123);
                    break;
                case "Boolean":
                    ilGenerator.Emit(OpCodes.Ldc_I8, 1 );
                    break;
            }

            ilGenerator.Emit(OpCodes.Ret);
            typeBuilder.DefineMethodOverride(methodBuilder, typeof(IMockInterface).GetMethod(method.Name));
        }

        //Instance the type and execute all the methods.
        var dynamicType = typeBuilder.CreateType();
        object typeInstance = Activator.CreateInstance(dynamicType);
        foreach (var method in typeof(IMockInterface).GetMethods())
        {
            var dynamicMethod = dynamicType.GetMethod(method.Name);

            var parameters = new object[method.GetParameters().Length];

            var returnOutput = dynamicMethod?.Invoke(typeInstance, parameters);
            Console.WriteLine($"The default implementation of method '{dynamicMethod.Name}' returns : {returnOutput}");
        }

        return Activator.CreateInstance(dynamicType);
    }
}
