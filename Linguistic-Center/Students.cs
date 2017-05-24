using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linguistic_Center
{

    [Serializable]
    class Students
    {
        private string _secondName;
        private string _firstName;
        private string _monthlyPayment;
        private int _mark;




        public string SecondName
        {
            get
            {
                return _secondName;
            }
            set
            {
                _secondName = value;
            }
        }

        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
            }
        }

        public int Mark
        {
            get
            {
                return _mark;
            }
            set
            {
                _mark = value;
            }
        }

        public string MonthlyPayment
        {
            get
            {
                return _monthlyPayment;
            }
            set
            {
                _monthlyPayment = value;
            }
        }
        public Students(string fName, string sName, int mark, string pay)
        {
            SecondName = sName;
            FirstName = fName;
            MonthlyPayment = pay;
            Mark = mark;
        }
    }
}
