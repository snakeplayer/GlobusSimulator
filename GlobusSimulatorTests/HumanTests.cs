/*
 * Authors : Baptiste COUDRAY, Benoit CHAUCHE
 * Enterprise : CFPTI, T.IS-E2
 * Date : 07.02.2018
 * Project : GlobusSimulator
 * Project desc. : A simulated Globus shop
 * Class : HumanTests.cs
 * Class desc. : Represents a human being - UNIT TESTS CLASS
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GlobusSimulator;
using System.Drawing;
using FluentAssertions;

namespace GlobusSimulatorTests
{
    [TestClass()]
    public class HumanTests
    {
        [TestMethod()]
        public void HumanCtorTest1()
        {
            Human target = new Human();

            target.Should().NotBeNull();
            target.Shape.Should().NotBeNull();
            target.NumberOfItems.Should().Be(0);
        }

        [TestMethod()]
        public void HumanAddItemTest1()
        {
            Human target = new Human();

            target.AddItem();

            target.NumberOfItems.Should().Be(1);
        }

        [TestMethod()]
        public void HumanRemoveItemTest1()
        {
            Human target = new Human();

            bool wasRemoved = target.RemoveItem();

            wasRemoved.Should().BeFalse();
            target.NumberOfItems.Should().Be(0);
        }

        [TestMethod()]
        public void HumanRemoveItemTest2()
        {
            Human target = new Human();

            target.AddItem();
            bool wasRemoved = target.RemoveItem();

            wasRemoved.Should().BeTrue();
            target.NumberOfItems.Should().Be(0);
        }
    }
}
