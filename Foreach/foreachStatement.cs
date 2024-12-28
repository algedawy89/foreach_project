using System;
using System.Collections.Generic;

namespace Graammar
{
    public class GrammarStatement
    {
        public string type { get; set; }
        public string ID { get; set; }
        public string Collection { get; set; }
        public bool Statement { get; set; }
        public bool LeftBrac { get; set; }
        public bool RightBrac { get; set; }

        public GrammarStatement()
        {


            //string type, string id, string col, bool statement, bool leftBrac, bool rightBrac
            //this.type = type;
            //this.ID = id;
            //this.Collection = col;
            //this.Statement = statement;
            //this.LeftBrac = leftBrac;
            //this.RightBrac = rightBrac;
        }

        public void Scan()
        {
            if (!Statement)
            {
                Console.WriteLine("Error: Missing statement block.");
            }
            if (!LeftBrac)
            {
                Console.WriteLine("Error: Missing opening brace.");
            }
            if (!RightBrac)
            {
                Console.WriteLine("Error: Missing closing brace.");
            }
            if (string.IsNullOrEmpty(ID))
            {
                Console.WriteLine("Error: Identifier (ID) is null or empty.");
            }

            if (!string.IsNullOrEmpty(Collection) && !string.IsNullOrEmpty(type))
            {
                switch (type)
                {
                    case "int":
                        ParseCollection<int>(Collection);
                        break;
                    case "string":
                        ParseCollection<string>(Collection);
                        break;
                    case "object":
                        ParseCollection<object>(Collection);
                        break;
                    default:
                        Console.WriteLine("Error: Unsupported type.");
                        break;
                }
            }
        }

        private void ParseCollection<T>(string collection)
        {
            try
            {
                var elements = collection.Trim('[', ']').Split(',');

                List<T> parsedElements = new List<T>();
                foreach (var element in elements)
                {
                    if (typeof(T) == typeof(int) && int.TryParse(element, out int intValue))
                    {
                        parsedElements.Add((T)(object)intValue);
                    }
                    else if (typeof(T) == typeof(string))
                    {
                        parsedElements.Add((T)(object)element.Trim());
                    }
                    else if (typeof(T) == typeof(object))
                    {
                        parsedElements.Add((T)(object)element);
                    }
                    else
                    {
                        Console.WriteLine($"Error parsing element: {element}");
                    }
                }

                Console.WriteLine($"Parsed collection of {type}: {string.Join(", ", parsedElements)}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error parsing collection: {ex.Message}");
            }
        }
    }
}
