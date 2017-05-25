using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Linguistic_Center
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        List<Courses> courses;

        public List<Courses> _courses
        {
            get { return courses; }
            set { courses = value; }
        }

        public MainPage()
        {
            InitializeComponent();
            dg.ItemsSource = null;
            dgStudents.ItemsSource = null;
            LoadData();
            LoadData1();
        }

        private void SearchCourses_Click(object sender, RoutedEventArgs e)
        {
            foreach (Courses crs in courses)
            {
                if (crs.ID == searchID.Text)
                {
                    coursesInfo.Text = crs.Language + " - " + crs.Level + " - " + crs.Group + " - " + crs.Metro + " - " + crs.ID;
                    break;
                }
                else
                    coursesInfo.Text = "Указанного курса не существует";
                Logger.Log("Осуществлён поиск элемента списка");
            }
        }

        private void AddCourses_Click(object sender, RoutedEventArgs e)
        {

            LoadData();
            NavigationService.Navigate(Pages.AdditionPage);
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
        //Students

        List<Students> students;

        private List<Students> _students
        {
            get
            {
                return students;
            }
            set
            {
                students = value;
            }
        }


        private void AddStudents_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(Pages.AddStudentsPage);
            LoadData1();
        }

        private void SearchStudents_Click(object sender, RoutedEventArgs e)
        {
            foreach (Students st in students)
            {
                if (st.SecondName == searchName.Text)
                {
                    studentsInfo.Text = st.FirstName + " - " + st.SecondName + " - " + st.Mark + " - " + st.MonthlyPayment;
                    break;
                }
                else
                    coursesInfo.Text = "Студент не найден";
                Logger.Log("Осуществлён поиск элемента списка");
            }
        }

        private void DeleteStudents_Click(object sender, RoutedEventArgs e)
        {
            foreach (var row in dgStudents.SelectedItems)
            {
                Students st = row as Students;
                _students.Remove(st);
            }
            dgStudents.ItemsSource = null;
            dgStudents.Columns.Clear();
            dgStudents.ItemsSource = students;
            SaveData1();
        }

        private void SaveData1()
        {
            using (FileStream filest = new FileStream("../../students1.dat", FileMode.Open))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(filest, courses);
                Logger.Log("Сохранение данных в файл");
            }
        }

        private void LoadData1()
        {
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                using (FileStream filest = new FileStream("../../students1.dat", FileMode.OpenOrCreate))
                {
                    try
                    {
                        students = (List<Students>)formatter.Deserialize(filest);
                    }
                    catch
                    {
                        students = new List<Students>();
                    }
                }
                Logger.Log("Считывание данных из файла");
            }
            catch
            {
                MessageBox.Show("Ошибка чтения из файла");
            }

            dgStudents.ItemsSource = students;
        }
    }
}