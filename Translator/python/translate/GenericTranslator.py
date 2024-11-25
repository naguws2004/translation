import deepl
import asyncio
import aiofiles

class GenericTranslator:
    def __init__(self):
        # Initialize translator
        self.translator = deepl.Translator("380c8d16-91c0-460e-8d68-cb19a189ea00:fx")

    def translate(self, text, source_lang, target_lang):
        result = self.translator.translate_text(text, source_lang=source_lang, target_lang=target_lang)
        return result.text

    async def translate_file(self, source_file, source_lang='en', target_lang='es'):
        sb = []

        # Load Key file with Source language text
        async with aiofiles.open(source_file, mode='r', encoding='utf-8') as file:
            async for line in file:
                # Process the line as needed
                entry = line.split('=')
                if len(entry) >= 2:
                    for i in range(1, len(entry)):
                        entry[i] = self.translate(entry[i], source_lang, target_lang)
                    sb.append(f"{entry[0]}")
                    for i in range(1, len(entry)):
                        sb.append(f"={entry[i]}")
                    #sb.append("\n")
                    continue
                sb.append(line)

        # Write the translated content back to the file or another file
        async with aiofiles.open(source_file + ".translated", mode='w', encoding='utf-8') as file:
            await file.writelines(sb)
