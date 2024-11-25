from GoogleTranslator import GoogleTranslator 

# Main block to execute the method
if __name__ == "__main__":
    source_file = "C:\\Users\\yerkala_n\\source\\repos\\Translator\\Translator\\python\\translate\\translations\\messages.properties"
    GoogleTranslator.translate_properties_file(source_file, "en", "es")

    print("Completed Translation")  
    
