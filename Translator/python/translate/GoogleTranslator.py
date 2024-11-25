from pathlib import Path
from google_translator import google_translator

class GoogleTranslator:
    def translate_properties_file(source_file, source_lang="en", target_lang="es"):
        output_file = f"{source_file}_{target_lang}"
        with open(source_file, 'r') as f_in, open(output_file, 'w') as f_out:
            for line in f_in:
                key, *values = line.strip().split('=')
                translated_values = []
                for value in values:
                    print(value)
                    result = google_translator.translate_text(value, target_lang, source_lang)
                    translated_values.append(result)
                    print(result)
                    print("\n")
                f_out.write(f"{key}={'='.join(translated_values)}\n")

