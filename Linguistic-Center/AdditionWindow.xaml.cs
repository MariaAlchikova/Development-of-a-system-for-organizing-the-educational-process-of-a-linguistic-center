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

        List<Courses> coursesnew;
        public AdditionWindow()
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

            using (FileStream filest = new FileStream("../../courses1.dat", FileMode.Open))
            {
                formatter = new BinaryFormatter();
                formatter.Serialize(filest, coursesnew);
            }
            Logger.Log("Добавлен новый курс");
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }
    }
}