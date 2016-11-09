using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MDU112Assignment2;

namespace Assignment2Test
{
    [TestClass]
    public class Assingment2Test
    {
        [TestMethod]
        public void TestNameGenerator()
        {
            NameGenerator Generator = new NameGenerator();

            Assert.IsTrue(Generator.GenerateName(1) is string);

            Assert.IsTrue(Generator.GenerateName(2) is string);

            Assert.IsTrue(Generator.GenerateName(3) is string);

            Assert.IsTrue(Generator.GenerateName(4) is string);

            Assert.IsTrue(Generator.GenerateName(5) is string);
        }

        [TestMethod]
        public void TestCharacter()
        {
            Character Char = new Character(10, 10, 10, 10);

            Assert.AreEqual("Character", Char.GetCharacterName(), "Name is not generating correctly");

            Assert.AreEqual(100, Char.Health, "Health is not calculating correctly");

            Assert.AreEqual(0.1, Char.DodgeChance, "Dodge Chance is not calculating correctly");

            Assert.AreEqual(0.1, Char.CritChance, "Crit Chance is not calculating correctly");

            Assert.AreEqual(15, Char.Damage, "Damage is not calculating correctly");

            Assert.IsFalse(Char.TakesDamage(10), "Damage taken is not calculated correctly");

            Assert.AreEqual(90, Char.Health, "Health taken is not being calculated correctly");

            Assert.IsTrue(Char.TakesDamage(100), "Character is not identified as being dead");
        }
    }
}
