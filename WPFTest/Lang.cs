using DotNetTranslator;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace WPFTest
{
    class Lang
    {
        static Dictionary<string, string> English = new Dictionary<string, string>()
        {
            { "TB_GROUP_BOX_MAIN", "Inside of this GroupBox hosted ScrollViewer with StackPanel" },
            { "TB_INSIDE_STACK_PANEL", "The first label in StackPanel" },
            { "TB_INSIDE_CTRL", "This Inline in UserControl says: " },
            { "TB_LANG", "English Selected!" },
            { "LB_ITEM_1", "First ListBox element" },
            { "LB_ITEM_2", "Second ListBox element" },
            { "LB_ITEM_3", "Third ListBox element" },
            { "BTN_ENGLISH", "Set English" },
            { "BTN_RUSSIAN", "Set Russian" }
        };

        static Dictionary<string, string> Russian = new Dictionary<string, string>()
        {
            { "TB_GROUP_BOX_MAIN", "Внутри этого GroupBox есть ScrollViewer с StackPanel" },
            { "TB_INSIDE_STACK_PANEL", "Первый Label внутри StackPanel" },
            { "TB_INSIDE_CTRL", "Этот Inline в UserControl говорит: " },
            { "TB_LANG", "Выбран русский!" },
            { "LB_ITEM_1", "Первый элемент ListBox" },
            { "LB_ITEM_2", "Второй элемент ListBox" },
            { "LB_ITEM_3", "Третий элемент ListBox" },
            { "BTN_ENGLISH", "Установить английский" },
            { "BTN_RUSSIAN", "Установить русский" }
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
