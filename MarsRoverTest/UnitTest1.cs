using NUnit.Framework;
using MarsRover;

namespace MarsRoverTest
{
    [TestFixture]
    public class Tests
    {
        [SetUp]
        public void Setup() { }
        [Test]
        public void isCurrentPositionLengthBigger()
        {
            string[] cPos = { "1", "2", "N", "Z", "9" };
            string[] comm = { "L", "M", "L", "M", "L", "M", "L", "M", "M" };
            MarsRover.Rover r1 = new MarsRover.Rover(cPos, comm);

            Assert.That(r1.ErrCode == 0, r1.ErrDesc);
        }
        [Test]
        public void isCurrentPositionLengthLower()
        {
            string[] cPos = { "1", "2" };
            string[] comm = { "L", "M", "L", "M", "L", "M", "L", "M", "M" };
            MarsRover.Rover r1 = new MarsRover.Rover(cPos, comm);

            Assert.That(r1.ErrCode == 0, r1.ErrDesc);
        }
        [Test]
        public void isCurrentPositionFormatTrue()
        {
            string[] cPos = { "1", "2", "N" };
            string[] comm = { "L", "M", "L", "M", "L", "M", "L", "M", "M" };
            MarsRover.Rover r1 = new MarsRover.Rover(cPos, comm);

            Assert.That(r1.ErrCode == 0, r1.ErrDesc);
        }
        [Test]
        public void isCurrentPositionFormatFalseNotChar()
        {
            string[] cPos = { "1", "2", "5" };
            string[] comm = { "L", "M", "L", "M", "L", "M", "L", "M", "M" };
            MarsRover.Rover r1 = new MarsRover.Rover(cPos, comm);

            Assert.That(r1.ErrCode == 0, r1.ErrDesc);
        }
        [Test]
        public void isCurrentPositionFormatFalseNotNESW()
        {
            string[] cPos = { "1", "2", "Y" };
            string[] comm = { "L", "M", "L", "M", "L", "M", "L", "M", "M" };
            MarsRover.Rover r1 = new MarsRover.Rover(cPos, comm);

            Assert.That(r1.ErrCode == 0, r1.ErrDesc);
        }
        [Test]
        public void isInstructionsFormatTrue()
        {
            string[] cPos = { "1", "2", "N" };
            string[] comm = { "L", "M", "L", "M", "L", "M", "L", "M", "M" };
            MarsRover.Rover r1 = new MarsRover.Rover(cPos, comm);

            Assert.That(r1.ErrCode == 0, r1.ErrDesc);
        }
        [Test]
        public void isInstructionsFormatFalse()
        {
            string[] cPos = { "1", "2", "N" };
            string[] comm = { "L", "M", "L", "M", "L", "M", "L", "M", "X" };
            MarsRover.Rover r1 = new MarsRover.Rover(cPos, comm);

            Assert.That(r1.ErrCode == 0, r1.ErrDesc);
        }
        [Test]
        public void PDFTestCase1()
        {
            string[] cPos = { "1", "2", "N" };
            string[] comm = { "L", "M", "L", "M", "L", "M", "L", "M", "M" };
            string[] result = { "1", "3", "N" };
            MarsRover.Rover r1 = new MarsRover.Rover(cPos, comm);

            Assert.AreEqual(r1.NewPosition, result);
        }
        [Test]
        public void PDFTestCase2()
        {
            string[] cPos = { "3", "3", "E" };            
            string[] comm = { "M", "M", "R", "M", "M", "R", "M", "R", "R","M" };
            string[] result = { "5", "1", "E" };
            MarsRover.Rover r1 = new MarsRover.Rover(cPos, comm);

            Assert.AreEqual(r1.NewPosition, result);
        }
    }
}