using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Markup;

namespace TextEditorLite
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public TextFile textFile { get; set; }
        private bool textIsModified = false;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoadBtn_Click(object sender, RoutedEventArgs e)
        {
            LoadWindow loadWindow = new LoadWindow();
            loadWindow.Owner = this;
            if (loadWindow.ShowDialog() == true)
            {
                textFile = loadWindow.filesListBox.SelectedItem as TextFile;
                mainTextBox.SetText(textFile.Value);
                textIsModified = false;
            }
        }

        private void MainTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            textIsModified = true;
        }

        private void NewBtn_Click(object sender, RoutedEventArgs e)
        {
           /* if (!textIsModified)
            {*/
                textIsModified = false;
                textFile = null;
                mainTextBox.Document.Blocks.Clear();
           /* }
            else
            {

            }*/
        }
    }

    public static class ExtRichTextBox
    {
        public static void SetText(this RichTextBox richTextBox, string text)
        {
            richTextBox.Document.Blocks.Clear();
            richTextBox.Document.Blocks.Add(new Paragraph(new Run(text)));
        }

        public static string GetText(this RichTextBox richTextBox)
        {
            return new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd).Text;
        }
    }
}
