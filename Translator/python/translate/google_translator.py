from google.cloud import translate_v2 as translate

class google_translator:
     def translate_text(text, target_language_code, source_language_code):
        """Translates text into the target language.

        Args:
            text: The text to translate.
            target_language_code: The ISO 639-1 code of the target language.
            source_language_code: The ISO 639-1 code of the source language.

        Returns:
            The translated text.
        """

        client = translate.Client()
        result = client.translate(text, target_language=target_language_code, source_language=source_language_code)
        return result['translatedText']




