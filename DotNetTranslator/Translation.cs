/* 
   PROJECT:     DotNetTranslator
   LICENSE:     (See it on GitHub page)
   FILE:        Translation.cs
   DESCRIPTION: Provides access to translation
   PROGRAMMERS: Yaroslav Kibysh (2018 - 2019)
   GITHUB:      https://github.com/feel-the-dz3n/DotNetTranslator
*/
using System;
using System;
using System.Collections.Generic;

namespace DotNetTranslator
{
    [Serializable]
    public class Translation
    {
        public string Language = "English";
        public string Locale = "en-US";

        public List<TranslationElement> Elements = new List<TranslationElement>();

        /// <summary>
        /// Gets value of element
        /// </summary>
        /// <param name="ElementName">Translation Element Name</param>
        /// <returns></returns>
        public string Get(string ElementName)
        {
            for (int i = 0; i < Elements.Count; i++)
                if (Elements[i].Name == ElementName)
                    return Elements[i].Value;

            return null;
        }

        /// <summary>
        /// Translation info 
        /// </summary>
        /// <param name="language">Translation Language</param>
        /// <param name="locale">Language Locale (like 'en-US')</param>
        public Translation(string language, string locale)
        {
            Language = language;
            Locale = locale;
        }
        
        /// <summary>
        /// Create Translation from dictionary
        /// </summary>
        /// <param name="language"></param>
        /// <param name="locale"></param>
        /// <param name="dictionary"></param>
        public Translation(string language, string locale, Dictionary<string, string> dictionary)
        {
            Language = language;
            Locale = locale;

            AddRange(dictionary);
        }

        /// <summary>
        /// Emptry constructor for deserializer. DO NOT USE IT.
        /// </summary>
        public Translation() { }

        /// <summary>
        /// Add translations from dictionary
        /// </summary>
        /// <param name="dictionary"></param>
        public void AddRange(Dictionary<string, string> dictionary)
        {
            foreach(var k in dictionary)
            {
                Elements.Add(new TranslationElement(k.Key, k.Value));
            }
        }
    }
}
