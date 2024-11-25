import json
import deepl

class JsonTranslator:
    def __init__(self, auth_key):
        self.translator = deepl.Translator(auth_key)

    def translate_json_file(self, source_file, source_lang="en", target_lang="es"):
        with open(source_file, 'r', encoding='utf-8') as f:
            source_text = json.load(f)

        destination_text = {}
        for key, value in source_text.items():
            try:
                translated_value = self.translate(value, source_lang, target_lang)
                destination_text[key] = translated_value
            except Exception as e:
                print(f"Error translating {key}: {str(e)}")
                destination_text[key] = value

        destination_file = source_file.replace(f"_{source_lang}", f"_{target_lang}")
        with open(destination_file, 'w', encoding='utf-8') as f:
            json.dump(destination_text, f, indent=4)

    def translate(self, text, source_lang, target_lang):
        result = self.translator.translate_text(text, source_lang=source_lang, target_lang=target_lang)
        return result.text