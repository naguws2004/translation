from bs4 import BeautifulSoup
import os
import Common as Common

def replace_text_with_keys(folder_path):
    """Replaces visible text with keys in HTML files within the folder."""
    for root, _, files in os.walk(folder_path):
        for filename in files:
            if filename.endswith(".html"):
                file_path = os.path.join(root, filename)
                with open(file_path, 'r', encoding='utf-8') as f:
                    soup = BeautifulSoup(f, 'html.parser')

                replace_text_with_keys_helper(soup)

                with open(file_path, 'w', encoding='utf-8') as f:
                    f.write(str(soup))  # Convert BeautifulSoup object to string    
                print(f"Text replaced with keys in {file_path}.")

def replace_text_with_keys_helper(node):
    """Replaces text with keys recursively within a BeautifulSoup node."""
    if isinstance(node, str):
        return

    if node.name == '#text' and node.string.strip():  # Check for text node with non-whitespace content
        formatted_text = Common.Common.format_text(node.string.strip())  # Assuming format_text is defined
        if formatted_text:
            key = Common.Common.get_key_from_text(formatted_text)  # Assuming get_key_from_text is defined
            node.replace_with(f"@@{key}")  # Replace node with key

    for child in node.children:
        replace_text_with_keys_helper(child)
