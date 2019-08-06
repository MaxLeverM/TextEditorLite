using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TextEditorLite
{
    /// <summary>
    /// Interaction logic for LoadWindow.xaml
    /// </summary>
    public partial class LoadWindow : Window
    {
        ApplicationContext db;
        public LoadWindow(ApplicationContext db)
        {
            InitializeComponent();

            this.db = db;
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

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if (filesListBox.SelectedItem != null)
            {
                db.TextFiles.Remove(filesListBox.SelectedItem as TextFile);
                db.SaveChanges();
            }
        }
    }
}
