using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDU112Assignment2
{
    public class NameGenerator
    {
        List<string> Names;
        Random Rand;

        public NameGenerator()
        {
            Names = new List<string>();
            Rand = new Random();

            Names.Add("mon");
            Names.Add("rey");
            Names.Add("fay");
            Names.Add("quark");
            Names.Add("zord");
            Names.Add("yzen");
            Names.Add("bragh");
            Names.Add("kor");
            Names.Add("vort");
            Names.Add("waja");
            Names.Add("baha");
        }

        /// <summary>
        /// Generates a string name for characters
        /// </summary>
        /// <param name="syllables">The number of syllables for character</param>
        /// <returns>string name for character</returns>
        public string GenerateName(int syllables)
        {
            string name = "";
            for (int x = 0; x < syllables; x++)
            {
                name += Names[Rand.Next(Names.Count())];
            }

            return name;
        }
    }
}
