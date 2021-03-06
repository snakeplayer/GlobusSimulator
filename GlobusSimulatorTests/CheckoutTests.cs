﻿/*
 * Authors : Baptiste COUDRAY, Benoit CHAUCHE
 * Enterprise : CFPTI, T.IS-E2
 * Date : 07.02.2018
 * Project : GlobusSimulator
 * Project desc. : A simulated Globus shop
 * Class : CheckoutTests.cs
 * Class desc. : Represents a checkout - UNIT TESTS CLASS
 */
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
            Checkout target = new Checkout(shape, Color.Red, 10);
            target.Shape.Should().Be(shape);
            target.Color.Should().Be(Color.Red);
            target.MaxNumberOfHumans.Should().Be(10);
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
            Mock<Path> mockPath = new Mock<Path>();
            Mock<Human> human = new Mock<Human>();
            Checkout target = new Checkout(new Size(15, 25));
            target.AddHuman(human.Object);
            target.NumberOfHumans.Should().Be(1);
        }

        [TestMethod()]
        public void CashOutTest()
        {
            Mock<Path> mockPath = new Mock<Path>();
            Mock<Human> human = new Mock<Human>();
            Checkout target = new Checkout(new Size(15, 25));
            target.AddHuman(human.Object);
            target.CashOut().Should().Be(human.Object);
            target.NumberOfHumans.Should().Be(0);
        }

        [TestMethod()]
        public void CashOutTest1()
        {
            Mock<Path> mockPath = new Mock<Path>();
            Mock<Human> human = new Mock<Human>();
            Checkout target = new Checkout(new Size(15, 25));
            target.AddHuman(human.Object);
            target.CashOut().Should().Be(human.Object);
            target.NumberOfHumans.Should().Be(0);
        }

        [TestMethod()]
        public void CashOutTest2()
        {
            Mock<Path> mockPath = new Mock<Path>();
            Mock<GlobusShop> mockShop = new Mock<GlobusShop>(mockPath.Object);
            Mock<Human> human = new Mock<Human>();
            Mock<Human> human1 = new Mock<Human>();
            Checkout target = new Checkout(new Size(15, 25));
            target.AddHuman(human.Object);
            target.AddHuman(human1.Object);
            target.CashOut().Should().Be(human.Object);
            target.NumberOfHumans.Should().Be(1);
        }
    }
}