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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Courses> courses;

        public List<Courses> _courses
        {
            get { return courses; }
            set { courses = value; }
        }
        public MainWindow()
        {
            InitializeComponent();
            dg.ItemsSource = null;
            LoadData();
        }


        private void AddCourses_Click(object sender, RoutedEventArgs e)
        {

            AdditionWindow add = new AdditionWindow();
            add.Show();
            this.Close();
            LoadData();
        }

        private void ChangeCourses_Click(object sender, RoutedEventArgs e)
        {
            bool idFound = false;
            foreach (Courses crs in courses)
            {
                if (crs.ID == IDforSearch.Text)
                {
                    idFound = true;
                    ChangeWindow window = new ChangeWindow(this, crs);
                    window.ShowDialog();
                    break;
                }
            }
            if (!idFound)
            {
                MessageBox.Show("Курс не найден");
            }
            idFound = false;
            SaveData();
        }

        private void SearchCourses_Click(object sender, RoutedEventArgs e)
        {
            foreach (Courses crs in courses)
            {
                if (crs.ID == searchID.Text)
                {
                    coursesInfo.Text = crs.Language + " " + crs.Level + " " + crs.Group + " " + crs.Metro + " " + crs.ID;
                    break;
                }
                else
                    coursesInfo.Text = "Указанного курса не существует";
                Logger.Log("Осуществлён поиск элемента списка");
            }
        }

        private void DeleteCourses_Click(object sender, RoutedEventArgs e)
        {
            foreach (var row in dg.SelectedItems)
            {
                Courses cs = row as Courses;
                _courses.Remove(cs);
            }
            dg.ItemsSource = null;
            dg.Columns.Clear();
            dg.ItemsSource = _courses;
            SaveData();
        }

        private void SaveListToFileWithName_Click(object sender, RoutedEventArgs e)
        {
            using (FileStream fs = new FileStream(@"../../newcourses.txt", FileMode.Create, FileAccess.Write))
            {

                StreamWriter sr = new StreamWriter(fs, Encoding.Default);

                foreach (Courses crs in courses)
                {
                    sr.Write(crs.Language + " " + crs.Level + " " + crs.Group + " " + crs.Metro + " " + crs.ID);
                    sr.WriteLine();
                }

                sr.Close();
                fs.Close();
            }
            coursesInfo.Text = "Данные сохранены в файл newcourses.txt";
        }

        private void SaveData()
        {
            using (FileStream filest = new FileStream("../../courses1.dat", FileMode.Open))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(filest, courses);
                Logger.Log("Сохранение данных в файл");
            }
        }

        private void LoadData()
        {
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                using (FileStream filest = new FileStream("../../courses1.dat", FileMode.OpenOrCreate))
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
                Logger.Log("Считывание данных из файла");
            }
            catch
            {
                MessageBox.Show("Ошибка чтения из файла");
            }

            dg.ItemsSource = courses;

        }
    }
}
