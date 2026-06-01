using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PraksaPrviDan
{
    public class Player : ClubMember, ITrainable
    {
        private int jerseyNumber;

        public int JerseyNumber
        {
            get { return jerseyNumber; }
            set
            {
                if (value > 0)
                {
                    jerseyNumber = value;
                }
                else
                {
                    jerseyNumber = 1;
                }
            }
        }

        public string Position { get; set; }
        public double MarketValue { get; set; }

        public Player(string name, int age, string clubName, int jerseyNumber, string position, double marketValue)
            : base(name, age, clubName)
        {
            JerseyNumber = jerseyNumber;
            Position = position;
            MarketValue = marketValue;
        }

        public override void ShowInfo()
        {
            Console.WriteLine("=== IGRAČ ===");
            ShowBasicInfo();
            Console.WriteLine($"Broj dresa: {JerseyNumber}");
            Console.WriteLine($"Pozicija: {Position}");
            Console.WriteLine($"Tržišna vrijednost: {MarketValue} mil. eur");
        }

        public void Train()
        {
            Console.WriteLine($"{Name} trenira na poziciji {Position}.");
        }
        public void UpdateMarketValue(double newValue)
        {
            if (newValue < 0)
            {
                Console.WriteLine("Tržišna vrijednost ne može biti negativna.");
                return;
            }

            double oldValue = MarketValue;
            MarketValue = newValue;

            Console.WriteLine($"{Name}: tržišna vrijednost promijenjena s {oldValue} na {MarketValue} mil. eur.");
        }
    }
}