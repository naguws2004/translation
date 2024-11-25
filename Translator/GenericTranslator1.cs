using DeepL;
using System.Text;

namespace CustomTranslator;
public class GenericTranslator1
{
    private readonly Translator translator;

    public GenericTranslator1()
    {
        // Initialize translator
        translator = new Translator("380c8d16-91c0-460e-8d68-cb19a189ea00:fx");
    }

    public async Task TranslateFile(string sourceFile, string sourceLang = "en", string targetLang = "es")
    {
        StringBuilder sb = new();

        // Load Key file with Source language text
        foreach (string line in File.ReadLines(sourceFile))
        {
            // Process the line as needed
            string[] entry = line.Split('=');
            if (entry.Length >= 2)
            {
                for (int i = 1; i < entry.Length; i++) entry[i] = await Translate(entry[i], sourceLang, targetLang);
                sb.Append($"{entry[0]}");
                for (int i = 1; i < entry.Length; i++) sb.Append($"={entry[i]}");
                sb.AppendLine("");
                continue;
            }
            sb.AppendLine(line);
        }

        var destinationFile = sourceFile.Replace(sourceLang, targetLang);

        // Save the translated text to destination file
        File.WriteAllText(destinationFile, sb.ToString());
    }

    private async Task<string> Translate(string sourceText, string sourceLang, string targetLang)
    {
        // Translate value to target language
        var result = await translator.TranslateTextAsync(sourceText, sourceLang, targetLang);
        return result.Text;

        //return await Task.FromResult(sourceText);
    }
}