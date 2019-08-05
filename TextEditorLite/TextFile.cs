using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TextEditorLite
{
    public class TextFile : INotifyPropertyChanged
    {
        private string name;
        private string dateCreate;
        private string valueText;

        public int ID { get; set; }

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        public string DateCreate
        {
            get { return dateCreate; }
            set
            {
                dateCreate = value;
                OnPropertyChanged("DateCreate");
            }
        }

        public string Value
        {
            get { return valueText; }
            set
            {
                valueText = value;
                OnPropertyChanged("Value");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
