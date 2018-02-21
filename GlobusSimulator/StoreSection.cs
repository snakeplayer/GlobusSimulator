/*
 * Authors : Baptiste COUDRAY, Benoit CHAUCHE
 * Enterprise : CFPTI, T.IS-E2
 * Date : 31.01.2018
 * Project : GlobusSimulator
 * Project desc. : A simulated Globus shop
 * Class : StoreSection.cs
 * Class desc. : Reprensents a store section
 */
using System.Drawing;

namespace GlobusSimulator
{
    public class StoreSection
    {
        #region Consts
        private const int DEFAULT_WIDTH = 25;
        private const int DEFAULT_HEIGHT = 10;
        private static readonly Color DEFAULT_COLOR = Color.Blue;
        #endregion

        #region Fields
        #endregion

        #region Properties
        public Rectangle Shape { get; private set; }
        public Color Color { get; private set; }
        #endregion

        #region Constructors
        public StoreSection(Rectangle shape, Color color)
        {
            this.Shape = shape;
            this.Color = color;
        }

        public StoreSection(Point location, Size size) : this(new Rectangle(location, size), StoreSection.DEFAULT_COLOR)
        {
            // no code
        }

        public StoreSection(int x, int y, int width, int height) : this(new Point(x, y), new Size(width, height))
        {
            // no code
        }

        public StoreSection(int x, int y) : this(x,y,StoreSection.DEFAULT_WIDTH, StoreSection.DEFAULT_HEIGHT)
        {
            // no code
        }

        public StoreSection(Point location) : this(location.X, location.Y)
        {
            // no code
        }
        #endregion
    }
}
