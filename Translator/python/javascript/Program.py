from JavaScriptTextExtractor import JavaScriptTextExtractor

# Main block to execute the method
if __name__ == "__main__":
    js_file_path = "C:\\Users\\yerkala_n\\source\\repos\\Translator\\Translator\\python\\javascript\\jsfiles"
    JavaScriptTextExtractor.extract_text_from_js_files(js_file_path)
    print(f"Extracted user-visible text.")