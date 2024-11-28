import deepl

class GenericTranslator:
    def __init__(self):
        self.translator = deepl.Translator(auth_key="380c8d16-91c0-460e-8d68-cb19a189ea00:fx")

    def translate_file(self, source_file, source_lang, target_lang):
        lines = []
        with open(source_file, 'r', encoding='utf-8', errors='ignore') as f:
            for line in f:
                line = line.strip()
                if line:
                    translated_line = self.translate(line, source_lang, target_lang)
                    lines.append(translated_line)
                else:
                    lines.append(line)

        destination_file = source_file + ".converted"
        with open(destination_file, 'w') as f:
            f.write('\n'.join(lines))

    def translate(self, source_text, source_lang, target_lang):
        result = self.translator.translate_text(text=source_text,
                                                      source_lang=source_lang,
                                                      target_lang=target_lang)
        return result.text

# Usage example:
if __name__ == "__main__":
    translator = GenericTranslator()
    translator.translate_file("C:\\Users\\yerkala_n\\source\\repos\\translation\\Translator\\python\\translate\\translations\\test.txt", "en", "fr")
