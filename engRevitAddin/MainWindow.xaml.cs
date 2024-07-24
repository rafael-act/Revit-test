using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.ComponentModel;
using System.Windows;

namespace engRevitAddin
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IDataErrorInfo, INotifyPropertyChanged
    {
        public UIDocument uidoc { get; }
        public Document doc { get; }

        private string _parameterName;
        public string ParameterName
        {
            get { return _parameterName; }
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("Must to have a value");
                }

                _parameterName = value;
                OnPropertyChanged("ParameterName");
            }
        }
        private string _parameterValue;

      

        public string ParameterValue
        {
            get { return _parameterValue; }
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("Must to have a value");
                }

                _parameterValue = value;
                OnPropertyChanged("ParameterValue");
            }
        }

        public string Error
        {
            get
            {
                return string.Empty;
            }
        }

        public string this[string columnName]
        {
            get
            {
                string result = String.Empty;
                if (columnName == "ParameterName")
                {
                    if (ParameterName.Length > 0)
                    {
                        result = "Must to have a value";
                    }
                }

                if (columnName == "ParameterValue")
                {
                    if (ParameterValue.Length > 0)
                    {
                        result = "Must to have a value";
                    }
                }

                return result;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        public MainWindow(UIDocument uIDocument)
        {
            this.DataContext = this;
            uidoc = uIDocument;
            doc = uIDocument.Document;
            InitializeComponent();
        }

        private void IsolateCommand(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtParameterName.Text))
            {
                throw new ArgumentException("Name Must to have a value");
            }
        }

        private void SelectCommand(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtParameterValue.Text))
            {
                throw new ArgumentException("Parameter Value Must to have a value");
            }
        }
    }
}
