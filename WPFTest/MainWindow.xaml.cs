using DotNetTranslator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AvailableTranslations t = Lang.Initialize();

        public MainWindow()
        {
            t.SelectedTranslationChanged += T_SelectedTranslationChanged;
            InitializeComponent();
            this.UpdateTranslation(t);
        }

        private void T_SelectedTranslationChanged(AvailableTranslations TranslationSource)
            => this.UpdateTranslation(TranslationSource);

        private void BtnEnglish_Click(object sender, RoutedEventArgs e)
            => t.SelectedTranslation = t.GetTranslation("English");

        private void BtnRussian_Click(object sender, RoutedEventArgs e)
            => t.SelectedTranslation = t.GetTranslation("Russian");
    }
}
