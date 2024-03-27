using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Todo_MVC.Models
{
    public class User
    {
		private long _id;
        private string _username;
        private string _password;

        public long Id
		{
			get { return _id; }
			set { _id = value; }
		}

		public string Username
		{
			get { return _username; }
			set { _username = value; }
		}

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public User() { }

        public User(string username, string password)
        {
            _username = username;
            _password = password;
        }

        public User(long id, string username, string password)
        {
            _id = id;
            _username = username;
            _password = password;
        }
    }
}