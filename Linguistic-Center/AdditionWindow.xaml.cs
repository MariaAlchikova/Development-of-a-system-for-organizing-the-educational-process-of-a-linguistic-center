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

namespace Linguistic_Center
{
    /// <summary>
    /// Логика взаимодействия для AdditionWindow.xaml
    /// </summary>
    public partial class AdditionWindow : Window
    {
        
   
            MainWindow wndw;
            public AdditionWindow (MainWindow w)
            {
                wndw = w;
                InitializeComponent();
            }

            private void addCrs_Click(object sender, RoutedEventArgs e)
            {
                try
                {
                    Courses crs = new Courses(newLanguage.Text, newLevel.Text, newGroup.Text, newMetro.Text, newID.Text);
                    wndw._courses.Add(crs);
                    wndw.coursesList.Items.Add(crs);
                //wndw.NewCourseFile();
                MessageBox.Show("Курс добавлен!");
                }
                catch
                {
                    MessageBox.Show("Данные введены неверно!");
                }
                this.Close();
            }
    }
    }

