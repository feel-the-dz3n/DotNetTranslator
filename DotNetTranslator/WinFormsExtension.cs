/* 
   PROJECT:     DotNetTranslator
   LICENSE:     (See it on GitHub page)
   FILE:        WinFormsExtensions.cs
   DESCRIPTION: Provides automated extensions for Windows Forms
   PROGRAMMERS: Yaroslav Kibysh (2018 - 2019)
   GITHUB:      https://github.com/feel-the-dz3n/DotNetTranslator
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DotNetTranslator
{
    public static class WinFormsExtension
    {
        /// <summary>
        /// Updates translation for all controls on Form
        /// </summary>
        public static void UpdateTranslation(this Form form, AvailableTranslations translation)
            => UpdateTranslation(form, translation.SelectedTranslation);

        /// <summary>
        /// Updates translation for all controls on Form
        /// </summary>
        public static void UpdateTranslation(this Form form, Translation translation)
        {
            for (int i = 0; i < form.Controls.Count; i++)
            {
                var control = form.Controls[i];
                control.UpdateTranslation(translation);
            }
        }

        /// <summary>
        /// Updates translation for one control or all controls for panels
        /// </summary>
        public static void UpdateTranslation(this Control control, AvailableTranslations translation)
            => UpdateTranslation(control, translation.SelectedTranslation);

        /// <summary>
        /// Updates translation for one control or all controls for panels
        /// </summary>
        public static void UpdateTranslation(this Control control, Translation translation)
        {
            if(control is Panel)
            {
                var panel = control as Panel;

                for (int i = 0; i < panel.Controls.Count; i++)
                {
                    var ctrl = panel.Controls[i];
                    ctrl.UpdateTranslation(translation);
                }

                return;
            }

            var value = translation.Get(control.Name);

            if (value != null)
                control.Text = value;
        }

        /// <summary>
        /// Updates translation for all controls on user control
        /// </summary>
        public static void UpdateTranslation(this UserControl control, AvailableTranslations translation)
            => UpdateTranslation(control, translation.SelectedTranslation);

        /// <summary>
        /// Updates translation for all controls on user control
        /// </summary>
        public static void UpdateTranslation(this UserControl control, Translation translation)
        {
            for (int i = 0; i < control.Controls.Count; i++)
            {
                var ctrl = control.Controls[i];
                ctrl.UpdateTranslation(translation);
            }
        }
    }
}
