using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
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
        public AdditionWindow(MainWindow w)
        {
            wndw = w;
            InitializeComponent();
        }
        List<Courses> courses;

        private void addCrs_Click(object sender, RoutedEventArgs e)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream filest = new FileStream("../../courses.dat", FileMode.OpenOrCreate))
            {
                try
                {
                    courses = (List<Courses>)formatter.Deserialize(filest);
                }
                catch
                {
                    courses = new List<Courses>();
                }
            }

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
            using (FileStream filest = new FileStream("../../courses.dat", FileMode.Open))
            {
                formatter = new BinaryFormatter();
                formatter.Serialize(filest, courses);
            }
            Logger.Log("Добавлен новый курс");
        }
    }
}

