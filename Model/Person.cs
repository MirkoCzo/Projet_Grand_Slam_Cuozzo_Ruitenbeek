using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Grand_Slam_Cuozzo_Ruitenbeek
{
    internal class Person
    {
        private string firstname;
        private string lastname;
        private string nationality;

        public string getFirstname()
        {
            return firstname;
        }
        public string getLastname()
        {
            return lastname;
        }
        public string getNationality()
        {
            return nationality;
        }
        public void setFirstname(string firstname)
        {
            this.firstname = firstname;
        }
        public void setLastname(string lastname)
        {
            this.lastname = lastname;
        }
        public void setNationality(string nationality)
        {
            this.nationality = nationality;
        }
    }
}
