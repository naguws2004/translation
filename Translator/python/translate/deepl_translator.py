import deepl

class deepl_translator:
    def translate_text(auth_key, text, source_lang, target_lang):
        translator = deepl.Translator(auth_key)
        result = translator.translate_text(text, source_lang=source_lang, target_lang=target_lang)
        return result.text

