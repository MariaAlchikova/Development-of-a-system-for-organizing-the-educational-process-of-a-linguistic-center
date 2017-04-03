using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linguistic_Center
{
    class Students
    {
        private string _secondName;
        private string _firstName;
        private string _monthlyPayment; // "yes" if a student paid for courses, "no" if he did not paid
        private float _mark;




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

        public float Mark
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
        public Students(string fName, string sName, float mark, string pay)
        {
            SecondName = sName;
            FirstName = fName;
            MonthlyPayment = pay;
            Mark = mark;
        }

        
    }
}
