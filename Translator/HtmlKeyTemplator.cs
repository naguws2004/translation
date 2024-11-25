using HtmlAgilityPack;

namespace CustomTranslator
{
    public class HtmlKeyTemplator
    {
        public static void ReplaceTextWithKeysInHtmlFiles(string folderPath)
        {
            var htmlFiles = Directory.GetFiles(folderPath, "*.html", SearchOption.AllDirectories);

            foreach (var htmlFile in htmlFiles)
            {
                var htmlDoc = new HtmlDocument();
                htmlDoc.Load(htmlFile);
                ReplaceTextWithKeys(htmlDoc.DocumentNode);
                htmlDoc.Save(htmlFile);
                Console.WriteLine($"Text replaced with keys in {htmlFile}.");
            }
        }

        private static void ReplaceTextWithKeys(HtmlNode node)
        {
            // extract visible text from the HTML document
            if (node.NodeType == HtmlNodeType.Text && !string.IsNullOrWhiteSpace(node.InnerText))
            {
                var formattedText = Common.FormatText(node.InnerText);
                if (!string.IsNullOrEmpty(formattedText))
                {
                    var key = Common.GetKeyFromText(formattedText);
                    node.InnerHtml = "@@" + key;
                }
            }

            foreach (var child in node.ChildNodes)
            {
                ReplaceTextWithKeys(child);
            }
        }
    }
}
