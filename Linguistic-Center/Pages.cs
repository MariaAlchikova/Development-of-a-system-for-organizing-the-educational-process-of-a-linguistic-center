using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linguistic_Center
{
    static class Pages
    {
        private static MainPage _mainPage = new MainPage();
        private static AdditionPage _additionPage = new AdditionPage();
        private static AddStudentsPage _addStudentsPage = new AddStudentsPage();


        public static AdditionPage AdditionPage
        {
            get
            {
                return _additionPage;
            }
        }

        public static MainPage MainPage
        {
            get
            {
                return _mainPage;
            }
        }
        public static AddStudentsPage AddStudentsPage
        {
            get
            {
                return _addStudentsPage;
            }
        }


    }
}
