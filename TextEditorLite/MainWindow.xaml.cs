using System.Data.Entity;
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
        ApplicationContext db;
        public TextFile textFile { get; set; }
        private bool textIsModified = false;

        public MainWindow()
        {
            InitializeComponent();

            db = new ApplicationContext();
            DBhandler.LoadFromDB(db);

            // mainTextBox.Language = FastColoredTextBoxNS.Language.XML;
            mainTextBox.AutoIndent = true;
        }

        private void LoadBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!textIsModified)
            {
                CreateLoadWindow();
            }
            else
            {
                if (askSaveFile())
                {
                    SaveBtn_Click(this, new RoutedEventArgs());
                }
                else
                {
                    CreateLoadWindow();
                }
            }
        }
        private void CreateLoadWindow()
        {
            LoadWindow loadWindow = new LoadWindow(db);
            loadWindow.Owner = this;
            if (loadWindow.ShowDialog() == true)
            {
                textFile = loadWindow.filesListBox.SelectedItem as TextFile;
                mainTextBox.Text = ZipHandler.Unzip(textFile.Value);
                textIsModified = false;
            }
        }

        private void NewBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!textIsModified)
            {
                VarToDefault();
            }
            else
            {
                if (askSaveFile())
                {
                    SaveBtn_Click(this, new RoutedEventArgs());
                }
                else
                {
                    VarToDefault();
                }
            }
        }

        private bool askSaveFile()
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("Сохранить файл?", "Внимание", MessageBoxButton.YesNo);
            bool result = false;
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                result = true;
            }
            else if (messageBoxResult == MessageBoxResult.No)
            {
                result = false;
            }
            return result;
        }

        private void VarToDefault()
        {
            textIsModified = false;
            textFile = null;
            mainTextBox.Clear();
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
            if (textFile == null)
            {
                textFile = new TextFile { Value = ZipHandler.Zip(mainTextBox.Text) };
            }
            else
            {
                textFile.Value = ZipHandler.Zip(mainTextBox.Text);
            }
            SaveWindow saveWindow = new SaveWindow(db, textFile);
            saveWindow.Owner = this;
            if (saveWindow.ShowDialog() == true)
            {
                textIsModified = false;
            }
        }
    }
}
