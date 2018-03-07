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
using System.Linq;
using System.Timers;

namespace GlobusSimulator
{
    public class Human : Object
    {
        #region Consts

        private const int DEFAULT_WIDTH = 15;
        private const int DEFAULT_HEIGHT = 15;
        private const int DEFAULT_POSITION_X = 0;
        private const int DEFAULT_POSITION_Y = 0;
        private const int DEFAULT_TIME_TO_STAY_MS = 20000;
        private const int DEFAULT_DIVIDE_TIME = 500;

        #endregion

        #region Fields
        private int _numberOfItems;
        private Timer _timer;
        private Path _path;
        #endregion

        #region Properties
        public Rectangle Shape { get; set; }

        public Color Color { get; set; }

        public int TimeToStayInMilliseconds { get; private set; }

        private Timer Timer { get => _timer; set => _timer = value ?? throw new ArgumentNullException("Timer", "Timer cannot be null."); }

        public int NumberOfItemsToBuy
        {
            get
            {
                return TimeToStayInMilliseconds / DEFAULT_DIVIDE_TIME;
            }
        }

        public int NumberOfItems
        {
            get
            {
                return _numberOfItems;
            }
            private set
            {
                _numberOfItems = value < 0 ? 0 : value;
            }
        }

        public Path Path { get => _path; private set => _path = value ?? new Path(); }
        #endregion

        #region Constructors

        public Human() : this(DEFAULT_POSITION_X, DEFAULT_POSITION_Y, Color.FromArgb(0, 255, 255, 255), DEFAULT_TIME_TO_STAY_MS) { }

        public Human(int pPositionX, int pPositionY, Color pColor, int pTimeToStayInMilliseconds) : this(new Point(pPositionX, pPositionY), pColor, pTimeToStayInMilliseconds) { }

        // Will be the most used in the project
        public Human(Point pPoint, Color pColor, int pTimeToStayInMilliseconds) : this(pPoint, new Size(DEFAULT_WIDTH, DEFAULT_HEIGHT), pColor, pTimeToStayInMilliseconds) { }

        public Human(int pPositionX, int pPositionY, int pSizeWidth, int pSizeHeight, Color pColor, int pTimeToStayInMilliseconds)
            : this(new Point(pPositionX, pPositionY), new Size(pSizeWidth, pSizeHeight), pColor, pTimeToStayInMilliseconds) { }

        public Human(Point pPoint, Size pSize, Color pColor, int pTimeToStayInMilliseconds)
        {
            this.Shape = new Rectangle(pPoint, pSize);
            this.Color = pColor;

            this.TimeToStayInMilliseconds = pTimeToStayInMilliseconds;

            this.Timer = new Timer(this.TimeToStayInMilliseconds);
            this.Timer.Elapsed += TimeInShop_Elapsed;

            this.NumberOfItems = 0;
        }

        #endregion

        #region Methods
        public void Move()
        {
            this.Timer.Start();
        }

        private void TimeInShop_Elapsed(object sender, ElapsedEventArgs e)
        {
            int index = this.Path.Points.FindIndex(p => p == this.Shape.Location);
            Point nextPoint = ++index < this.Path.NumberOfPoints ? this.Path.Points[index++] : this.Path.Points.Last();
            this.Shape = new Rectangle(nextPoint, this.Shape.Size);
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
