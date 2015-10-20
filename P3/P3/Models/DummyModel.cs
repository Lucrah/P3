using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace P3.Models
{
    enum AccessLevel
	{
	    Guest = 0,
        User = 1,
        Admin = 2,
        Developer = 3
	};

    class DummyModel : BaseINPCModel, INotifyPropertyChanged
    {
        //Contaning a few properties, a couple of actions, for learning purposes

        public DummyModel() { }
        public DummyModel( int age, string name, AccessLevel useraccessLevel)
        {
            _age = age;
            _name = name;
            _userAccessLevel = useraccessLevel;
        } 

        private int _age;
        public int Age
        {
            get { return _age; }
            set 
            {
                if (_age != value)
                {
                    _age = value;
                    RaisePropertyChanged("Age");
                }
            }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    RaisePropertyChanged("Name");
                }
            }
        }

        private AccessLevel _userAccessLevel;
        public AccessLevel UserAccessLevel
        {
            get { return _userAccessLevel; }
            set
            {
                if (_userAccessLevel != value)
                {
                    _userAccessLevel = value;
                    RaisePropertyChanged("UserAccessLevel");
                }
            }
        }

       
        
    }
}
