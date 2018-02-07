/*
 * Authors : Baptiste COUDRAY, Benoit CHAUCHE
 * Enterprise : CFPTI, T.IS-E2
 * Date : 07.02.2018
 * Project : GlobusSimulator
 * Project desc. : A simulated Globus shop
 * Class : PathTests.cs
 * Class desc. : Represents a path - UNIT TESTS CLASS
 */
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using System.Collections.Generic;
using System.Drawing;

namespace GlobusSimulator.Tests
{
    [TestClass()]
    public class PathTests
    {
        [TestMethod()]
        public void PathTest()
        {
            Path target = new Path();
            target.Points.Should().NotBeNull();
        }

        [TestMethod()]
        public void PathTest1()
        {
            List<Point> points = new List<Point>()
            {
                new Point(10, 10)
            };
            Path target = new Path(points);
            target.Points.Should().Contain(points);
        }

        [TestMethod()]
        public void AddPointTest()
        {
            Point point = new Point(10, 10);
            Path target = new Path();
            target.AddPoint(point);
            target.Points.Should().Contain(point);
        }

        [TestMethod()]
        public void AddPointsTest()
        {
            List<Point> points = new List<Point>()
            {
                new Point(15,15),
                new Point(30,30)
            };
            Path target = new Path();
            target.AddPoints(points);
            target.Points.Should().Contain(points);
        }

        [TestMethod()]
        public void RemovePointTest()
        {
            Point point = new Point(10, 10);
            Path target = new Path();
            target.AddPoint(point);
            target.Points.Should().Contain(point);
            target.RemovePoint(point);
            target.Points.Should().NotContain(point);
        }

        [TestMethod()]
        public void RemovePointsTest()
        {
            List<Point> points = new List<Point>()
            {
                new Point(15,15),
                new Point(30,30)
            };
            Path target = new Path();
            target.AddPoints(points);
            target.RemovePoints(points);
            target.Points.Should().NotContain(points);
        }
    }
}