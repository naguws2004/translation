using HtmlAgilityPack;

namespace CustomTranslator
{
    public class HtmlKeyReplacer
    {
        public static void ReplaceKeysWithTextInHtmlFiles(string folderPath, string translationFilePath)
        {
            var htmlFiles = Directory.GetFiles(folderPath, "*.html", SearchOption.AllDirectories);

            Dictionary<string, string> keyValuePairs = Common.GetKeyValuesFromFile(translationFilePath);

            foreach (var htmlFile in htmlFiles)
            {
                var htmlDoc = new HtmlDocument();
                htmlDoc.Load(htmlFile);
                if (keyValuePairs != null && keyValuePairs.Count > 0) ReplaceKeysWithText(htmlDoc.DocumentNode, keyValuePairs);
                htmlDoc.Save(htmlFile);
                Console.WriteLine($"Text replaced with keys in {htmlFile}.");
            }
        }

        private static void ReplaceKeysWithText(HtmlNode node, Dictionary<string, string> keyValuePairs)
        {
            // extract visible text from the HTML document
            if (node.NodeType == HtmlNodeType.Text && !string.IsNullOrWhiteSpace(node.InnerText))
            {
                var key = Common.GetKeyFromHtml(node.InnerText);
                if (!string.IsNullOrEmpty(key))
                {
                    var value = Common.GetValueFromKey(keyValuePairs, key);
                    if (value != null) node.InnerHtml = value;
                }
            }

            foreach (var child in node.ChildNodes)
            {
                ReplaceKeysWithText(child, keyValuePairs);
            }
        }
    }
}
