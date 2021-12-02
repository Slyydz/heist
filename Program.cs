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
                SkillLevel = 50,
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
                SkillLevel = 50,
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

            var sortedDict = from entry in systemList orderby entry.Value ascending select entry;

            Console.WriteLine($"Least Secure: {sortedDict.ElementAt(0).Key}");
            Console.WriteLine($"Most Secure: {sortedDict.ElementAt(2).Key}");

            foreach (IRobber robber in rolodex)
            {
                Console.WriteLine($"Name: {robber.Name} || Specialty: {robber.GetType().ToString().Split('.')[1]} || Skill level: {robber.SkillLevel} || Cut: {robber.PercentageCut}");
            }

        }
    }
}
