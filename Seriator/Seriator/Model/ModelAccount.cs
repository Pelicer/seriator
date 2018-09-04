using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seriator.Model
{
    class ModelAccount
    {
        private int userId;
        private string userName;
        private string userPassword;
        private double userTimeWatched;

        public int UserId
        {
            get
            {
                return userId;
            }

            set
            {
                userId = value;
            }
        }

        public string UserName
        {
            get
            {
                return userName;
            }

            set
            {
                userName = value;
            }
        }

        public string UserPassword
        {
            get
            {
                return userPassword;
            }

            set
            {
                userPassword = value;
            }
        }

        public double UserTimeWatched
        {
            get
            {
                return userTimeWatched;
            }

            set
            {
                userTimeWatched = value;
            }
        }

    }
}
