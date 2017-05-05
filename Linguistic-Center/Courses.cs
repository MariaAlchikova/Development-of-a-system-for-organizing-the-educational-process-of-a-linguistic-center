using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linguistic_Center
{
    class Courses
    {
        private string _language;
        private string _level;
        private string _age;
        private string _metro;



        public string Language
        {
            get
            {
                return _language;
            }
            set
            {
                if (!String.IsNullOrWhiteSpace(value))
                    _language = value;
                else throw new Exception();
            }
        }

        public string Level
        {
            get

            {
                return _level;
            }
            set
            {
                if (!String.IsNullOrWhiteSpace(value))
                    _level = value;
                else throw new Exception();
            }
        }

        public string Age
        {
            get

            {
                return _age;
            }
            set
            {
                if (!String.IsNullOrWhiteSpace(value))
                    _age = value;
                else throw new Exception();
            }
        }

        public string Metro
        {
            get

            {
                return _metro;
            }
            set
            {
                if (!String.IsNullOrWhiteSpace(value))
                    _metro = value;
                else throw new Exception();
            }
        }


        public Courses (string lng, string lvl, string age, string met)
        {

            Language = lng;
            Level = lvl;
            Age = age;
            Metro = met;
        }
    }
}