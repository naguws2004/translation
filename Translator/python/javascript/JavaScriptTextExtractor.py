import ast
import os
from Common import Common

class JavaScriptTextExtractor:
    def extract_text_from_js_files(folder_path):
        js_files = [os.path.join(root, file) for root, _, files in os.walk(folder_path) for file in files if file.endswith('.js')]
        output_file = os.path.join(os.path.dirname(__file__), "translations_en.txt")
        with open(output_file, 'w') as f:
            for js_file in js_files:
                print(f"Extracting text from {js_file}")
                text = JavaScriptTextExtractor.extract_text_from_js_file(js_file)
                f.write(f"/* {js_file} */\n{text}\n\n")

    def extract_text_from_js_file(js_file_path):
        with open(js_file_path, 'r', encoding='utf-8') as f:
            js_code = f.read()

        js_code = js_code.replace('\u00A1', '')
        tree = ast.parse(js_code)
        string_literals = []
        JavaScriptTextExtractor.extract_string_literals(tree, string_literals)

        return '\n'.join(string_literals)

    def extract_string_literals(node, string_literals):
        if isinstance(node, ast.Str):
            formatted_text = Common.format_text(node.s)  # Implement format_text and get_key_from_text
            key = Common.get_key_from_text(formatted_text)
            if key not in string_literals:
                string_literals.append(f"{key}={formatted_text}")
        elif isinstance(node, ast.JoinedStr):
            for s in node.values:
                JavaScriptTextExtractor.extract_string_literals(s, string_literals)
        else:
            for child in ast.iter_child_nodes(node):
                JavaScriptTextExtractor.extract_string_literals(child, string_literals)