using System.Reflection;
using Pastel;
using ConsoleTables;

namespace DynamicObjectInspector
{
    /// <summary>
    /// Class to inspect and modify the properties of an object
    /// </summary>
    internal class ObjectInspector
    {
        /// <summary>
        /// Method to inspect the properties of the object
        /// </summary>
        /// <param name="obj">The object which must be inspected</param>
        public void InspectProperty(object obj)
        {
            Type objectType = obj.GetType();
            Console.WriteLine($"\nType : { objectType.FullName}\n".Pastel(ConsoleColor.Magenta));

            IEnumerable<PropertyInfo> objectProperties = objectType.GetProperties();
            ConsoleTable table = new ConsoleTable("Property", "Value");
           
            if(objectProperties.Count() > 0)
            {
                foreach (PropertyInfo property in objectProperties)
                {
                    string propertyName = property.Name;
                    object? propertyValue = property.GetValue(obj);
                    table.AddRow(propertyName, propertyValue);
                }
                table.Write();
            }
            else
                Console.WriteLine($"No properties found !!!".Pastel(ConsoleColor.Red));    
        }

        /// <summary>
        /// Method to set the properties of the object
        /// </summary>
        /// <param name="obj">The object whose properties is to be set</param>
        /// <param name="propertyName">The property name which is to be set</param>
        /// <param name="newValue">The new value of the property</param>
        public void SetPropertyValue(object obj, string propertyName, object newValue)
        {
            Type objectType = obj.GetType();
            PropertyInfo? property = objectType.GetProperty(propertyName);
            property?.SetValue(obj, newValue);
        }
    }
}
