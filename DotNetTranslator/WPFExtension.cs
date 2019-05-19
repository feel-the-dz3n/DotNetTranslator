/* 
   PROJECT:     DotNetTranslator
   LICENSE:     (See it on GitHub page)
   FILE:        WPFExtension.cs
   DESCRIPTION: Provides automated extensions for WPF
   PROGRAMMERS: Yaroslav Kibysh (2018 - 2019)
   GITHUB:      https://github.com/feel-the-dz3n/DotNetTranslator
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using System.Windows.Markup;

namespace DotNetTranslator
{
    public static class WPFExtension
    {
        private static string[] PropertiesToTranslate =
        {
            "Header", "Text", "Content"
        };

        public static void UpdateTranslation(this object element, AvailableTranslations translation)
        {
            if (element == null) return;

            if(element is ContentControl) // Window/UserControl
            {
                var ctrl = element as ContentControl;
                UpdateTranslation(ctrl.Content, translation);
            }
            else if (element is TextBlock)
            {
                var ctrl = element as TextBlock;
                
                var list = new List<object>();

                for (int i = 0; i < ctrl.Inlines.Count; i++)
                    list.Add(ctrl.Inlines.ElementAt(i));

                foreach (var control in list)
                    UpdateTranslation(control, translation);

                if(list.Count >= 1)
                    return; // do not continue editing for TextBlock if there are inlines (hack)
            }
            else if (element is Panel) // Grid/Panels
            {
                var ctrl = element as Panel;

                var list = new List<object>();

                for (int i = 0; i < ctrl.Children.Count; i++)
                    list.Add(ctrl.Children[i]);

                foreach (var control in list)
                    UpdateTranslation(control, translation);
            }
            else if (element is ItemsControl) // ListBox
            {
                var ctrl = element as ItemsControl;

                var list = new List<object>();

                for (int i = 0; i < ctrl.Items.Count; i++)
                    list.Add(ctrl.Items[i]);

                foreach (var control in list)
                    UpdateTranslation(control, translation);
            }

            var namep = element.GetType().GetProperty("Name");

            if (namep != null)
            {
                var name = namep.GetValue(element, null) as string;

                if (string.IsNullOrWhiteSpace(name))
                {
                    namep = element.GetType().GetProperty("Tag");
                    if (namep != null)
                        name = namep.GetValue(element, null) as string;
                }

                if (!string.IsNullOrWhiteSpace(name))
                {
                    name = name.Trim(new char[] { '_' });

                    var t = translation.Get(name);

                    if (t != null)
                    {
                        foreach (var tx in PropertiesToTranslate)
                        {
                            var property = element.GetType().GetProperty(tx);
                            if (property != null)
                            {
                                property.SetValue(element, t, null);
                                break;
                            }
                        }
                    }
                }
            }
        }
    }
}
