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

        public Character()
        {
            Random rand = new Random();

            Agility = rand.Next(5, 16);
            Stamina = rand.Next(5, 16);
            Strength = rand.Next(5, 16);
            Acuity = rand.Next(5, 16);

            //Set Health
            Health = Stamina * 10;
        }

        //Functions to retrieve stats
        private int Speed
        {
            get { return Agility * 2; }
        }

        private double Damage
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
            Console.WriteLine("This Character has " + this.Health + " health, " + this.Speed + " speed, " + this.Damage + " damage and " + this.CritChance + " crit chance");
        }
        //Function to calculate a battle scenario? input, target character
    }
}
