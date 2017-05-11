using System;
using System.Collections.Generic;
using System.IO;
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


namespace Linguistic_Center
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Courses> courses = new List<Courses>();

        //internal List<Courses> Courses { get => courses; set => courses = value; }  // инкапсуляция поля

        public MainWindow()
        {
            InitializeComponent();
        
      
            using (FileStream fs = new FileStream(@"../../courses.txt", FileMode.Open, FileAccess.Read))
            {
                string[] data;
                Courses crs;
                StreamReader sr = new StreamReader(fs, Encoding.Default);

                while (!sr.EndOfStream)
                {
                    data = sr.ReadLine().Split(' ');
                    crs = new Courses(data[0], data[1], data[2], data[3]);
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
                    sr.Write(crs.Language + " " + crs.Level + " " + crs.Age + " " + crs.Metro);
                    sr.WriteLine();
                }

                sr.Close();
                fs.Close();
            }

        }


        //private void AddCourses_Click(object sender, RoutedEventArgs e)
        //{
        //    AddCoursesWindow wnd = new AddCoursesWindow(this);
        //    wnd.Show();
        //}

        //private void SearchCourses_Click(object sender, RoutedEventArgs e)
        //{
        //    foreach (Courses crs in courses)
        //    {
        //        if (crs.Language == searchLanguage.Text)
        //        {
        //            coursesInfo.Text = crs.Language + " " + crs.Level + " " + crs.Age + " " + crs.Metro;
        //            break;
        //        }
        //        else
        //            coursesInfo.Text = "Указанного курса не существует";
        //    }
        //}

        private void DeleteCourses_Click(object sender, RoutedEventArgs e)
        {
            Object crs = coursesList.SelectedItem;
            coursesList.Items.Remove(crs);
            courses.Remove((Courses)crs);
            NewCourses();
        }

        private void SaveListToFileWithName_Click(object sender, RoutedEventArgs e)
        {
            using (FileStream fs = new FileStream(@"../../newcourses.txt", FileMode.Create, FileAccess.Write))
            {

                StreamWriter sr = new StreamWriter(fs, Encoding.Default);

                foreach (Courses crs in courses)
                {
                    sr.Write(crs.Language + " " + crs.Level + " " + crs.Age + " " + crs.Metro);
                    sr.WriteLine();
                }

                sr.Close();
                fs.Close();
            }
            coursesInfo.Text = "Данные сохранены в файл newcourses.txt";
        }
    }

}
