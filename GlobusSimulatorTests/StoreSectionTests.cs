using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using System.Drawing;

namespace GlobusSimulator.Tests
{
    [TestClass()]
    public class StoreSectionTests
    {
        [TestMethod()]
        public void StoreSectionTest()
        {
            Point location = new Point(15, 25);
            Size size = new Size(45, 50);
            Rectangle shape = new Rectangle(location, size);
            StoreSection target = new StoreSection(shape, Color.Red);
            target.Shape.Should().Be(shape);
            target.Color.Should().Be(Color.Red);
        }

        [TestMethod()]
        public void StoreSectionTest1()
        {
            Point location = new Point(15, 25);
            Size size = new Size(45, 50);
            StoreSection target = new StoreSection(location, size);
            target.Shape.Location.Should().Be(location);
            target.Shape.Size.Should().Be(size);
        }

        [TestMethod()]
        public void StoreSectionTest2()
        {
            Size size = new Size(45, 50);
            StoreSection target = new StoreSection(size);
            target.Shape.Size.Should().Be(size);
        }

        [TestMethod()]
        public void StoreSectionTest3()
        {
            StoreSection target = new StoreSection(15, 10);
            target.Shape.Size.Width.Should().Be(15);
            target.Shape.Size.Height.Should().Be(10);
        }

        [TestMethod()]
        public void StoreSectionTest4()
        {
            StoreSection target = new StoreSection(10, 15, 50, 40);
            target.Shape.X.Should().Be(10);
            target.Shape.Y.Should().Be(15);
            target.Shape.Width.Should().Be(50);
            target.Shape.Height.Should().Be(40);
        }
    }
}