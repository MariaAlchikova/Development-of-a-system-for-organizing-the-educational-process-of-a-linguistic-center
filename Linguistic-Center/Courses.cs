using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//24.05.17 
namespace Linguistic_Center
{
    [Serializable]
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

        public string Group
        {
            get

            {
                return _group;
            }
            set
            {
                _group = value;
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

        public string ID
        {
            get

            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        public Courses(string lng, string lvl, string grp, string met, string id)
        {

            Language = lng;
            Level = lvl;
            Group = grp;
            Metro = met;
            ID = id;
        }
    }
}