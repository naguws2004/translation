﻿// See https://aka.ms/new-console-template for more information

using CustomTranslator;

Console.WriteLine("Started");
GenericTranslator customTranslator = new();
await customTranslator.TranslateFile("C:\\Users\\yerkala_n\\source\\repos\\Translator\\Translator\\translation\\test.txt", "en", "fr");
Console.WriteLine("Completed");

//Console.WriteLine("Started");
//HtmlTextExtractor.ExtractTextFromHtmlFiles("C:\\Users\\yerkala_n\\source\\repos\\Translator\\Translator\\templates");
//Console.WriteLine("Completed");

//Console.WriteLine("Started");
//HtmlKeyTemplator.ReplaceTextWithKeysInHtmlFiles("C:\\Users\\yerkala_n\\source\\repos\\Translator\\Translator\\templates");
//Console.WriteLine("Completed");

//Console.WriteLine("Started");
//GenericTranslator customTranslator1 = new();
//await customTranslator1.TranslateFile("C:\\Users\\yerkala_n\\source\\repos\\Translator\\Translator\\translation\\translations_en.txt");
//Console.WriteLine("Completed");

////Console.WriteLine("Started");
////HtmlKeyReplacer.ReplaceKeysWithTextInHtmlFiles("C:\\Users\\yerkala_n\\source\\repos\\Translator\\Translator\\templates", "C:\\Users\\yerkala_n\\source\\repos\\Translator\\Translator\\translation\\translations_es.txt");
////Console.WriteLine("Completed");

//Console.WriteLine("Started");
//string jsFilePath = "C:\\Users\\yerkala_n\\source\\repos\\Translator\\Translator\\jsfiles";
//JavaScriptTextExtractor.ExtractTextFromJsFiles(jsFilePath);
//Console.WriteLine("Completed");

//Console.WriteLine("Started");
//JavaScriptKeyTemplator.ReplaceTextWithKeysInJsFiles("C:\\Users\\yerkala_n\\source\\repos\\Translator\\Translator\\jsfiles");
//Console.WriteLine("Completed");

//Console.WriteLine("Started");
//GenericTranslator customTranslator2 = new();
//await customTranslator2.TranslateFile("C:\\Users\\yerkala_n\\source\\repos\\Translator\\Translator\\translation\\translations_en.txt");
//Console.WriteLine("Completed");

////Console.WriteLine("Started");
////JavaScriptKeyReplacer.ReplaceKeysWithTextInJsFiles("C:\\Users\\yerkala_n\\source\\repos\\Translator\\Translator\\jsfiles", "C:\\Users\\yerkala_n\\source\\repos\\Translator\\Translator\\translation\\translations_es.txt");
////Console.WriteLine("Completed");

//Console.WriteLine("Completed");