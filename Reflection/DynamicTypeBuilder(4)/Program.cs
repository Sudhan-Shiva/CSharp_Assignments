using System.Reflection;
using System.Reflection.Emit;

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
        //To build the required assembly, module and type.
        AssemblyBuilder? assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(new AssemblyName("DynamicAssembly"), AssemblyBuilderAccess.Run);
        Console.WriteLine($"Assembly : {assemblyBuilder.FullName?.Split(',').FirstOrDefault()} is created.\n");
        ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule("DynamicModule");
        TypeBuilder typeBuilder = moduleBuilder.DefineType("DynamicType");
        Console.WriteLine($"Type : {typeBuilder.FullName} is created.\n");

        //To build the required method which returns a string.
        MethodBuilder methodBuilder = typeBuilder.DefineMethod("DynamicTestMethod", MethodAttributes.Public, typeof(string), null);
        Console.WriteLine($"Method : {methodBuilder.Name} is created.\n");
        var ilGenerator = methodBuilder.GetILGenerator();
        ilGenerator.Emit(OpCodes.Ldstr, "Method Invoked !!!");
        ilGenerator.Emit(OpCodes.Ret);
        
        //To build the required property and the corresponding field of string type.
        FieldBuilder fieldBuilder = typeBuilder.DefineField("DynamicTestField", typeof(string), FieldAttributes.Public);
        PropertyBuilder? propertyBuilder = typeBuilder.DefineProperty("DynamicTestProperty", PropertyAttributes.HasDefault, typeof(string), Type.EmptyTypes);
        Console.WriteLine($"Property : {propertyBuilder.Name} is created.\n");

        //To define the get method of the dynamic property.
        MethodBuilder getMethodBuilder = typeBuilder.DefineMethod("getDynamicTestProperty", MethodAttributes.Public, typeof(string), Type.EmptyTypes);
        ilGenerator = getMethodBuilder.GetILGenerator();
        ilGenerator.Emit(OpCodes.Ldarg_0);
        ilGenerator.Emit(OpCodes.Ldfld, fieldBuilder);
        ilGenerator.Emit(OpCodes.Ret);

        //To build the set property of the dynamic property.
        MethodBuilder setMethodBuilder = typeBuilder.DefineMethod("setDynamicTestProperty", MethodAttributes.Public, null, new Type[] { typeof(string) });
        ilGenerator = setMethodBuilder.GetILGenerator();
        ilGenerator.Emit(OpCodes.Ldarg_0);
        ilGenerator.Emit(OpCodes.Ldarg_1);
        ilGenerator.Emit(OpCodes.Stfld, fieldBuilder);
        ilGenerator.Emit(OpCodes.Ret);

        //To add the get and set methods to the property.
        propertyBuilder.SetGetMethod(getMethodBuilder);
        propertyBuilder.SetSetMethod(setMethodBuilder);

        //Create an instance of the class.
        var dynamicType = typeBuilder.CreateType();
        object typeInstance = Activator.CreateInstance(dynamicType);

        //Invoke the dynamic method
        var dynamicMethod = dynamicType.GetMethod("DynamicTestMethod");
        var returnString = dynamicMethod?.Invoke(typeInstance, null);
        Console.WriteLine($"{dynamicMethod.Name} returns : {returnString}");
    
        //Invoke the dynamic property
        var dynamicField = dynamicType.GetField("DynamicTestField");
        dynamicField?.SetValue(typeInstance, "Initial String");
        var dynamicProperty = dynamicType.GetProperty("DynamicTestProperty");
        var defaultPropertyValue = dynamicProperty?.GetValue(typeInstance);
        Console.WriteLine($"\nDefault Value of {dynamicProperty.Name}: " + defaultPropertyValue);

        //Change the value of the property
        dynamicProperty?.SetValue(typeInstance,"Modified String");
        var newPropertyValue = dynamicProperty?.GetValue(typeInstance);
        Console.WriteLine($"\n{dynamicProperty.Name} Value after Set : " + newPropertyValue);

        Console.ReadKey();
    }
}