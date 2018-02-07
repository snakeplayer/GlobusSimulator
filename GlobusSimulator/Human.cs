/*
 * Authors : Baptiste COUDRAY, Benoit CHAUCHE
 * Enterprise : CFPTI, T.IS-E2
 * Date : 31.01.2018
 * Project : GlobusSimulator
 * Project desc. : A simulated Globus shop
 * Class : Human.cs
 * Class desc. : Represents a human being
 */
using System;
using System.Drawing;
using System.Timers;

namespace GlobusSimulator
{
    public class Human : Object
    {
        #region Consts

        private const int DEFAULT_WIDTH = 10;
        private const int DEFAULT_HEIGHT = 10;
        private const int DEFAULT_POSITION_X = 0;
        private const int DEFAULT_POSITION_Y = 0;
        private const int DEFAULT_TIME_TO_STAY_MS = 20000;
        private const int DEFAULT_DIVIDE_TIME = 500;

        #endregion

        #region Fields

        private int _numberOfItems;

        #endregion

        #region Properties

        public Rectangle Shape { get; set; }
        public Color Color { get; set; }

        public int TimeToStayInMilliseconds { get; set; }
        public Timer Timer { get; set; }

        public int NumberOfItemsToBuy {
            get {
                return TimeToStayInMilliseconds / DEFAULT_DIVIDE_TIME;
            }
        }

        public int NumberOfItems {
            get {
                return _numberOfItems;
            }
            set {
                _numberOfItems = value < 0 ? 0 : value;
            }
        }

        public GlobusShop GlobusShop { get; set; }

        #endregion

        #region Constructors

        public Human(GlobusShop pGlobusShop) : this(DEFAULT_POSITION_X, DEFAULT_POSITION_Y, Color.FromArgb(0, 255, 255, 255), DEFAULT_TIME_TO_STAY_MS, pGlobusShop) { }

        public Human(int pPositionX, int pPositionY, Color pColor, int pTimeToStayInMilliseconds, GlobusShop pGlobusShop) : this(new Point(pPositionX, pPositionY), pColor, pTimeToStayInMilliseconds, pGlobusShop) { }

        // Will be the most used in the project
        public Human(Point pPoint, Color pColor, int pTimeToStayInMilliseconds, GlobusShop pGlobusShop) : this(pPoint, new Size(DEFAULT_WIDTH, DEFAULT_HEIGHT), pColor, pTimeToStayInMilliseconds, pGlobusShop) { }

        public Human(int pPositionX, int pPositionY, int pSizeWidth, int pSizeHeight, Color pColor, int pTimeToStayInMilliseconds, GlobusShop pGlobusShop) 
            : this(new Point(pPositionX, pPositionY), new Size(pSizeWidth, pSizeHeight), pColor, pTimeToStayInMilliseconds, pGlobusShop) { }

        public Human(Point pPoint, Size pSize, Color pColor, int pTimeToStayInMilliseconds, GlobusShop pGlobusShop)
        {
            Point p = pPoint;
            Size s = pSize;

            this.Shape = new Rectangle(p, s);
            this.Color = pColor;

            this.TimeToStayInMilliseconds = pTimeToStayInMilliseconds;

            this.Timer = new Timer(this.TimeToStayInMilliseconds);
            this.Timer.Elapsed += TimeInShop_Elapsed;

            this.NumberOfItems = 0;

            this.GlobusShop = pGlobusShop;
        }

        #endregion

        #region Methods

        private void TimeInShop_Elapsed(object sender, ElapsedEventArgs e)
        {
            // TODO
        }

        public void StartTimer()
        {
            this.Timer.Start();
        }

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
