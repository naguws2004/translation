﻿from PropertiesTranslator2 import PropertiesTranslator2 

# Replace 'YOUR_AUTH_KEY' with your actual DeepL API key
auth_key = 'd825783b-cab2-4713-bf05-dbb1f3dc74b9:fx'

# Main block to execute the method
if __name__ == "__main__":
    source_file = "C:\\Users\\yerkala_n\\source\\repos\\Translator\\Translator\\python\\translate\\messages.properties"
    PropertiesTranslator2.translate_properties_file(auth_key, source_file, "en", "es")

    print("Completed Translation")  
    
