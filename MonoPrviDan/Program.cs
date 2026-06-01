using System;
using System.Collections.Generic;

namespace PraksaPrviDan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<ClubMember> members = new List<ClubMember>
            {
                new Player("Luka Modric", 39, "Real Madrid", 10, "Midfielder", 8.5),
                new Player("Josko Gvardiol", 23, "Manchester City", 24, "Defender", 75.0),
                new Coach("Zlatko Dalic", 59, "Croatia", "4-3-3", 15)
            };

            bool run = true;

            while (run)
            {
                Console.Clear();
                Console.WriteLine("=== NOGOMETNI KLUB ===");
                Console.WriteLine("1 - Prikaži sve članove");
                Console.WriteLine("2 - Prikaži sve igrače");
                Console.WriteLine("3 - Prikaži sve trenere");
                Console.WriteLine("4 - Prikaži sve članove detaljno");
                Console.WriteLine("5 - Pokreni trening");
                Console.WriteLine("6 - Promijeni broj dresa");
                Console.WriteLine("7 - Dodaj novog člana");
                Console.WriteLine("8 - Prikaži igrače sortirane po tržišnoj vrijednosti");
                Console.WriteLine("0 - Izlaz");
                Console.Write("Odabir: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ShowAllMembers(members);
                        break;
                    case "2":
                        ShowPlayers(members);
                        break;
                    case "3":
                        ShowCoaches(members);
                        break;
                    case "4":
                        ShowDetailedMembers(members);
                        break;
                    case "5":
                        StartTraining(members);
                        break;
                    case "6":
                        ChangeJerseyNumber(members);
                        break;
                    case "7":
                        AddMember(members);
                        break;
                    case "8":
                        ShowPlayersSortedByMarketValue(members);
                        break;
                    case "0":
                        run = false;
                        break;
                    default:
                        Console.WriteLine("Neispravan unos.");
                        break;
                }

                if (run)
                {
                    Console.WriteLine("\nPritisni bilo koju tipku za nastavak...");
                    Console.ReadKey();
                }
            }
        }

        static void ShowAllMembers(List<ClubMember> members)
        {
            Console.WriteLine("\n--- SVI ČLANOVI ---");

            foreach (ClubMember member in members)
            {
                member.ShowBasicInfo();
                Console.WriteLine();
            }
        }

        static void ShowPlayers(List<ClubMember> members)
        {
            Console.WriteLine("\n--- IGRAČI ---");

            foreach (ClubMember member in members)
            {
                if (member is Player player)
                {
                    Console.WriteLine($"{player.Name} - broj {player.JerseyNumber} - {player.Position}");
                }
            }
        }

        static void ShowCoaches(List<ClubMember> members)
        {
            Console.WriteLine("\n--- TRENERI ---");

            foreach (ClubMember member in members)
            {
                if (member is Coach coach)
                {
                    Console.WriteLine($"{coach.Name} - formacija {coach.Formation}");
                }
            }
        }

        static void ShowDetailedMembers(List<ClubMember> members)
        {
            Console.WriteLine("\n--- DETALJNI PRIKAZ ---");

            foreach (ClubMember member in members)
            {
                member.ShowInfo();
                Console.WriteLine();
            }
        }

        static void StartTraining(List<ClubMember> members)
        {
            Console.WriteLine("\n--- TRENING ---");

            foreach (ClubMember member in members)
            {
                if (member is ITrainable trainableMember)
                {
                    trainableMember.Train();
                }
            }
        }

        static void ChangeJerseyNumber(List<ClubMember> members)
        {
            Console.WriteLine("\n--- PROMJENA BROJA DRESA ---");

            List<Player> players = new List<Player>();

            foreach (ClubMember member in members)
            {
                if (member is Player player)
                {
                    players.Add(player);
                }
            }

            if (players.Count == 0)
            {
                Console.WriteLine("Nema igrača u klubu.");
                return;
            }

            for (int i = 0; i < players.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {players[i].Name} - trenutni broj: {players[i].JerseyNumber}");
            }

            Console.Write("Odaberi igrača: ");
            bool validPlayerChoice = int.TryParse(Console.ReadLine(), out int playerChoice);

            if (!validPlayerChoice || playerChoice < 1 || playerChoice > players.Count)
            {
                Console.WriteLine("Neispravan odabir igrača.");
                return;
            }

            Console.Write("Unesi novi broj dresa: ");
            bool validNewNumber = int.TryParse(Console.ReadLine(), out int newNumber);

            if (!validNewNumber)
            {
                Console.WriteLine("Neispravan broj dresa.");
                return;
            }

            players[playerChoice - 1].JerseyNumber = newNumber;

            Console.WriteLine($"Novi broj igrača {players[playerChoice - 1].Name} je {players[playerChoice - 1].JerseyNumber}");
        }
        static void AddMember(List<ClubMember> members)
        {
            Console.WriteLine("\n--- DODAJ ČLANA ---");
            Console.WriteLine("1 - Igrač");
            Console.WriteLine("2 - Trener");
            Console.Write("Odabir: ");
            string typeChoice = Console.ReadLine();

            if (typeChoice == "1")
            { 
                Console.Write("Ime: ");
                string name = Console.ReadLine();

                Console.Write("Godine: ");
                int age = int.Parse(Console.ReadLine());

                Console.Write("Klub: ");
                string clubName = Console.ReadLine();

                Console.Write("Broj dresa: ");
                int jerseyNumber = int.Parse(Console.ReadLine());

                Console.Write("Pozicija: ");
                string position = Console.ReadLine();

                Console.Write("Tržišna vrijednost: ");
                double marketValue = double.Parse(Console.ReadLine());

                members.Add(new Player(name, age, clubName, jerseyNumber, position, marketValue));
                Console.WriteLine("Igrač je dodan.");
            }
            else if (typeChoice == "2")
            {
                Console.Write("Ime: ");
                string name = Console.ReadLine();

                Console.Write("Godine: ");
                int age = int.Parse(Console.ReadLine());

                Console.Write("Klub: ");
                string clubName = Console.ReadLine();

                Console.Write("Formacija: ");
                string formation = Console.ReadLine();

                Console.Write("Godine iskustva: ");
                int experienceYears = int.Parse(Console.ReadLine());

                members.Add(new Coach(name, age, clubName, formation, experienceYears));
                Console.WriteLine("Trener je dodan.");
            }
            else
            {
                Console.WriteLine("Neispravan odabir.");
            }
        }
        static void ShowPlayersSortedByMarketValue(List<ClubMember> members)
        {
            List<Player> players = new List<Player>();

            foreach (ClubMember member in members)
            {
                if (member is Player player)
                {
                    players.Add(player);
                }
            }

            if (players.Count == 0)
            {
                Console.WriteLine("Nema igrača u klubu.");
                return;
            }

            var sortedPlayers = players.OrderByDescending(p => p.MarketValue);

            Console.WriteLine("\n--- IGRAČI SORTIRANI PO TRŽIŠNOJ VRIJEDNOSTI ---");

            foreach (Player player in sortedPlayers)
            {
                Console.WriteLine($"{player.Name} - {player.MarketValue} mil. € - {player.Position}");
            }
        }
    }
}