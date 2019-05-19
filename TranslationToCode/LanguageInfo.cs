using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace TranslationToCode
{
    public class LanguageInfo
    {
        public string Name { get; set; } = "";
        public string Locale { get; set; } = "";
        public string LocalName { get; set; } = "";

        public LanguageInfo() { }

        public LanguageInfo(CultureInfo cult)
        {
            Name = cult.EnglishName;
            Locale = cult.Name;
            LocalName = cult.DisplayName;
        }

        public override string ToString() => $"{Name} ({Locale})";
    }
}
