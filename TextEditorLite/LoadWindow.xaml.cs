using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using System.Windows.Shapes;

namespace TextEditorLite
{
    /// <summary>
    /// Interaction logic for LoadWindow.xaml
    /// </summary>
    public partial class LoadWindow : Window
    {
        ApplicationContext db;
        public LoadWindow()
        {
            InitializeComponent();

            db = new ApplicationContext();
            db.TextFiles.Load();
            this.DataContext = db.TextFiles.Local.ToBindingList();
        }

        private void OpenBtn_Click(object sender, RoutedEventArgs e)
        {
            if (filesListBox.SelectedItem != null)
            {
                DialogResult = true;
            }
            else
            {
                MessageBox.Show("Выберите файл для открытия!");
            }
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
