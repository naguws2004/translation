from deepl_translator import deepl_translator

# Replace 'YOUR_AUTH_KEY' with your actual DeepL API key
auth_key = 'd825783b-cab2-4713-bf05-dbb1f3dc74b9:fx'

def test_connection():
    try:
        result = deepl_translator.translate_text(auth_key, "Hello, world!", source_lang="en", target_lang="es")
        print(result.text)
        print("Connection successful!")
    except Exception as e:
        print(f"Connection failed: {str(e)}")

if __name__ == "__main__":
    test_connection()
