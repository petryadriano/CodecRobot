using CodecRobot.Console;
using NUnit.Framework;

namespace CodecRobot.Tests
{
    public class RobotTest
    {
        private Robot? robot = null;

        [SetUp]
        public void Setup()
        {
            robot = new Robot();
        }

        [TestCase("5x5", "FFRFLFLF", "1,4,West")]
        [TestCase("2x2", "FFF", "1,2,North")]
        [TestCase("99999x99999", "LFFRLRLFFFRFLFLFFFRFLFLFLFFRLRLFFFRFLFLFFFRFLFLFLFFRLRLFFFRFLFLFFFRFLFLFLFFRLRLFFFRFLFLFFFRFLFLF", "2,1,West")]
        public void IsValidMovs(string size, string movs, string expectedResult)
        {
            // Assert
            Assert.AreEqual(expectedResult, robot?.execute(size, movs));
        }

        [TestCase("5x5", "FFRFLFLF", "2,2,West")]
        [TestCase("99999x99999", "LFFRLRLFFFRFLFFLFLF", "1,1,East")]
        public void IsInvalidMovs(string size, string movs, string expectedResult)
        {
            // Assert
            Assert.AreNotEqual(expectedResult, robot?.execute(size, movs));
        }
    }
}