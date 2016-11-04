using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDU112Assignment2
{
    class Program
    {
        const int ROSTER_SIZE = 10;
        const int MIN_STAT = 5;
        const int MAX_STAT = 16;
        const int TEAM_SIZE = 3;

        static void Main(string[] args)
        {
            
            //Create a roster of 10 characters
            List<Character> roster = new List<Character>();
            Random RandomStatGenerator = new Random();
            NameGenerator NameGenerator = new NameGenerator();

            for (int x = 0; x < ROSTER_SIZE; x++)
            {
                string name = NameGenerator.GenerateName(2);
                int agility = RandomStatGenerator.Next(MIN_STAT, MAX_STAT);
                int stamina = RandomStatGenerator.Next(MIN_STAT, MAX_STAT);
                int strength = RandomStatGenerator.Next(MIN_STAT, MAX_STAT);
                int acuity = RandomStatGenerator.Next(MIN_STAT, MAX_STAT);

                roster.Add(new Character(agility, stamina, strength, acuity, name));
            }

            List<Character> Team1 = new List<Character>();
            List<Character> Team2 = new List<Character>();
            AssignTeams(roster, Team1, Team2);

            Battle(Team1, Team2);
        }

        //Create Battle scenario between two teams
        private static void Battle(List<Character> team1, List<Character> team2)
        {
            Random rand = new Random();
            int round = 1;

            while (team1.Count() > 0 && team2.Count() > 0)
            {
                Console.WriteLine("ROUND " + round);
                //Selects which team attacks first
                if (rand.NextDouble() >= 0.5)
                {
                    //Team 1 Attacks Team 2
                    Console.WriteLine("Team 1 attacks Team 2");
                    TeamAttack(team1, team2, rand);

                    if (team1.Count() == 0 || team2.Count() == 0) break;

                    //Team 2 Attacks Team 1
                    Console.WriteLine("Team 2 attacks Team 1");
                    TeamAttack(team2, team1, rand);
                }
                else
                {
                    //Team 2 Attacks Team 1
                    Console.WriteLine("Team 2 attacks Team 1"); 
                    TeamAttack(team2, team1, rand);

                    if (team1.Count() == 0 || team2.Count() == 0) break;

                    //Team 1 Attacks Team 2
                    Console.WriteLine("Team 1 attacks Team 2");
                    TeamAttack(team1, team2, rand);
                }

                Console.ReadLine();

                round++;
            }

            if (team1.Count() > 0)
            {
                Console.WriteLine("TEAM 1 IS THE WINNER!");
            }
            else
            {
                Console.WriteLine("TEAM 2 IS THE WINNER!");
            }
            Console.ReadLine();
        }

        //Team Attacks Another team with randomly generated attacker and target
        private static void TeamAttack(List<Character> attackingTeam, List<Character> defendingTeam, Random rand)
        {
            int attacker = rand.Next(attackingTeam.Count());
            int target = rand.Next(defendingTeam.Count());
            if (attackingTeam[attacker].Attack(defendingTeam[target]))
            {
                defendingTeam.Remove(defendingTeam[target]);
            }
        }

        //Assign Characters to both teams from the roster
        private static void AssignTeams(List<Character> roster, List<Character> Team1, List<Character> Team2)
        {
            Random rand = new Random();

            //Assign Characters from roster to team 1 and removethem from the roster list
            Console.WriteLine("TEAM 1:");
            for (int x = 0; x < TEAM_SIZE; x++)
            {
                int index = rand.Next(roster.Count());
                roster[index].Details();
                Team1.Add(roster[index]);
                roster.Remove(roster[index]);
            }

            //Assign Characters from roster to team 2 and remove them from the roster list
            Console.WriteLine("TEAM 2:");
            for (int x = 0; x < TEAM_SIZE; x++)
            {
                int index = rand.Next(roster.Count());
                roster[index].Details();
                Team2.Add(roster[index]);
                roster.Remove(roster[index]);
            }
        }
    }
}
