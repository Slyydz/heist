using System;
using System.Collections.Generic;
using System.Linq;

namespace heist
{
    class Program
    {
        static void Main(string[] args)
        {
            Muscle muscle1 = new Muscle()
            {
                Name = "nameHoldMuscle1",
                SkillLevel = 100,
                PercentageCut = 10
            };
            Muscle muscle2 = new Muscle()
            {
                Name = "nameHoldMuscle2",
                SkillLevel = 50,
                PercentageCut = 10
            };
            Hacker hacker1 = new Hacker()
            {
                Name = "nameHoldHacker1",
                SkillLevel = 50,
                PercentageCut = 10
            };
            Hacker hacker2 = new Hacker()
            {
                Name = "nameHoldHacker2",
                SkillLevel = 50,
                PercentageCut = 10
            };
            LockSpecialists lock1 = new LockSpecialists()
            {
                Name = "nameHoldLock1",
                SkillLevel = 100,
                PercentageCut = 10
            };
            LockSpecialists lock2 = new LockSpecialists()
            {
                Name = "nameHoldLock2",
                SkillLevel = 50,
                PercentageCut = 10
            };

            List<IRobber> rolodex = new List<IRobber> {
                muscle1,
                muscle2,
                hacker1,
                hacker2,
                lock1,
                lock2
            };

            foreach (IRobber robber in rolodex)
            {
                Console.WriteLine($"{robber.Name}");
            }

            Console.WriteLine();


            Console.Write("Enter new crew member name: ");
            string crewMember = Console.ReadLine();

            while (crewMember != "")
            {

                Console.WriteLine();

                Console.Write($"Enter a specialty for {crewMember} (Hacker, Lock Specialist, Muscle): ");
                string specialty = Console.ReadLine();

                Console.WriteLine();

                Console.Write($"Enter the skill level for {crewMember} (1-100): ");
                int skillLevel = Int32.Parse(Console.ReadLine());

                Console.WriteLine();

                Console.Write($"Enter the percentage of the cut {crewMember} will get: ");
                int cutPer = Int32.Parse(Console.ReadLine());

                switch (specialty)
                {
                    case "Hacker":
                        rolodex.Add(new Hacker()
                        {
                            Name = crewMember,
                            SkillLevel = skillLevel,
                            PercentageCut = cutPer
                        });
                        break;
                    case "Muscle":
                        rolodex.Add(new Muscle()
                        {
                            Name = crewMember,
                            SkillLevel = skillLevel,
                            PercentageCut = cutPer
                        });
                        break;
                    case "Lock Specialist":
                        rolodex.Add(new LockSpecialists()
                        {
                            Name = crewMember,
                            SkillLevel = skillLevel,
                            PercentageCut = cutPer
                        });
                        break;
                }

                Console.WriteLine();

                Console.Write("Enter new crew member name: ");
                crewMember = Console.ReadLine();
            }

            Random randInt = new Random();

            Bank bank1 = new Bank()
            {
                AlarmScore = randInt.Next(0, 100),
                VaultScore = randInt.Next(0, 100),
                SecurityGuardScore = randInt.Next(0, 100),
                CashOnHand = randInt.Next(50000, 1000000)
            };

            Dictionary<string, int> systemList = new Dictionary<string, int>(){
                {"Alarm", bank1.AlarmScore},
                {"Vault", bank1.VaultScore},
                {"Security Guard", bank1.SecurityGuardScore}
            };

            Console.WriteLine();

            var sortedDict = from entry in systemList orderby entry.Value ascending select entry;

            Console.WriteLine($"Least Secure: {sortedDict.ElementAt(0).Key}");
            Console.WriteLine($"Most Secure: {sortedDict.ElementAt(2).Key}");

            Console.WriteLine();
            Console.WriteLine("-------------------------------");
            Console.WriteLine();

            for (int i = 0; i < rolodex.Count; i++)
            {
                Console.WriteLine($"({i + 1}) Name: {rolodex[i].Name} || Specialty: {rolodex[i].GetType().ToString().Split('.')[1]} || Skill level: {rolodex[i].SkillLevel} || Cut: {rolodex[i].PercentageCut}");
            }

            List<IRobber> crew = new List<IRobber>();

            Console.WriteLine();
            Console.WriteLine("-------------------------------");
            Console.WriteLine();

            Console.Write("Enter the number of the operative you would like to include in the heist: ");
            string output = Console.ReadLine();


            while (output != "")
            {
                int num = int.Parse(output) - 1;
                int total = 0;

                foreach (IRobber robber in rolodex)
                {
                    total += robber.PercentageCut;
                }

                List<IRobber> filtered = rolodex.Where(r => !crew.Contains(r) && r.PercentageCut < 100 - crew.Select(s => s.PercentageCut).Sum()).ToList();

                if (filtered.Contains(rolodex[num]))
                {
                    crew.Add(rolodex[num]);
                    Console.WriteLine();
                    Console.WriteLine("Operative succesfully added!");
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Operative is already added!");
                }

                Console.WriteLine();

                Console.Write("Enter the number of the operative you would like to include in the heist: ");
                output = Console.ReadLine();
            }

            Console.WriteLine();
            Console.WriteLine("-------------------------------");

            foreach (IRobber member in crew)
            {

                Console.WriteLine($"{member.Name}");


            }

            Console.WriteLine();

            foreach (IRobber member in crew)
            {

                Console.WriteLine();
                member.PerformSkill(bank1);

            }

            if (bank1.isSecure)
            {
                Console.WriteLine();
                Console.WriteLine("Uh Oh! You got caught :(");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Successfully robbed the bank!");
                Console.WriteLine();

                double crewTake = bank1.CashOnHand;

                foreach (IRobber member in crew)
                {
                    Console.WriteLine($"{member.Name}'s cut: {Math.Round(bank1.CashOnHand * ((double)member.PercentageCut / 100))}");

                    crewTake -= Math.Round(bank1.CashOnHand * ((double)member.PercentageCut / 100));
                }

                Console.WriteLine();

                Console.WriteLine($"Your Take: {crewTake}");
            }

        }
    }
}
