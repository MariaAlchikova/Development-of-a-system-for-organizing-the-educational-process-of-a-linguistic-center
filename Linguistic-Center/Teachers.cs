using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linguistic_Center
{
    class Teachers
    {
        private string _name;
        private string _foreignLanguage; 
        private float _groupNumber;



        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        public string ForeignLanguage
        {
            get
            {
                return _foreignLanguage;
            }
            set
            {
                _foreignLanguage = value;
            }
        }

        public float GroupNumber
        {
            get
            {
                return _groupNumber;
            }
            set
            {
                _groupNumber = value;
            }
        }

        
        public Teachers(string teachersName, string fLang, float gNumber)
        {
            Name = teachersName;
            ForeignLanguage = fLang;
            GroupNumber = gNumber;
        }
    }
}
