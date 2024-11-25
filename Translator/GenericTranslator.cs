using DeepL;
using System.Text;

namespace CustomTranslator;
public class GenericTranslator
{
    private readonly Translator translator;

    public GenericTranslator()
    {
        // Initialize translator
        translator = new Translator("380c8d16-91c0-460e-8d68-cb19a189ea00:fx");
    }

    public async Task TranslateFile(string sourceFile, string sourceLang, string targetLang)
    {
        StringBuilder sb = new();

        // Load Key file with Source language text
        foreach (string line in File.ReadLines(sourceFile))
        {
            // Process the line as needed
            if (line.Trim().Length > 0)
            {
                var convertedLine = await Translate(line, sourceLang, targetLang);
                sb.AppendLine(convertedLine);
                continue;
            }
            sb.AppendLine(line);
        }

        var destinationFile = sourceFile + ".converted";

        // Save the translated text to destination file
        File.WriteAllText(destinationFile, sb.ToString());
    }

    private async Task<string> Translate(string sourceText, string sourceLang, string targetLang)
    {
        // Translate value to target language
        var result = await translator.TranslateTextAsync(sourceText, sourceLang, targetLang);
        return result.Text;
    }
}