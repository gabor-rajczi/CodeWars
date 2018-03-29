using System;
using NUnit.Framework;

namespace CodeWars.Dubstep
{
    [TestFixture]
    public class DubstepTests
    {
        [Test]
        public void Test1()
        {
            var result = Dubstep.SongDecoder("WUBWUBABCWUB");
          Assert.AreEqual("ABC", result);
        }

        [Test]
        public void Test2()
        {
          Assert.AreEqual("R L", Dubstep.SongDecoder("RWUBWUBWUBLWUB"));
        }
    }
}
