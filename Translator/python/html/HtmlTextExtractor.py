import os
import json
import Common as Common
from bs4 import BeautifulSoup

def extract_text_from_html_files(folder_path):
    html_files = [os.path.join(root, file) for root, _, files in os.walk(folder_path) for file in files if file.endswith('.html')]
    destination_file = os.path.join(os.path.dirname(os.path.abspath(__file__)), "translations_en.json")
    output_data = {}

    for html_file in html_files:
        print(f"Extracting text from {html_file}")
        with open(html_file, 'r', encoding='utf-8') as f:
            soup = BeautifulSoup(f, 'html.parser')

        for text in soup.stripped_strings:
            formatted_text = Common.Common.format_text(text)  # Assuming format_text is defined
            key = Common.Common.get_key_from_text(formatted_text)  # Assuming get_key_from_text is defined
            if key not in output_data:
                output_data[key] = formatted_text

    with open(destination_file, 'w', encoding='utf-8') as f:
        json.dump(output_data, f, indent=4)

