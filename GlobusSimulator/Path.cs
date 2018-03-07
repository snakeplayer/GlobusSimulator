/*
 * Authors : Baptiste COUDRAY, Benoit CHAUCHE
 * Enterprise : CFPTI, T.IS-E2
 * Date : 31.01.2018
 * Project : GlobusSimulator
 * Project desc. : A simulated Globus shop
 * Class : Path.cs
 * Class desc. : Reprensents a path
 */
using System.Collections.Generic;
using System.Drawing;

namespace GlobusSimulator
{
    public class Path
    {
        #region Consts

        #endregion

        #region Fields
        private List<Point> _points;
        #endregion

        #region Properties
        public List<Point> Points { get => _points; private set => _points = value ?? new List<Point>(); }
        public int NumberOfPoints { get => this.Points.Count; }
        #endregion

        #region Constructors
        public Path() : this(new List<Point>())
        {
            // no code
        }

        public Path(List<Point> points)
        {
            this.Points = new List<Point>(points);
        }
        #endregion

        #region Methods
        public void AddPoint(Point point)
        {
            this.Points.Add(point);
        }

        public void AddPoints(List<Point> points)
        {
            this.Points.AddRange(points);
        }

        public void RemovePoint(Point point)
        {
            this.Points.Remove(point);
        }

        public void RemovePoints(List<Point> points)
        {
            points.ForEach(p => this.Points.Remove(p));
        }

        public void RemoveAllPoints()
        {
            this.Points.Clear();
        }
        #endregion
    }
}
