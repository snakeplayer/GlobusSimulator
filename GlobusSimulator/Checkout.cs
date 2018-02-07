/*
 * Authors : Baptiste COUDRAY, Benoit CHAUCHE
 * Enterprise : CFPTI, T.IS-E2
 * Date : 31.01.2018
 * Project : GlobusSimulator
 * Project desc. : A simulated Globus shop
 * Class : Checkout.cs
 * Class desc. : Reprensents a checkout
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobusSimulator
{
    public class Checkout
    {
        #region Consts
        private const int DEFAULT_WIDTH = 25;
        private const int DEFAULT_HEIGHT = 10;
        #endregion

        #region Fields
        private Queue<Human> _queuLine;
        #endregion

        #region Properties
        public Rectangle Shape { get; private set; }
        private Queue<Human> QueueLine { get => _queuLine; set => _queuLine = value ?? new Queue<Human>(); }
        public int NbOfHumans { get => this.QueueLine.Count; }
        #endregion

        #region Constructors
        public Checkout(Rectangle shape)
        {
            this.Shape = shape;
            this.QueueLine = new Queue<Human>();
        }

        public Checkout(Point location, Size size) : this(new Rectangle(location, size))
        {
            // no code
        }

        public Checkout(int x, int y, int width, int height) : this(new Point(x, y), new Size(width, height))
        {
            // no code
        }

        public Checkout(Size size) : this(Checkout.DEFAULT_WIDTH, Checkout.DEFAULT_HEIGHT, size.Width, size.Height)
        {
            // no code
        }

        public Checkout(int width, int height) : this(new Size(width, height))
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
        #endregion
    }
}
