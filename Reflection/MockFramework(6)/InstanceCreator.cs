using MockFramework;
using System.Reflection.Emit;
using System.Reflection;

public class InstanceCreator
{
    public object CreateDynamicTypeInstance()
    {
        AssemblyBuilder? assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(new AssemblyName("DynamicAssembly"), AssemblyBuilderAccess.Run);
        Console.WriteLine($"Assembly : {assemblyBuilder.FullName?.Split(',').FirstOrDefault()} is created.\n");
        ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule("DynamicModule");
        TypeBuilder typeBuilder = moduleBuilder.DefineType("DynamicType");
        typeBuilder.AddInterfaceImplementation(typeof(IMockInterface));
        Console.WriteLine($"Type : {typeBuilder.FullName} is created with the implementation of IMockInterface.\n");

        foreach (var method in typeof(IMockInterface).GetMethods())
        {
            var parameterArguments = method.GetParameters().Select(i => i.ParameterType);

            MethodBuilder methodBuilder = typeBuilder.DefineMethod(method.Name, MethodAttributes.Public | MethodAttributes.Virtual, method.ReturnType, parameterArguments.ToArray());
            ILGenerator ilGenerator = methodBuilder.GetILGenerator();

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
