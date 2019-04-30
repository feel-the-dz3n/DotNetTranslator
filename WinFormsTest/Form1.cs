using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DotNetTranslator;

namespace WinFormsTest
{
    public partial class Form1 : Form
    {
        AvailableTranslations t = Lang.Initialize();

        public Form1()
        {
            t.SelectedTranslationChanged += T_SelectedTranslationChanged;
            InitializeComponent();
            groupBoxFirstCtrlText.Controls.Add(new UserControl1());
            this.UpdateTranslation(t);
        }

        private void T_SelectedTranslationChanged(AvailableTranslations TranslationSource)
        {
            this.UpdateTranslation(TranslationSource);
        }

        private void linkEnglish_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            t.SelectedTranslation = t.GetTranslation("English");
        }

        private void linkRussian_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            t.SelectedTranslation = t.GetTranslation("Russian");
        }
    }
}
