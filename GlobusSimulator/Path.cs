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
using System.Linq;

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
        public Point Start { get => this.NumberOfPoints > 0 ? this.Points[0] : Point.Empty; }
        public Point End { get => this.NumberOfPoints > 0 ? this.Points.Last() : Point.Empty; }
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="Path"/> class.
        /// </summary>
        public Path() : this(new List<Point>())
        {
            // no code
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Path"/> class.
        /// </summary>
        /// <param name="points">The points.</param>
        public Path(List<Point> points)
        {
            this.Points = new List<Point>(points);
        }
        #endregion

        #region Methods
        /// <summary>
        /// Adds the point.
        /// </summary>
        /// <param name="point">The point.</param>
        public void AddPoint(Point point)
        {
            this.Points.Add(point);
        }

        /// <summary>
        /// Adds the points.
        /// </summary>
        /// <param name="points">The points.</param>
        public void AddPoints(List<Point> points)
        {
            this.Points.AddRange(points);
        }

        /// <summary>
        /// Removes the point.
        /// </summary>
        /// <param name="point">The point.</param>
        public void RemovePoint(Point point)
        {
            this.Points.Remove(point);
        }

        /// <summary>
        /// Removes the points.
        /// </summary>
        /// <param name="points">The points.</param>
        public void RemovePoints(List<Point> points)
        {
            points.ForEach(p => this.Points.Remove(p));
        }

        /// <summary>
        /// Removes all points.
        /// </summary>
        public void RemoveAllPoints()
        {
            this.Points.Clear();
        }
        #endregion
    }
}
