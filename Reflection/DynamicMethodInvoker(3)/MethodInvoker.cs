using System.Reflection;

namespace DynamicMethodInvoker
{
    /// <summary>
    /// Class to invoke methods dynamically
    /// </summary>
    public class MethodInvoker
    {
        /// <summary>
        /// Method to invoke a method dynamically on an object
        /// </summary>
        /// <param name="obj">The object whose methods are to be invoked</param>
        /// <param name="methodName">The method which is to be invoked from the object</param>
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
