using Esprima;
using Esprima.Ast;
using System.Text;

namespace CustomTranslator;
public class JavaScriptTextExtractor
{
    private static readonly HashSet<string> keyStore = [];

    public static void ExtractTextFromJsFiles(string folderPath)
    {
        var jsFiles = Directory.GetFiles(folderPath, "*.js", SearchOption.AllDirectories);
        var destinationPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        var destinationFile = Path.Combine(destinationPath!, "translations_en.txt");
        var stringBuilder = new StringBuilder();

        foreach (var jsFile in jsFiles)
        {
            stringBuilder.AppendLine("/* " + jsFile + " */");
            stringBuilder.Append(ExtractTextFromJsFile(jsFile));
            stringBuilder.AppendLine(" ");
            Console.WriteLine($"Text from {jsFile} extracted.");
        }
        stringBuilder.Remove(stringBuilder.Length - 4, 1);
        File.WriteAllText(destinationFile, stringBuilder.ToString());
    }

    private static string ExtractTextFromJsFile(string jsFilePath)
    {
        var stringBuilder = new StringBuilder();

        string jsContent = File.ReadAllText(jsFilePath);
        var parser = new JavaScriptParser();
        var program = parser.ParseScript(jsContent);

        var stringLiterals = new List<string>();
        ExtractStringLiterals(program, stringLiterals);

        return string.Join(Environment.NewLine, stringLiterals);
    }

    private static void ExtractStringLiterals(Node node, List<string> stringLiterals)
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
            if (!keyStore.Contains(key))
            {
                keyStore.Add(key);
                stringLiterals.Add(key + "=" + formattedText);
            }
        }

        foreach (var child in node.ChildNodes)
        {
            ExtractStringLiterals(child, stringLiterals);
        }
    }
}


