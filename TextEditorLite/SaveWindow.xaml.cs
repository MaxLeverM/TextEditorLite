﻿using System;
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
using System.Windows.Shapes;

namespace TextEditorLite
{
    /// <summary>
    /// Interaction logic for SaveWindow.xaml
    /// </summary>
    public partial class SaveWindow : Window
    {
        ApplicationContext db;
        TextFile textFile;
        public SaveWindow(ApplicationContext db, TextFile textFile)
        {
            InitializeComponent();
            this.db = db;
            this.textFile = textFile;
            nameTextBox.Text = textFile?.Name ?? "NewFile";
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            textFile.Name = nameTextBox.Text;
            TextFile tempTextFile = db.TextFiles.Find(textFile.ID);

            if (tempTextFile != null)
            {
                db.Entry(textFile).State = System.Data.Entity.EntityState.Modified;
            }
            else
            {
                textFile.DateCreate = DateTime.Now.ToLongDateString();
                db.TextFiles.Add(textFile);
            }

            DBhandler.SaveToDB(db);
            DialogResult = true;
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
