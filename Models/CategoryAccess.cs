using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class CategoryAccess
    {
        private int _ID; // field
        public int ID   // property
        {
            get { return _ID; }   // get method
            set { _ID = value; }  // set method
        }

        private string _Title; // field
        public string Title   // property
        {
            get { return _Title; }   // get method
            set { _Title = value; }  // set method
        }

        private string _Department; // field
        public string Department   // property
        {
            get { return _Department; }   // get method
            set { _Department = value; }  // set method
        }

    }
}