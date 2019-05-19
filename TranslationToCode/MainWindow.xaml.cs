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

namespace TranslationToCode
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnLanguages_Click(object sender, RoutedEventArgs e)
        {
            new DataGridLanguagesList(dataGrid).ShowDialog();
        }

        private void BtnCodeViewer_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnOpen_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnNew_Click(object sender, RoutedEventArgs e)
        {
            var columns = dataGrid.Columns.Where(x => x.Header.GetType().Name != typeof(string).Name);

            foreach (var column in columns)
                dataGrid.Columns.Remove(column);

            dataGrid.Items.Clear();
        }
    }
}
