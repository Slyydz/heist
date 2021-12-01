using System;
using System.Collections.Generic;

namespace heist
{
    class Program
    {
        static void Main(string[] args)
        {
            Muscle muscle1 = new Muscle();
            Muscle muscle2 = new Muscle();
            Hacker hacker1 = new Hacker();
            Hacker hacker2 = new Hacker();
            LockSpecialists lock1 = new LockSpecialists();
            LockSpecialists lock2 = new LockSpecialists();

            List<IRobber> rolodex = new List<IRobber> {
                muscle1,
                muscle2,
                hacker1,
                hacker2,
                lock1,
                lock2
            };
        }
    }
}
