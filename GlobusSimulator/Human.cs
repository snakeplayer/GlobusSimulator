/*
 * Authors : Baptiste COUDRAY, Benoit CHAUCHE
 * Enterprise : CFPTI, T.IS-E2
 * Date : 31.01.2018
 * Project : GlobusSimulator
 * Project desc. : A simulated Globus shop
 * Class : Human.cs
 * Class desc. : Reprensents a human being
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobusSimulator
{
    public class Human : Object
    {
        #region Consts

        private const int DEFAULT_WIDTH = 10;
        private const int DEFAULT_HEIGHT = 10;
        private const int DEFAULT_POSITION_X = 0;
        private const int DEFAULT_POSITION_Y = 0;

        #endregion

        #region Fields

        private int _numberOfItems;

        #endregion

        #region Properties

        public Rectangle Shape { get; set; }
        public int NumberOfItems {
            get {
                return _numberOfItems;
            }
            set {
                _numberOfItems = value < 0 ? 0 : value;
            }
        }

        #endregion

        #region Constructors

        public Human() : this(DEFAULT_POSITION_X, DEFAULT_POSITION_Y) { }

        public Human(int pPositionX, int pPositionY) : this(new Point(pPositionX, pPositionY)) { }

        public Human(Point pPoint) : this(pPoint, new Size(DEFAULT_WIDTH, DEFAULT_HEIGHT)) { }

        public Human(int pPositionX, int pPositionY, int pSizeWidth, int pSizeHeight) 
            : this(new Point(pPositionX, pPositionY), new Size(pSizeWidth, pSizeHeight)) { }

        public Human(Point pPoint, Size pSize)
        {
            Point p = pPoint;
            Size s = pSize;

            this.Shape = new Rectangle(p, s);
            this.NumberOfItems = 0;
        }

        #endregion

        #region Methods

        public void AddItem()
        {
            this.NumberOfItems++;
        }

        public bool RemoveItem()
        {
            bool wasRemoved = false;

            if (this.NumberOfItems > 0)
            {
                this.NumberOfItems--;
                wasRemoved = true;
            }

            return wasRemoved;
        }

        #endregion
    }
}
