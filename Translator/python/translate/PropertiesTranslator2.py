from pathlib import Path
from deepl_translator import deepl_translator

class PropertiesTranslator2:
    def translate_properties_file(auth_key, source_file, source_lang="en", target_lang="es"):
        output_file = f"{source_file}_{target_lang}"
        with open(source_file, 'r') as f, open(output_file, 'w') as out_f:
            for line in f:
                parts = line.strip().split('=')
                if len(parts) == 2:
                    translated_value = deepl_translator.translate_text(auth_key, parts[1], source_lang, target_lang)
                    out_f.write(f"{parts[0]}={translated_value}\n")
                else:
                    out_f.write(line)


