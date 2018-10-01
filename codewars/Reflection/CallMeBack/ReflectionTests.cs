namespace CodeWars.Reflection.CallMeBack
{
    using NUnit.Framework;

    [TestFixture]
    public class ReflectionTests
    {
        private static bool setting;

        public static void Activate()
        {
            setting = true;
        }

        [Test]
        public void Test()
        {
            Reflection.Activator();
            Assert.IsTrue(setting);
        }
    }
}
