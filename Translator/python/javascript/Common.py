import re
import json

class Common:
    @staticmethod
    def get_key_from_text(text):
        """
        Processes text to generate a key.

        Args:
            text (str): Text to process.

        Returns:
            str: The generated key in lowercase format.
        """

        text = text.strip()
        text = re.sub(r"\s+", "_", text)  # Replace whitespace with underscores
        text = re.sub(r"[^\w]", "", text)  # Remove non-word characters
        text = text[:24] if len(text) > 24 else text  # Truncate to 24 characters
        return f"tls_key_{text.lower()}"

    @staticmethod
    def get_key_from_html(key):
        """
        Extracts key from HTML text, assuming it starts with "@@tls_key_".

        Args:
            key (str): HTML text.

        Returns:
            str: The extracted key, or an empty string if not found.
        """

        if key.startswith("@@tls_key_"):
            return key[2:]  # Remove "@@tls_key_" prefix
        return ""

    @staticmethod
    def format_text(text):
        """
        Formats text by removing specific patterns.

        Args:
            text (str): Text to format.

        Returns:
            str: The formatted text, or an empty string if no text remains.
        """

        formatted_text = re.sub(r"\s+", " ", text)  # Replace multiple spaces with single space
        formatted_text = re.sub(r"\[\[.*?\]\]", "", formatted_text)  # Remove [[ ]] content
        formatted_text = re.sub(r"{{.*?}}", "", formatted_text)  # Remove {{ }} content
        formatted_text = re.sub(r"@@.*", "", formatted_text)  # Remove text starting with @@
        return formatted_text if any(char.isalpha() for char in formatted_text) else ""

    @staticmethod
    def get_key_from_json_value(jobject, target_value):
        """
        Finds a key in a JSON object whose value matches the target value.

        Args:
            jobject (dict): JSON object to search.
            target_value (str): The target value to match.

        Returns:
            str: The key associated with the target value, or None if not found.
        """

        for key, value in jobject.items():
            if str(value) == target_value:
                return key
        return None

    @staticmethod
    def get_value_from_json_key(jobject, target_key):
        """
        Retrieves the value associated with a specific key in a JSON object.

        Args:
            jobject (dict): JSON object to search.
            target_key (str): The target key to get the value for.

        Returns:
            str: The value associated with the target key, or None if not found.
        """

        if target_key in jobject:
            return str(jobject[target_key])
        return None