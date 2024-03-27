using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Todo_MVC.Models
{
    public class Tasks
    {
        private long _id;
        private string _name;
        private bool _completed;

        public long Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public bool Completed
        {
            get { return _completed; }
            set { _completed = value; }
        }

        public Tasks()
        {
        }

        public Tasks(string name, bool completed)
        {
            _name = name;
            _completed = completed;
        }

        public Tasks(long id, string name, bool completed)
        {
            _id = id;
            _name = name;
            _completed = completed;
        }
    }
}