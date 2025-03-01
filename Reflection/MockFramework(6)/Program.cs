using MockFramework;
using System.Numerics;
using System.Reflection.Emit;
using System.Reflection;

public class Program
{
    static void Main()
    {
        InstanceCreator instanceCreator = new InstanceCreator();
        IMockInterface mockInterface = instanceCreator.CreateDynamicTypeInstance() as IMockInterface;
        Console.ReadKey();
    }
}
