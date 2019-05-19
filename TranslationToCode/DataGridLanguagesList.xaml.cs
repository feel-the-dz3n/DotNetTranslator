using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TranslationToCode
{
    /// <summary>
    /// Interaction logic for DataGridLanguagesList.xaml
    /// </summary>
    public partial class DataGridLanguagesList : Window
    {
        public DataGrid dataGrid;

        public DataGridLanguagesList()
        {
            InitializeComponent();
            InitCopyFrom();
        }

        public DataGridLanguagesList(DataGrid TheDataGrid)
        {
            InitializeComponent();
            InitCopyFrom();

            dataGrid = TheDataGrid;

            LoadGridColumns();
        }

        private void LoadGridColumns()
        {
            lbLanguages.Items.Clear();

            foreach (var column in dataGrid.Columns.Where(x => x.Header is LanguageInfo))
            {
                var l = (LanguageInfo)column.Header;
                lbLanguages.Items.Add(
                    new ListBoxItem()
                    {
                        Tag = l,
                        Content = l
                    });
            }

            lbLanguages.SelectedItem = null;
        }

        private void InitCopyFrom()
        {
            foreach(var cult in CultureInfo.GetCultures(CultureTypes.AllCultures))
            {
                var c = new LanguageInfo(cult);
                cbCOpyFrom.Items.Add(
                    new ComboBoxItem()
                    {
                        Tag = c,
                        Content = c
                    });
            }
        }

        private void LbLanguages_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(lbLanguages.SelectedItem == null)
            {
                tbSelectedLanguage.Text = "Select or Add Language";
                panelEditor.IsEnabled = false;
            }
            else
            {
                panelEditor.IsEnabled = true;
                var l = (LanguageInfo)((ListBoxItem)lbLanguages.SelectedItem).Tag;
                tbSelectedLanguage.Text = l.ToString();
                tbLanguage.Text = l.Name;
                tbLocale.Text = l.Locale;
                tbLocalName.Text = l.LocalName;
            }
        }

        private void CbCOpyFrom_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbCOpyFrom.SelectedItem == null) return;

            var l = (LanguageInfo)((ComboBoxItem)cbCOpyFrom.SelectedItem).Tag;

            var item = lbLanguages.SelectedItem as ListBoxItem;

            item.Tag = l;

            LbLanguages_SelectionChanged(null, null);

            cbCOpyFrom.SelectedItem = null;
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e) => this.Close();

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            dataGrid.Columns.Add(new DataGridTextColumn() { Header = new LanguageInfo() });
            LoadGridColumns();
            lbLanguages.SelectedItem = lbLanguages.Items[lbLanguages.Items.Count - 1];
        }

        private void BtnRemove_Click(object sender, RoutedEventArgs e)
        {
            var item = lbLanguages.SelectedItem as ListBoxItem;

            if (item != null)
            {
                dataGrid.Columns.Remove(
                    dataGrid.Columns.First(
                        x => x.Header is LanguageInfo &&
                        ((LanguageInfo)x.Header) == item.Tag
                        )
                        );

                LoadGridColumns();
            }
        }

        private void TbLanguage_TextChanged(object sender, TextChangedEventArgs e)
        {
            var l = (LanguageInfo)((ListBoxItem)lbLanguages.SelectedItem).Tag;
            l.Name = tbLanguage.Text;
            tbSelectedLanguage.Text = l.ToString();
        }

        private void TbLocale_TextChanged(object sender, TextChangedEventArgs e)
        {
            var l = (LanguageInfo)((ListBoxItem)lbLanguages.SelectedItem).Tag;
            l.Locale = tbLocale.Text;
            tbSelectedLanguage.Text = l.ToString();
        }

        private void TbLocalName_TextChanged(object sender, TextChangedEventArgs e)
        {
            var l = (LanguageInfo)((ListBoxItem)lbLanguages.SelectedItem).Tag;
            l.LocalName = tbLocalName.Text;
            tbSelectedLanguage.Text = l.ToString();
        }
    }
}
