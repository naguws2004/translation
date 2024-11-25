using Esprima;
using Esprima.Ast;
using System.Text;

namespace CustomTranslator
{
    public class JavaScriptKeyTemplator
    {
        public static void ReplaceTextWithKeysInJsFiles(string folderPath)
        {
            var jsFiles = Directory.GetFiles(folderPath, "*.js", SearchOption.AllDirectories);

            foreach (var jsFile in jsFiles)
            {
                string jsContent = File.ReadAllText(jsFile);
                jsContent = ReplaceTextWithKeys(jsContent);
                File.WriteAllText(jsFile, jsContent);
                Console.WriteLine($"Text replaced with keys in {jsFile}.");
            }
        }

        private static string ReplaceTextWithKeys(string jsContent)
        {
            var stringBuilder = new StringBuilder(jsContent);

            var parser = new JavaScriptParser();
            var program = parser.ParseScript(jsContent);

            ReplaceStringLiterals(program, stringBuilder);

            return stringBuilder.ToString();
        }

        private static void ReplaceStringLiterals(Node node, StringBuilder stringBuilder)
        {
            string text = string.Empty;
            if (node is Literal literal && literal.TokenType == TokenType.StringLiteral)
            {
                text = literal.StringValue;
            }
            else if (node is TemplateLiteral templateLiteral)
            {
                foreach (var quasi in templateLiteral.Quasis)
                {
                    text = quasi.Value.Cooked;
                }
            }

            var formattedText = Common.FormatText(text);
            if (!string.IsNullOrEmpty(formattedText))
            {
                var key = Common.GetKeyFromText(formattedText);
                stringBuilder.Replace(text, "@@" + key);
            }

            foreach (var child in node.ChildNodes)
            {
                ReplaceStringLiterals(child, stringBuilder);
            }
        }
    }
}
