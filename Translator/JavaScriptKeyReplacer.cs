using Esprima;
using Esprima.Ast;
using System.Text;

namespace CustomTranslator
{
    public class JavaScriptKeyReplacer
    {
        public static void ReplaceKeysWithTextInJsFiles(string folderPath, string translationFilePath)
        {
            var jsFiles = Directory.GetFiles(folderPath, "*.js", SearchOption.AllDirectories);
            Dictionary<string, string> keyValuePairs = Common.GetKeyValuesFromFile(translationFilePath);

            foreach (var jsFile in jsFiles)
            {
                string jsContent = File.ReadAllText(jsFile);
                if (keyValuePairs != null && keyValuePairs.Count > 0) jsContent = ReplaceKeysWithText(jsContent, keyValuePairs);
                File.WriteAllText(jsFile, jsContent);
                Console.WriteLine($"Text replaced with keys in {jsFile}.");
            }
        }

        private static string ReplaceKeysWithText(string jsContent, Dictionary<string, string> keyValuePairs)
        {
            var stringBuilder = new StringBuilder(jsContent);

            var parser = new JavaScriptParser();
            var program = parser.ParseScript(jsContent);

            ReplaceStringLiterals(program, stringBuilder, keyValuePairs);

            return stringBuilder.ToString();
        }

        private static void ReplaceStringLiterals(Node node, StringBuilder stringBuilder, Dictionary<string, string> keyValuePairs)
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

            if (!string.IsNullOrEmpty(text) && text.Trim().StartsWith("@@"))
            {
                var value = Common.GetValueFromKey(keyValuePairs, text.Trim().Remove(0, 2));
                stringBuilder.Replace(text, value);
            }

            foreach (var child in node.ChildNodes)
            {
                ReplaceStringLiterals(child, stringBuilder, keyValuePairs);
            }
        }
    }
}
