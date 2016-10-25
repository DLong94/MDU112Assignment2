using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDU112Assignment2
{
    class Program
    {
        static void Main(string[] args)
        {
            
            //Create a roster of 10 characters
            List<Character> roster = new List<Character>();
            for (int x = 0; x < 10; x++)
            {
                roster.Add(new Character());
            }

            List<Character> Team1 = new List<Character>();
            List<Character> Team2 = new List<Character>();
            AssignTeams(roster, Team1, Team2);

            Battle(Team1, Team2);
        }

        private static void Battle(List<Character> team1, List<Character> team2)
        {
            Console.WriteLine("Team 1:");
            for (int x = 0; x < team1.Count(); x++)
            {
                team1[x].Details();
            }
            Console.WriteLine("");

            Console.WriteLine("Team 2:");
            for (int x = 0; x < team2.Count(); x++)
            {
                team2[x].Details();
            }
            Console.WriteLine("");

            Console.ReadLine();
        }

        private static void AssignTeams(List<Character> roster, List<Character> Team1, List<Character> Team2)
        {
            Random rand = new Random();

            for (int x = 0; x < 3; x++)
            {
                int index = rand.Next(roster.Count()); //Pick a random number between 0 and the size of the roster
                Team1.Add(roster[index]); //Add that character to the roster
                roster.Remove(roster[index]); //Remove that character from the available roster
            }

            for (int x = 0; x < 3; x++)
            {
                int index = rand.Next(roster.Count()); //Pick a random number between 0 and the size of the roster
                Team2.Add(roster[index]); //Add that character to the roster
                roster.Remove(roster[index]); //Remove that character from the available roster
            }
        }
    }
}
