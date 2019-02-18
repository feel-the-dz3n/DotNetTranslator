using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DotNetTranslator.NativeTest
{
    class Program
    {
        public const string FileName = "translations.xml";

        static Dictionary<string, string> DefaultTranslationEN = new Dictionary<string, string>()
        {
            { "ElementOne", "This is English value for element №1!" },
            { "TextBoxPassword", "This is English value for element \"TextBoxPassword\"!" },
            { "TestElement", "I like this TestElement!" }
        };

        static Dictionary<string, string> DefaultTranslationRU = new Dictionary<string, string>()
        {
            { "ElementOne", "Это русское значение для элемента №1!" },
            { "TextBoxPassword", "Это русское значение для элемента \"TextBoxPassword\"!" },
            { "TestElement", "Мне нравится этот TestElement!" }
        };

        static void Main(string[] args)
        {
            //string locale = "en-US";

            Console.WriteLine("NativeTest for DotNetTranslator");

            //if(args.Length <= 0)
            //{
            //    Console.WriteLine("No arguments - selected locale: en-US");
            //}
            //else
            //{
            //    locale = args[0];
            //    Console.WriteLine("Selected locale: " + locale);
            //}

            if (!File.Exists(FileName))
            {
                Console.WriteLine(FileName + " is not found - creating default translation file");
                AvailableTranslations def = new AvailableTranslations();
                def.Translations.Add(new Translation("English", "en-US", DefaultTranslationEN));
                def.Translations.Add(new Translation("Russian", "ru-RU", DefaultTranslationRU));

                using (StreamWriter writer = new StreamWriter(FileName))
                {
                    writer.Write(def.ConvertToXML());
                }
            }

            AvailableTranslations Translator = AvailableTranslations.DeserializeFromFile(FileName);

            Console.WriteLine(FileName + " is loaded");

            Console.WriteLine();
            Console.WriteLine($"Default Translation: {Translator.DefaultTranslation.Language} ({Translator.DefaultTranslation.Locale})");
            Console.WriteLine($"Selected Translation: {Translator.SelectedTranslation.Language} ({Translator.DefaultTranslation.Locale})");

            for (int i = 0; i < Translator.Translations.Count; i++)
            {
                var translation = Translator.Translations[i];

                Console.WriteLine();
                Console.WriteLine($"[{i}] {translation.Language} ({translation.Locale}) - {translation.Elements.Count} elements");

                for (int e = 0; e < translation.Elements.Count; e++)
                {
                    var element = translation.Elements[e];

                    Console.WriteLine($"      [{e}] {element.Name}: {element.Value}");
                }
            }

            Console.WriteLine();
            Console.WriteLine("Done");
            Console.ReadKey();
        }
    }
}
