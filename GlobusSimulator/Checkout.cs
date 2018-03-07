/*
 * Authors : Baptiste COUDRAY, Benoit CHAUCHE
 * Enterprise : CFPTI, T.IS-E2
 * Date : 31.01.2018
 * Project : GlobusSimulator
 * Project desc. : A simulated Globus shop
 * Class : Checkout.cs
 * Class desc. : Reprensents a checkout
 */
using System.Collections.Generic;
using System.Drawing;

namespace GlobusSimulator
{
    public class Checkout
    {
        #region Consts
        private const int DEFAULT_WIDTH = 25;
        private const int DEFAULT_HEIGHT = 10;
        private static readonly Color DEFAULT_COLOR = Color.Blue;
        private const int DEFAULT_MAX_NUMBER_OF_HUMANS = 5;
        #endregion

        #region Fields
        private Queue<Human> _queuLine;
        #endregion

        #region Properties
        public Rectangle Shape { get; private set; }
        private Queue<Human> QueueLine { get => _queuLine; set => _queuLine = value ?? new Queue<Human>(); }
        public int NumberOfHumans { get => this.QueueLine.Count; }
        public int MaxNumberOfHumans { get; private set; }
        public Color Color { get; private set; }
        public bool IsOpened { get; private set; }
        #endregion

        #region Constructors
        public Checkout(Rectangle shape, Color color, int maxNumberOfHumans)
        {
            this.Shape = shape;
            this.MaxNumberOfHumans = maxNumberOfHumans;
            this.QueueLine = new Queue<Human>(this.MaxNumberOfHumans);
            this.Color = color;
            this.IsOpened = false;
        }

        public Checkout(Point location) : this(location, new Size(DEFAULT_WIDTH, DEFAULT_HEIGHT))
        {

        }

        public Checkout(Point location, Size size) : this(new Rectangle(location, size), Checkout.DEFAULT_COLOR, Checkout.DEFAULT_MAX_NUMBER_OF_HUMANS)
        {
            // no code
        }

        public Checkout(int x, int y, int width, int height) : this(new Point(x, y), new Size(width, height))
        {
            // no code
        }

        public Checkout(int x, int y) : this(x, y, Checkout.DEFAULT_WIDTH, Checkout.DEFAULT_HEIGHT)
        {
            // no code
        }

        public Checkout(Point location) : this(location.X, location.Y)
        {
            // no code
        }
        #endregion

        #region Methods
        public void AddHuman(Human human)
        {
            this.QueueLine.Enqueue(human);
        }

        public Human CashOut()
        {
            return this.QueueLine.Dequeue();
        }

        public void Open()
        {
            this.IsOpened = false;
        }

        public void Close()
        {
            this.IsOpened = true;
        }
        #endregion
    }
}
