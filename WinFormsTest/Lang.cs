using DotNetTranslator;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace WinFormsTest
{
    class Lang
    {
        static Dictionary<string, string> English = new Dictionary<string, string>()
        {
            { "linkEnglish", "English" },
            { "linkRussian", "Russian" },
            { "groupBoxFirstCtrlText", "1st user control inside" },
            { "groupBoxInside1stCtrl", "2nd user control inside" },
            { "labelControl2", "this is label of 2nd control" },
        };
        
        static Dictionary<string, string> Russian = new Dictionary<string, string>()
        {  { "linkEnglish", "Английский" },
            { "linkRussian", "Русский" },
            { "groupBoxFirstCtrlText", "1ый юзер контрол внутри" },
            { "groupBoxInside1stCtrl", "2ой юзер контрол внутри" },
            { "labelControl2", "это лейбл второго контрола" },
        };
        
        public static AvailableTranslations Initialize()
        {
            AvailableTranslations Translation = new AvailableTranslations();

            Translation.Translations.Add(new DotNetTranslator.Translation("English", "en-US", English, "English"));
            Translation.Translations.Add(new DotNetTranslator.Translation("Russian", "ru-RU", Russian, "Русский"));

            var system = Translation.GetTranslation(CultureInfo.InstalledUICulture.DisplayName);
            if (system != null) Translation.SelectedTranslation = system;

            return Translation;
        }
    }
}
