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
        private bool Dead;
        private string Name;
        private Random rand;

        public Character(int agility, int stamina, int strength, int acuity, string name = "Character")
        {
            Name = name;
            Agility = agility;
            Stamina = stamina;
            Strength = strength;
            Acuity = acuity;
            rand = new Random();

            //Set Health
            Health = Stamina * 10;
            Dead = false;
        }

        /// <summary>
        /// The Dodge Chance calculated from the character's agility
        /// </summary>
        public double DodgeChance
        {
            get { return Agility * 0.01; }
        }

        /// <summary>
        /// The Damage calculated from the character's strength
        /// </summary>
        public int Damage
        {
            get { return Convert.ToInt32(Strength * 1.5); }
        }

        /// <summary>
        /// Critical Hit Chance calculated from the character's acuity
        /// </summary>
        public double CritChance
        {
            get { return Acuity * 0.01; }
        }

        /// <summary>
        /// Returns the current health of the character
        /// </summary>
        public int Health
        {
            get { return _Health; }
            set { _Health = value; }
        }
        
        /// <summary>
        /// Writes to the console character details
        /// </summary>
        public void Details()
        {
            Console.WriteLine(this.Name + " has " + this.Health + " health, " + this.DodgeChance + " Dodge Chance, " + this.Damage + " damage and " + this.CritChance + " crit chance");
        }
        
        /// <summary>
        /// Records and applies damage to the character
        /// </summary>
        /// <param name="Dmg"> The damage that the character receives </param>
        /// <returns>true if character is dead and false otherwise</returns>
        public bool TakesDamage(int Dmg)
        {
            //Applies damage to character and checks if health is greater than zero
            Console.WriteLine(this.Name + " Takes " + Dmg + " damage!");
            this.Health -= Dmg;
            if (this.Health > 0)
            {
                Console.WriteLine(this.Name + " is Alive with " + this._Health + " health!");
                return false;
            }
            else
            {
                Console.WriteLine(this.Name + " has DIED!");
                Dead = true;
                return true;
            }
        }

        /// <summary>
        /// Processes the current character attacking target character
        /// </summary>
        /// <param name="target"> Target character to be attacked</param>
        /// <returns> true if target character is dead and false otherwise </returns>
        public bool Attack(Character target)
        {
            int dmg = this.Damage;
            //Generates random values for crit and dodge check
            bool crit = rand.NextDouble() < this.CritChance ? true : false;
            bool dodge = rand.NextDouble() < target.DodgeChance ? true : false;
            //Checks if the target character dodged
            if (dodge)
            {
                Console.WriteLine(this.GenerateDodgeText());
                return false;
            }
            //Checks if the attacking character landed a critical hit
            if (crit)
            {
                Console.WriteLine(this.GenerateCritText());
                dmg *= 2;
            }

            return target.TakesDamage(dmg);
        }
        
        /// <summary>
        /// Returns the character name
        /// </summary>
        /// <returns>string name of character</returns>
        public string GetCharacterName()
        {
            return this.Name;
        }

        /// <summary>
        /// Generates a dodge narration
        /// </summary>
        /// <returns>string of dodge narration text</returns>
        private string GenerateDodgeText()
        {
            string[] DodgeText = new string[] {
                "At the last moment " + this.Name + " ducks underneath the attack dodging it",
                "In a feat of agility " + this.Name + " leans backwards matrix style and dodges the attack",
                this.Name + " throws themselves to the left dodging the attack barely",
                this.Name + " calmly moves his head slightly to the left dodging the attack",
                this.Name + " falls over clumsily but still manages to avoid the attack"
            };

            return DodgeText[rand.Next(DodgeText.Length)];
        }

        /// <summary>
        /// Generates a critical hit narration
        /// </summary>
        /// <returns>string of critical hit narration</returns>
        private string GenerateCritText()
        {
            string[] CritText = new string[]
            {
                this.Name + " lands a devastating blow on their target dealing CRITICAL damage.",
                this.Name + " swings blindly somehow hitting their target and dealing CRITICAL damage.",
                "With blinding speed " + this.Name + " attacks, dealing CRITICAL damage to their opponent.",
                this.Name + " attacks with precision dealing CRITICAL damage to their opponent."
            };

            return CritText[rand.Next(CritText.Length)];
        }
    }
}
