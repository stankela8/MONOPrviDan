using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PraksaPrviDan
{
    public abstract class ClubMember
    {
        public string Name { get; set; }
        public int Age { get; set; }

        protected string clubName;

        protected ClubMember(string name, int age, string clubName)
        {
            Name = name;
            Age = age;
            this.clubName = clubName;
        }

        public string GetClubName()
        {
            return clubName;
        }

        public virtual void ShowBasicInfo()
        {
            Console.WriteLine($"Ime: {Name}");
            Console.WriteLine($"Godine: {Age}");
            Console.WriteLine($"Klub: {clubName}");
        }

        public abstract void ShowInfo();
    }
}