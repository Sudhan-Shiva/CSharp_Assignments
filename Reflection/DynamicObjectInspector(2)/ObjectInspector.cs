using System.Reflection;
using Pastel;
using ConsoleTables;

namespace DynamicObjectInspector
{
    internal class ObjectInspector
    {
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

        public void SetPropertyValue(object obj, string propertyName, object newValue)
        {
            Type objectType = obj.GetType();
            PropertyInfo? property = objectType.GetProperty(propertyName);
            property?.SetValue(obj, newValue);
        }
    }
}
