namespace CodeWars.BuildTower
{
    using NUnit.Framework;

    [TestFixture]
    public class BuildTowerTests
    {
        [Test]
        public void BuildTowerWith3Floors()
        {
            var excepted = new string[]
            {"  *  ", 
             " *** ", 
             "*****"
            };
            Assert.That(BuildTower.Build(3), Is.EquivalentTo(excepted));
        }

        [Test]
        public void BuildTowerWith6Floors()
        {
            var excepted = new string[]
            {"     *     ", 
             "    ***    ", 
             "   *****   ",
             "  *******  ",
             " ********* ",
             "***********"
            };
            Assert.That(BuildTower.Build(6), Is.EquivalentTo(excepted));
        }
    }

    [TestFixture]
    public class KataTests
    {
        [Test]
        public void BasicTests()
        {
            Assert.AreEqual(string.Join(",", new[] { "*" }), string.Join(",", Kata.TowerBuilder(1)));
            Assert.AreEqual(string.Join(",", new[] { " * ", "***" }), string.Join(",", Kata.TowerBuilder(2)));
            Assert.AreEqual(string.Join(",", new[] { "  *  ", " *** ", "*****" }), string.Join(",", Kata.TowerBuilder(3)));
        }
    }
}