using HtmlAgilityPack;
using System.Text;

namespace CustomTranslator
{
    public class HtmlTextExtractor
    {
        private static readonly HashSet<string> keyStore = [];

        public static void ExtractTextFromHtmlFiles(string folderPath)
        {
            var htmlFiles = Directory.GetFiles(folderPath, "*.html", SearchOption.AllDirectories);
            var destinationPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            var destinationFile = Path.Combine(destinationPath!, "translations_en.txt");
            var stringBuilder = new StringBuilder();

            foreach (var htmlFile in htmlFiles)
            {
                stringBuilder.AppendLine("/* " + htmlFile + " */");
                stringBuilder.Append(ExtractTextFromHtml(htmlFile));
                stringBuilder.AppendLine(" ");
                Console.WriteLine($"Text from {htmlFile} extracted.");
            }
            stringBuilder.Remove(stringBuilder.Length - 4, 1);
            File.WriteAllText(destinationFile, stringBuilder.ToString());
        }

        private static string ExtractTextFromHtml(string htmlFilePath)
        {
            var stringBuilder = new StringBuilder();

            var htmlDoc = new HtmlDocument();
            htmlDoc.Load(htmlFilePath);

            var lines = ExtractTextFromDoc(htmlDoc);
            int lineCount = 0;
            foreach (var text in lines)
            {
                var formattedText = Common.FormatText(text);
                if (!string.IsNullOrEmpty(formattedText))
                {
                    var key = Common.GetKeyFromText(formattedText);
                    if (!keyStore.Contains(key))
                    {
                        keyStore.Add(key);
                        stringBuilder.Append(key);
                        stringBuilder.Append("=");
                        stringBuilder.Append(formattedText);
                        stringBuilder.AppendLine(" ");
                        lineCount++;
                    }
                }
            }

            return stringBuilder.ToString();
        }

        private static List<string> ExtractTextFromDoc(HtmlDocument doc)
        {
            // extract visible text from the HTML document
            return doc.DocumentNode
                .Descendants()
                .Where(node => node.NodeType == HtmlNodeType.Text && !string.IsNullOrWhiteSpace(node.InnerText))
                .Select(node => HtmlEntity.DeEntitize(node.InnerText.Trim()))
                .ToList();
        }
    }
}
