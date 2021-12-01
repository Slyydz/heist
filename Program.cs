using System;
using System.Collections.Generic;

namespace heist
{
    class Program
    {
        static void Main(string[] args)
        {
            Muscle muscle1 = new Muscle()
            {
                Name = "nameHold",
                SkillLevel = 50,
                PercentageCut = 10
            };
            Muscle muscle2 = new Muscle()
            {
                Name = "nameHold",
                SkillLevel = 50,
                PercentageCut = 10
            };
            Hacker hacker1 = new Hacker()
            {
                Name = "nameHold",
                SkillLevel = 50,
                PercentageCut = 10
            };
            Hacker hacker2 = new Hacker()
            {
                Name = "nameHold",
                SkillLevel = 50,
                PercentageCut = 10
            };
            LockSpecialists lock1 = new LockSpecialists()
            {
                Name = "nameHold",
                SkillLevel = 50,
                PercentageCut = 10
            };
            LockSpecialists lock2 = new LockSpecialists()
            {
                Name = "nameHold",
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

            foreach (IRobber robber in rolodex)
            {
                Console.WriteLine($"{robber.Name}");
            }

        }
    }
}
