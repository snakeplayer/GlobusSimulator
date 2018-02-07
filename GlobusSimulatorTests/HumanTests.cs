/*
 * Authors : Baptiste COUDRAY, Benoit CHAUCHE
 * Enterprise : CFPTI, T.IS-E2
 * Date : 07.02.2018
 * Project : GlobusSimulator
 * Project desc. : A simulated Globus shop
 * Class : HumanTests.cs
 * Class desc. : Represents a human being - UNIT TESTS CLASS
 */
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GlobusSimulator;
using FluentAssertions;
using Moq;

namespace GlobusSimulatorTests
{
    [TestClass()]
    public class HumanTests
    {
        [TestMethod()]
        public void HumanCtorTest1()
        {
            Mock<Path> mockPath = new Mock<Path>();
            Mock<GlobusShop> mockShop = new Mock<GlobusShop>(mockPath.Object);
            Human target = new Human(mockShop.Object);

            target.Should().NotBeNull();
            target.Shape.Should().NotBeNull();
            target.Color.Should().NotBeNull();
            target.TimeToStayInMilliseconds.Should().Be(20000);
            target.NumberOfItemsToBuy.Should().Be(40);
            target.NumberOfItems.Should().Be(0);
        }

        [TestMethod()]
        public void HumanAddItemTest1()
        {
            Mock<Path> mockPath = new Mock<Path>();
            Mock<GlobusShop> mockShop = new Mock<GlobusShop>(mockPath.Object);
            Human target = new Human(mockShop.Object);

            target.AddItem();

            target.NumberOfItems.Should().Be(1);
        }

        [TestMethod()]
        public void HumanRemoveItemTest1()
        {
            Mock<Path> mockPath = new Mock<Path>();
            Mock<GlobusShop> mockShop = new Mock<GlobusShop>(mockPath.Object);
            Human target = new Human(mockShop.Object);

            bool wasRemoved = target.RemoveItem();

            wasRemoved.Should().BeFalse();
            target.NumberOfItems.Should().Be(0);
        }

        [TestMethod()]
        public void HumanRemoveItemTest2()
        {
            Mock<Path> mockPath = new Mock<Path>();
            Mock<GlobusShop> mockShop = new Mock<GlobusShop>(mockPath.Object);
            Human target = new Human(mockShop.Object);

            target.AddItem();
            bool wasRemoved = target.RemoveItem();

            wasRemoved.Should().BeTrue();
            target.NumberOfItems.Should().Be(0);
        }
    }
}
