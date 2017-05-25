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
    /// Логика взаимодействия для AddStudentsPage.xaml
    /// </summary>
    public partial class AddStudentsPage : Page
    {
        List<Students> studentsnew = new List<Students>();
        // List<Students> students;

        public AddStudentsPage()
        {
            InitializeComponent();
        }

        int mark;
        string _yesButton;

        private void addSt_Click(object sender, RoutedEventArgs e)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream filest = new FileStream("../../students1.dat", FileMode.OpenOrCreate))
            {
                try
                {
                    studentsnew = (List<Students>)formatter.Deserialize(filest);
                }
                catch
                {
                    studentsnew = new List<Students>();
                }
            }
            int.TryParse(newMark.Text, out mark);

            if (YesButton.IsChecked == true)
            {
                _yesButton = "ДА";
            }
            else if (NoButton.IsChecked == true)
            {
                _yesButton = "НЕТ";
            }


            if (string.IsNullOrWhiteSpace(newSecondName.Text))
            {
                MessageBox.Show("Введите фамилию учащегося!", "ERROR");
                newSecondName.Focus();
                return;

            }

            if (string.IsNullOrWhiteSpace(newFirstName.Text))
            {
                MessageBox.Show("Введите имя учащегося!", "ERROR");
                newFirstName.Focus();
                return;

            }

            if (!int.TryParse(newMark.Text, out mark))
            {
                MessageBox.Show("Введите оценку учащегося!", "ERROR");
                newMark.Focus();
                return;
            }

            if (YesButton.IsChecked == false & NoButton.IsChecked == false)
            {

                MessageBox.Show("Выберите один из вариантов ответа!", "ERROR");
                return;
            }



            Students st = new Students(newFirstName.Text, newSecondName.Text, mark, _yesButton);

            //  List<Students> students = new List<Students>();
            studentsnew.Add(st);




            Logger.Log("Добавлен новый студент");
            NavigationService.Navigate(Pages.MainPage);

            using (FileStream filest = new FileStream("../../students1.dat", FileMode.Open))
            {
                formatter = new BinaryFormatter();
                formatter.Serialize(filest, studentsnew);
            }


        }
        private void NewMark_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

            if (!char.IsDigit(e.Text, e.Text.Length - 1))
            {
                e.Handled = true;
                MessageBox.Show("Введите оценку в целочисленном виде!", "WARNING");
            }
        }

        private void NewSecondName_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsLetter(e.Text, e.Text.Length - 1))
            {
                e.Handled = true;
                MessageBox.Show("Введите фамилию учащегося!", "WARNING");
            }
        }

        private void NewFirstName_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsLetter(e.Text, e.Text.Length - 1))
            {
                e.Handled = true;
                MessageBox.Show("Введите имя учащегося!", "WARNING");
            }
        }
    }
}




