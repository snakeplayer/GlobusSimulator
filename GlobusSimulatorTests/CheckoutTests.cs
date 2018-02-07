using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using FluentAssertions;
using System.Drawing;

namespace GlobusSimulator.Tests
{
    [TestClass()]
    public class CheckoutTests
    {
        [TestMethod()]
        public void CheckoutCtorTest()
        {
            Point location = new Point(15, 25);
            Size size = new Size(45, 50);
            Rectangle shape = new Rectangle(location, size);
            Checkout target = new Checkout(shape, Color.Red);
            target.Shape.Should().Be(shape);
            target.Color.Should().Be(Color.Red);
        }

        [TestMethod()]
        public void CheckoutCtorTest1()
        {
            Point location = new Point(15, 25);
            Size size = new Size(45, 50);
            Checkout target = new Checkout(location, size);
            target.Shape.Location.Should().Be(location);
            target.Shape.Size.Should().Be(size);
        }

        [TestMethod()]
        public void CheckoutCtorTest2()
        {
            Size size = new Size(45, 50);
            Checkout target = new Checkout(size);
            target.Shape.Size.Should().Be(size);
        }

        [TestMethod()]
        public void CheckoutCtorTest3()
        {
            Checkout target = new Checkout(15, 10);
            target.Shape.Size.Width.Should().Be(15);
            target.Shape.Size.Height.Should().Be(10);
        }

        [TestMethod()]
        public void CheckoutCtorTest4()
        {
            Checkout target = new Checkout(10,15,50,40);
            target.Shape.X.Should().Be(10);
            target.Shape.Y.Should().Be(15);
            target.Shape.Width.Should().Be(50);
            target.Shape.Height.Should().Be(40);
        }

        [TestMethod()]
        public void AddHumanTest()
        {
            Mock<Human> human = new Mock<Human>();
            Checkout target = new Checkout(new Size(15, 25));
            target.AddHuman(human.Object);
            target.NbOfHumans.Should().Be(1);
        }

        [TestMethod()]
        public void CashOutTest()
        {
            Mock<Human> human = new Mock<Human>();
            Checkout target = new Checkout(new Size(15, 25));
            target.AddHuman(human.Object);
            target.CashOut().Should().Be(human.Object);
            target.NbOfHumans.Should().Be(0);
        }

        [TestMethod()]
        public void CashOutTest1()
        {
            Mock<Human> human = new Mock<Human>();
            Checkout target = new Checkout(new Size(15, 25));
            target.AddHuman(human.Object);
            target.CashOut().Should().Be(human.Object);
            target.NbOfHumans.Should().Be(0);
        }

        [TestMethod()]
        public void CashOutTest2()
        {
            Mock<Human> human = new Mock<Human>();
            Mock<Human> human1 = new Mock<Human>();
            Checkout target = new Checkout(new Size(15, 25));
            target.AddHuman(human.Object);
            target.AddHuman(human1.Object);
            target.CashOut().Should().Be(human.Object);
            target.NbOfHumans.Should().Be(1);
        }
    }
}