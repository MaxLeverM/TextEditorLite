using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows;
using FastColoredTextBoxNS;

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

           // mainTextBox.Language = FastColoredTextBoxNS.Language.XML;
            mainTextBox.AutoIndent = true;
        }

        private void LoadBtn_Click(object sender, RoutedEventArgs e)
        {
            LoadWindow loadWindow = new LoadWindow();
            loadWindow.Owner = this;
            if (loadWindow.ShowDialog() == true)
            {
                textFile = loadWindow.filesListBox.SelectedItem as TextFile;
                mainTextBox.Text = textFile.Value;
                textIsModified = false;
            }
        }

        private void NewBtn_Click(object sender, RoutedEventArgs e)
        {
           /* if (!textIsModified)
            {*/
                textIsModified = false;
                textFile = null;
                mainTextBox.Clear();
           /* }
            else
            {

            }*/
        }

        private void MainTextBox_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (!textIsModified)
            {
                textIsModified = true;
            }
        }

        FastColoredTextBoxNS.Style GreenStyle = new FastColoredTextBoxNS.TextStyle(Brushes.Green, null, System.Drawing.FontStyle.Italic);
        private void MainTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            e.ChangedRange.ClearStyle(GreenStyle);
            e.ChangedRange.SetStyle(GreenStyle, @"//.*$", RegexOptions.Multiline);
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
