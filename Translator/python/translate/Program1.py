from google_translator import google_translator

# Main block to execute the method
if __name__ == "__main__":
    # Example usage:
    text_to_translate = "Hello, world!"
    target_language = "es"  # French
    source_language = "en"  # English

    translated_text = google_translator.translate_text(text_to_translate, target_language, source_language)
    print(translated_text)  

