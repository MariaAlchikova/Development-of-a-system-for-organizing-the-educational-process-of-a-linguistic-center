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
using System.Windows.Shapes;
using System.IO;

namespace Linguistic_Center
{
    /// <summary>
    /// Логика взаимодействия для ChangeWindow.xaml
    /// </summary>
    public partial class ChangeWindow : Window
    {
        private List<Courses> courses = new List<Courses>();
        private Courses receivedObj;

        MainWindow window;
        public ChangeWindow(MainWindow win, Courses obj)
        {
            receivedObj = obj;
            window = win;
            InitializeComponent();
        }


        private void SaveChanges_Click(object sender, RoutedEventArgs e)
        {
            
                    
            Courses crsNew = new Courses(otherLanguage.Text, otherLevel.Text, otherGroup.Text, otherMetro.Text, otherID.Text);
            window._courses.Remove(receivedObj);
            window._courses.Add(crsNew);
            window.coursesList.Items.Remove(receivedObj);
            window.coursesList.Items.Add(crsNew);
            //window.coursesList.ItemsSource = null;
            //window.coursesList.ItemsSource = window._courses;
            MessageBox.Show("Курс изменён!");


            this.Close();
        }

        
    }
    }

