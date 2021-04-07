using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using System.Windows.Shapes;

namespace Inotifypropertychanged
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }

        ObservableCollection<Person> persons = new ObservableCollection<Person>();


        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Info_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            listBox_Persons.ItemsSource = persons;
        }

        class Person : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;

            string name = string.Empty;
            string surname = string.Empty;
            int id;


            public int Id
            {
                get { return id; }

                set { id = value; }
            }

            public string Name
            {
                get { return name; }

                set
                {
                    if (value != name)
                    {
                        name = value;
                        if (PropertyChanged != null)
                        {
                            PropertyChanged(this, new PropertyChangedEventArgs(nameof(Name)));
                        }
                    }
                }
            }

            public string Surname
            {
                get { return surname; }

                set
                {
                    if (value != surname)
                    {
                        surname = value;
                        if (PropertyChanged != null)
                        {
                            PropertyChanged(this, new PropertyChangedEventArgs(nameof(Surname)));
                        }
                    }
                }
            }

        }



        private void button_Save_Click(object sender, RoutedEventArgs e)
        {
            Person prs1 = new Person();
            prs1.PropertyChanged += Info_PropertyChanged;
            prs1.Name = textBox_Name.Text;
            prs1.Surname = textBox_Surname.Text;

            persons.Add(prs1);

        }
    }
}
