using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;

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
    }
}
