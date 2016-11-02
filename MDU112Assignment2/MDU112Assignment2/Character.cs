using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDU112Assignment2
{
    public class Character
    {
        private int Agility;
        private int Stamina;
        private int Strength;
        private int Acuity;
        private int _Health;

        public Character(int agility, int stamina, int strength, int acuity)
        {
            Agility = agility;
            Stamina = stamina;
            Strength = strength;
            Acuity = acuity;

            //Set Health
            Health = Stamina * 10;
        }

        //Functions to retrieve stats
        private double DodgeChance
        {
            get { return Agility * 0.01; }
        }

        private int Damage
        {
            get { return Convert.ToInt32(Strength * 1.5); }
        }

        private double CritChance
        {
            get { return Acuity * 0.01; }
        }

        //Health is the only stat that will change
        private int Health
        {
            get { return _Health; }
            set { _Health = value; }
        }
        //Function to get stats, automatically converting attributes to stats
        public void Details()
        {
            Console.WriteLine("Character has " + this.Health + " health, " + this.DodgeChance + " Dodge Chance, " + this.Damage + " damage and " + this.CritChance + " crit chance");
        }
        
        //Returns true or false whether character is dead
        public bool TakesDamage(int Dmg)
        {
            Console.WriteLine("Character Takes " + Dmg + " damage!");
            this.Health -= Dmg;
            if (this.Health > 0)
            {
                Console.WriteLine("Character is Alive with " + this._Health + " health!");
                return false;
            }
            else
            {
                Console.WriteLine("Character has DIED!");
                return true;
            }
        }

        //Returns true or false whether target is dead
        public bool Attack(Character target)
        {
            int dmg = this.Damage;

            Random rand = new Random();

            bool crit = rand.NextDouble() < this.CritChance ? true : false;
            bool dodge = rand.NextDouble() < target.DodgeChance ? true : false;

            if (dodge)
            {
                Console.WriteLine("Character has dodged out of the way!");
                return false;
            }

            if (crit)
            {
                Console.WriteLine("Character Crits!");
                dmg *= 2;
            }

            return target.TakesDamage(dmg);
        }
        //Function to calculate a battle scenario? input, target character
    }
}
