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
        private List<Courses> courses = new List<Courses>();

        public List<Courses> _courses
        {
            get { return courses; }
            set { courses = value; }
        }
        public MainWindow()
        {
            InitializeComponent();
            LoadData();

            using (FileStream fs = new FileStream(@"../../courses.txt", FileMode.Open, FileAccess.Read))
            {
                string[] data;
                Courses crs;
                StreamReader sr = new StreamReader(fs, Encoding.Default);

                while (!sr.EndOfStream)
                {
                    data = sr.ReadLine().Split(' ');
                    crs = new Courses(data[0], data[1], data[2], data[3], data[4]);
                    courses.Add(crs);
                }

                sr.Close();
                fs.Close();
            }

            NewCourses();

            foreach (Courses crs in courses)
                coursesList.Items.Add(crs);



        }


        public void NewCourses()
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

        }


        private void AddCourses_Click(object sender, RoutedEventArgs e)
        {
            AdditionWindow wndw = new AdditionWindow(this);
            wndw.Show();
            SaveData();
            //using (FileStream fs = new FileStream("data.xml", FileMode.Create))
            //{
            //    Courses course1 = new Courses("German", "C1", "adult", "Третьяковская", "abc123");
            //    Courses course2 = new Courses("English", "B1", "children", "Университет", "abcd123");
            //    courses.Add(course1);
            //    courses.Add(course2);
            //    XmlSerializer xml = new XmlSerializer(typeof(List<Courses>));
            //    xml.Serialize(fs, courses);
            //}
            //Logger.Log("Добавлен новый курс");
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
                //else
                //    MessageBox.Show("Курс не найден");
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
            }
        }

        private void DeleteCourses_Click(object sender, RoutedEventArgs e)
        {
            Object crs = coursesList.SelectedItem;
            coursesList.Items.Remove(crs);
            courses.Remove((Courses)crs);
            NewCourses();
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
            using (FileStream filest = new FileStream("../../courses.dat", FileMode.Open))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(filest, courses);
            }
        }

        private void LoadData()
        {
            try
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
            }
            catch
            {
                MessageBox.Show("Ошибка чтения из файла");
            }

        }
    }
}
