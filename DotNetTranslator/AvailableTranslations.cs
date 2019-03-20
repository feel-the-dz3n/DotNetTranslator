using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace DotNetTranslator
{
    [Serializable]
    public class AvailableTranslations
    {
        public delegate void LanguageChangedHandler(AvailableTranslations TranslationSource);
        /// <summary>
        /// Triggers when SELECTED translation changed.
        /// </summary>
        public event LanguageChangedHandler SelectedTranslationChanged;
        /// <summary>
        /// Triggers when DEFAULT translation changed.
        /// </summary>
        public event LanguageChangedHandler DefaultTranslationChanged;

        /// <summary>
        /// List of translations
        /// </summary>
        public List<Translation> Translations = new List<Translation>();

        /// <summary>
        /// Default locale
        /// </summary>
        public string DefaultLocale = "en-US";

        /// <summary>
        /// Selected locale. null for default.
        /// </summary>
        public string SelectedLocale = null;

        /// <summary>
        /// Get Translation from SelectedLocale or set new SelectedLocale from translation
        /// </summary>
        public Translation SelectedTranslation
        {
            get
            {
                if (SelectedLocale == null)
                    return GetTranslation(DefaultLocale);
                else
                    return GetTranslation(SelectedLocale);
            }
            set
            {
                SelectedLocale = value.Locale;
                SelectedTranslationChanged?.Invoke(this);
            }
        }

        /// <summary>
        /// Gets or sets default translation
        /// </summary>
        public Translation DefaultTranslation
        {
            get => GetTranslation(DefaultLocale);
            set
            {
                DefaultLocale = value.Locale;
                DefaultTranslationChanged?.Invoke(this);
            }
        }

        /// <summary>
        /// Contains a list of translations
        /// </summary>
        public AvailableTranslations() { }

        /// <summary>
        /// Returns translation by Language or Locale from AvailableTranslations
        /// </summary>
        /// <param name="LanguageOrLocale"></param>
        /// <param name="CaseSensetive"></param>
        /// <returns>DefaultTranslation if not found</returns>
        public Translation GetTranslation(string LanguageOrLocale, bool CaseSensetive = false)
        {
            for(int i = 0; i < Translations.Count; i++)
            {
                var translation = Translations[i];
                if((!CaseSensetive && translation.Locale.ToLower() == LanguageOrLocale.ToLower()) ||
                    (!CaseSensetive && translation.Language.ToLower() == LanguageOrLocale.ToLower()) ||
                    (CaseSensetive && translation.Locale == LanguageOrLocale) ||
                    (CaseSensetive && translation.Language == LanguageOrLocale))
                {
                    return translation;
                }
            }

            return null;
        }

        /// <summary>
        /// Serialize content to XML-text
        /// </summary>
        /// <returns>XML</returns>
        public string ConvertToXML()
        {
            XmlSerializer s = new XmlSerializer(typeof(AvailableTranslations));

            using (var stream = new System.IO.StringWriter())
            {
                s.Serialize(stream, this);

                return stream.ToString();
            }
        }

        /// <summary>
        /// Deserialize from XML string
        /// </summary>
        /// <param name="xml"></param>
        public static AvailableTranslations Deserialize(string xml)
        {
            XmlSerializer s = new XmlSerializer(typeof(AvailableTranslations));

            using (var stream = new System.IO.StringReader(xml))
            {
                return (AvailableTranslations)s.Deserialize(stream);
            }
        }

        public static AvailableTranslations DeserializeFromFile(string filename)
        {
            XmlSerializer s = new XmlSerializer(typeof(AvailableTranslations));

            using (StreamReader fs = new StreamReader(filename, true))
            {
                return (AvailableTranslations)s.Deserialize(fs);
            }
        }
    }
}
