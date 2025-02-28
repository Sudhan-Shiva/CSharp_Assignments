using System.Reflection;

namespace DynamicMethodInvoker
{
    public class MethodInvoker
    {
        public void InvokeMethod(object obj, string methodName)
        {
            Type objectType = obj.GetType();
            MethodInfo? method = objectType.GetMethod(methodName);

            if (method != null)
            {
                method.Invoke(obj, null);
                Console.WriteLine($"\nMethod : {method.Name} is successfully invoked from Type : {objectType.FullName}.");
            }
            else
            {
                Console.WriteLine($"Method {methodName} not found !!!");
            }
        }
    }
}
