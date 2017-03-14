using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace language_center
{
    class Groups
    {
        private string _language;
        private string _level;
        private int _age;
        private string _metro;



        public string Language
        {
            get
            {
                return _language;
            }
            set
            {
                _language = value;
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
                _level = value;
            }
        }

        public int Age
        {
            get

            {
                return _age;
            }
            set
            {
                _age = value;
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
                _metro = value;
            }
        }


        public Groups(string lng, string lvl, int age, string met)
        {

            Language = lng;
            Level = lvl;
            Age = age;
            Metro = met;
        }
    }
}