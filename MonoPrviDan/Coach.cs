using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PraksaPrviDan
{
    public class Coach : ClubMember, ITrainable
    {
        public string Formation { get; set; }
        public int ExperienceYears { get; set; }

        public Coach(string name, int age, string clubName, string formation, int experienceYears)
            : base(name, age, clubName)
        {
            Formation = formation;
            ExperienceYears = experienceYears;
        }

        public override void ShowInfo()
        {
            Console.WriteLine("=== TRENER ===");
            ShowBasicInfo();
            Console.WriteLine($"Omiljena formacija: {Formation}");
            Console.WriteLine($"Godine iskustva: {ExperienceYears}");
        }

        public void Train()
        {
            Console.WriteLine($"{Name} vodi trening i postavlja formaciju {Formation}.");
        }
    }
}