using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;

namespace CustomTranslator
{
    public class Common
    {
        public static string GetKeyFromText(string text)
        {
            text = Regex.Replace(text.Trim(), @"\s+", "_"); // Replace any space character with an underscore
            text = Regex.Replace(text.Trim(), @"[^\w]", ""); // Remove any non-word character 
            if (text.Length > 24) text = text.Substring(0, 24);
            text = "tls_key_" + text;
            return text.ToLowerInvariant();
        }

        public static string GetKeyFromHtml(string key)
        {
            if (key.StartsWith("@@tls_key_"))
            {
                return key.Remove(0, 2); // Remove text starting with @@
            }
            return string.Empty;
        }

        public static string FormatText(string text)
        {
            var formattedText = Regex.Replace(text, @"\s+", " "); // Replace multiple spaces with a single space
            formattedText = Regex.Replace(formattedText, @"\[\[.*?\]\]", ""); // Remove text enclosed between [[ and ]]
            formattedText = Regex.Replace(formattedText, @"{{.*?}}", ""); // Remove text enclosed between [[ and ]]
            formattedText = Regex.Replace(formattedText, @"@@.*", ""); // Remove text starting with @@
            if (formattedText.Any(char.IsLetter))
            {
                return formattedText;
            }
            return string.Empty;
        }

        public static Dictionary<string, string> GetKeyValuesFromFile(string sourceFile)
        {
            Dictionary<string, string> keyValues = new();
            foreach (var line in File.ReadLines(sourceFile))
            {
                // Process the line as needed
                string[] entry = line.Split('=');
                if (entry.Length == 2)
                {
                    keyValues.Add(entry[0], entry[1]);
                    continue;
                }
            }

            return keyValues;
        }

        public static string GetValueFromKey(Dictionary<string, string> keyValuePairs, string key)
        {
            return keyValuePairs.FirstOrDefault(x => x.Key == key).Value;
        }
    }
}