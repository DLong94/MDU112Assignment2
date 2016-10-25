﻿using System;
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

        public Character()
        {
            Random rand = new Random();

            Agility = rand.Next(5, 16);
            Stamina = rand.Next(5, 16);
            Strength = rand.Next(5, 16);
            Acuity = rand.Next(5, 16);

            //Call function that allocates random attributes
        }

        //Functions to retrieve stats
        private int Health
        {
            get { return Stamina * 10; }
        }

        private int Speed
        {
            get { return Agility * 2; }
        }

        private double Damage
        {
            get { return Strength * 1.5; }
        }

        private double CritChance
        {
            get { return Acuity * 0.01; }
        }
        //Function to get stats, automatically converting attributes to stats

        //Allow game to get attributes? only stats?

        //Function to calculate a battle scenario? input, target character
    }
}
