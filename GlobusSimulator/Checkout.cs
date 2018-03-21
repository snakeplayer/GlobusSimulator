/*
 * Authors : Baptiste COUDRAY, Benoit CHAUCHE
 * Enterprise : CFPTI, T.IS-E2
 * Date : 31.01.2018
 * Project : GlobusSimulator
 * Project desc. : A simulated Globus shop
 * Class : Checkout.cs
 * Class desc. : Represents a checkout
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;

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

        #region Events
        public event EventHandler<HumanEventArgs> HumanEnqueue;
        public event EventHandler<HumanEventArgs> HumanCashOut;
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
        public bool IsFull { get => this.NumberOfHumans == this.MaxNumberOfHumans; }
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="Checkout"/> class.
        /// </summary>
        /// <param name="shape">The shape.</param>
        /// <param name="color">The color.</param>
        /// <param name="maxNumberOfHumans">The maximum number of humans.</param>
        public Checkout(Rectangle shape, Color color, int maxNumberOfHumans)
        {
            this.Shape = shape;
            this.MaxNumberOfHumans = maxNumberOfHumans;
            this.QueueLine = new Queue<Human>(this.MaxNumberOfHumans);
            this.Color = color;
            this.IsOpened = false;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Checkout"/> class.
        /// </summary>
        /// <param name="location">The location.</param>
        public Checkout(Point location) : this(location, new Size(DEFAULT_WIDTH, DEFAULT_HEIGHT))
        {
            // no code
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Checkout"/> class.
        /// </summary>
        /// <param name="location">The location.</param>
        /// <param name="size">The size.</param>
        public Checkout(Point location, Size size) : this(new Rectangle(location, size), Checkout.DEFAULT_COLOR, Checkout.DEFAULT_MAX_NUMBER_OF_HUMANS)
        {
            // no code
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Checkout"/> class.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        public Checkout(int x, int y, int width, int height) : this(new Point(x, y), new Size(width, height))
        {
            // no code
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Checkout"/> class.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        public Checkout(int x, int y) : this(x, y, Checkout.DEFAULT_WIDTH, Checkout.DEFAULT_HEIGHT)
        {
            // no code
        }
        #endregion

        #region Methods
        /// <summary>
        /// Enqueues the specified human.
        /// </summary>
        /// <param name="human">The human.</param>
        /// <returns>True if enqueued, otherwise false</returns>
        public bool Enqueue(Human human)
        {
            bool isEnqueue = false;
            try
            {
                if (!this.IsFull)
                {
                    this.QueueLine.Enqueue(human); // We add the human to the queue
                    isEnqueue = true;
                    this.OnHumanEnqueue(this, new HumanEventArgs(human)); // We trigger the event to notify that a human has been add to the queue
                }
            }
            catch
            {
                isEnqueue = false;
            }
            return isEnqueue;
        }

        /// <summary>
        /// Cashes ou the humans
        /// </summary>
        private async void CashOut()
        {
            await Task.Run(() =>
            {
                while (this.IsOpened)
                {
                    if (this.NumberOfHumans > 0)
                    {
                        Thread.Sleep(this.QueueLine.Peek().Type.Speed * 100); // We sleep to simulate the cash out process
                        Human human = this.QueueLine.Dequeue(); // We remove the human from the queue
                        this.OnHumanCashOut(this, new HumanEventArgs(human)); // We trigger the event to notify that a human has been cash out
                    }
                }
            }).ConfigureAwait(false);
        }

        /// <summary>
        /// Opens the checkout.
        /// </summary>
        public void Open()
        {
            this.IsOpened = true;
            this.CashOut(); // Process the cash out in background
        }

        /// <summary>
        /// Closes the checkout.
        /// </summary>
        public void Close()
        {
            this.IsOpened = false;
        }

        /// <summary>
        /// Called when [human enqueue].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="HumanEventArgs"/> instance containing the event data.</param>
        protected void OnHumanEnqueue(object sender, HumanEventArgs e)
        {
            this.HumanEnqueue?.Invoke(sender, e);
        }

        /// <summary>
        /// Called when [human cash out].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="HumanEventArgs"/> instance containing the event data.</param>
        protected void OnHumanCashOut(object sender, HumanEventArgs e)
        {
            this.HumanCashOut?.Invoke(sender, e);
        }
        #endregion
    }
}
