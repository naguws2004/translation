from bs4 import BeautifulSoup
import os
import json
import Common as Common

def replace_keys_with_text(folder_path, json_file_path):
  """Replaces keys with text in HTML files using a JSON key-value mapping."""
  for root, _, files in os.walk(folder_path):
    for filename in files:
      if filename.endswith(".html"):
        file_path = os.path.join(root, filename)

        # Read JSON data
        with open(json_file_path, 'r', encoding='utf-8') as f:
          key_value_pairs = json.load(f)

        # Parse HTML file
        with open(file_path, 'r', encoding='utf-8') as f:
          soup = BeautifulSoup(f, 'html.parser')

        replace_keys_with_text_helper(soup, key_value_pairs)

        # Save modified HTML
        with open(file_path, 'w', encoding='utf-8') as f:
          f.write(str(soup))  # Convert BeautifulSoup object to string
          print(f"Text replaced with keys in {file_path}.")

def replace_keys_with_text_helper(soup, key_value_pairs):
  """Replaces keys in a BeautifulSoup object with corresponding values from a dictionary."""
  for node in soup.find_all(text=True, recursive=True):
    key = Common.Common.get_key_from_html(node.string.strip())  # Assuming get_key_from_html is defined
    if key and key in key_value_pairs:
      node.replace_with(key_value_pairs[key])

