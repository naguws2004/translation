import HtmlTextExtractor as HtmlTextExtractor
import JsonTranslator as JsonTranslator
import HtmlKeyTemplator as HtmlKeyTemplator
import HtmlKeyReplacer as HtmlKeyReplacer

# Main block to execute the method
if __name__ == "__main__":
    html_dir = "C:\\Users\\yerkala_n\\source\\repos\\Translator\\Translator\\python\\html\\templates"
    HtmlTextExtractor.extract_text_from_html_files(html_dir)

    print("Completed HTML Text Extraction")

    # Replace with your actual authentication key
    auth_key = "380c8d16-91c0-460e-8d68-cb19a189ea00:fx"
    translator = JsonTranslator.JsonTranslator(auth_key)

    source_file = "C:\\Users\\yerkala_n\\source\\repos\\Translator\\Translator\\python\\html\\translation\\translations_en.txt"
    translator.translate_json_file(source_file)

    print("Completed JSON Translation")  

    html_dir = "C:\\Users\\yerkala_n\\source\\repos\\Translator\\Translator\\python\\html\\templates"
    HtmlKeyTemplator.replace_text_with_keys(html_dir)

    print("Completed HTML Key Templating")

    html_dir = "C:\\Users\\yerkala_n\\source\\repos\\Translator\\Translator\\templatespython\\html\\"
    translations_file = "C:\\Users\\yerkala_n\\source\\repos\\Translator\\Translator\\python\\html\\translation\\translations_es.txt"

    HtmlKeyReplacer.replace_keys_with_text(html_dir, translations_file)

    print("Completed HTML Key Replacement")

    print("Completed All Tasks")

# End of Program.py