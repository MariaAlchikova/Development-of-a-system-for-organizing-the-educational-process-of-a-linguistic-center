using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linguistic_Center
{
    public class Courses
    {
        private string _language;
        private string _level;
        private string _group;
        private string _metro;
        private string _id;



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

        public string Group
        {
            get

            {
                return _group;
            }
            set
            {
                if (!String.IsNullOrWhiteSpace(value))
                    _group = value;
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

        public string ID
        {
            get

            {
                return _id;
            }
            set
            {
                if (!String.IsNullOrWhiteSpace(value))
                    _id = value;
                else throw new Exception();
            }
        }

        public Courses (string lng, string lvl, string grp, string met, string id)
        {

            Language = lng;
            Level = lvl;
            Group = grp;
            Metro = met;
            ID = id;
        }

        public string displayedCourses
        {
            get
            {
                return $"{_language} - {_level} - {_group} - {_metro} - {_id}";
            }
        }
    }
}