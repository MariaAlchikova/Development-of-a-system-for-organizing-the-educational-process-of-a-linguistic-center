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
    public partial class AdditionPage : Page
    {

        List<Courses> coursesnew;
        
        public AdditionPage()
        {

            InitializeComponent();
        }


        private void addCrs_Click(object sender, RoutedEventArgs e)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream filest = new FileStream("../../courses1.dat", FileMode.OpenOrCreate))
            {
                try
                {
                    coursesnew = (List<Courses>)formatter.Deserialize(filest);
                }
                catch
                {
                    coursesnew = new List<Courses>();
                }
            }

            Courses crs = new Courses(newLanguage.Text, newLevel.Text, newGroup.Text, newMetro.Text, newID.Text);

            coursesnew.Add(crs);

            if (string.IsNullOrWhiteSpace(newLanguage.Text))
            {
                MessageBox.Show("Введите язык!", "ERROR");
                newLanguage.Focus();
                return;

            }

            //for (int i = 0; i < coursesnew.Count; i++)
            //{
            //    if (coursesnew[i].ID.ToLower() == newID.Text.ToLower())

            //    {
            //        MessageBox.Show("Курс с таким ID уже существует!", "ERROR");
            //        return;
            //    }
            //}

            if (string.IsNullOrWhiteSpace(newLevel.Text))
            {
                MessageBox.Show("Введите уровень владения языком!", "ERROR");
                newLevel.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(newGroup.Text))
            {
                MessageBox.Show("Введите язык!", "ERROR");
                newGroup.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(newMetro.Text))
            {
                MessageBox.Show("Введите название станции метро, на которой проводится курс!", "ERROR");
                newMetro.Focus();
                return;
            }


            if (string.IsNullOrWhiteSpace(newID.Text))
            {
                MessageBox.Show("Введите ID курса!", "ERROR");
                newID.Focus();
                return;
            }

            using (FileStream filest = new FileStream("../../courses1.dat", FileMode.Open))
            {
                formatter = new BinaryFormatter();
                formatter.Serialize(filest, coursesnew);
            }
            Logger.Log("Добавлен новый курс");
            NavigationService.Navigate(Pages.MainPage);
        }



        private void Language_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsLetter(e.Text, e.Text.Length - 1))
            {
                e.Handled = true;
                MessageBox.Show("Введите язык корректно!", "WARNING");
            }
        }

        private void Group_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsLetter(e.Text, e.Text.Length - 1))
            {
                e.Handled = true;
                MessageBox.Show("Введите название группы корректно!", "WARNING");
            }
        }

        private void Metro_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsLetter(e.Text, e.Text.Length - 1))
            {
                e.Handled = true;
                MessageBox.Show("Введите название станции метро корректно!", "WARNING");
            }
        }
    }
}

