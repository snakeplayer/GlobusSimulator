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
    public class Human : ICloneable
    {
        #region Consts
        private const int DEFAULT_WIDTH = 15;
        private const int DEFAULT_HEIGHT = 15;
        #endregion

        #region Fields
        private Timer _timer;
        private HumanType _type;
        private Path _path;
        #endregion

        #region Events
        public event EventHandler ShoppingFinished;
        #endregion

        #region Properties
        public Rectangle Shape { get; set; }
        private Timer Timer { get => _timer; set => _timer = value ?? throw new ArgumentNullException("Timer", "Timer cannot be null."); }
        public HumanType Type { get => _type; set => _type = value ?? MediumHumanType.CreateInstance(); }
        public Path Path { get => _path; private set => _path = value ?? new Path(); }
        public bool IsArrived { get => this.Shape.Location == this.Path.End; }
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="Human"/> class.
        /// </summary>
        /// <param name="location">The location.</param>
        /// <param name="size">The size.</param>
        /// <param name="humanType">Type of the human.</param>
        /// <param name="path">The path.</param>
        /// <param name="timer">The timer.</param>
        public Human(Point location, Size size, HumanType humanType, Path path, Timer timer)
        {
            this.Shape = new Rectangle(location, size);
            this.Type = humanType;
            this.Path = path;
            this.Timer = timer ?? new Timer(this.Type.Speed);
            this.Timer.Elapsed += Timer_Elapsed;
            this.Move();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Human"/> class.
        /// </summary>
        /// <param name="location">The location.</param>
        /// <param name="humanType">Type of the human.</param>
        /// <param name="path">The path.</param>
        public Human(Point location, HumanType humanType, Path path) : this(location, new Size(Human.DEFAULT_WIDTH, Human.DEFAULT_HEIGHT), humanType, path, null)
        {
            // no code
        }
        #endregion

        #region Methods
        /// <summary>
        /// Handles the Elapsed event of the Timer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ElapsedEventArgs"/> instance containing the event data.</param>
        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            int index = this.Path.Points.FindIndex(p => p == this.Shape.Location);
            Point nextPoint = ++index < this.Path.NumberOfPoints ? this.Path.Points[index] : this.Path.End;
            this.Shape = new Rectangle(nextPoint, this.Shape.Size);
            if (nextPoint == this.Path.End)
            {
                this.OnShoppingFinished(this, EventArgs.Empty); // The human has arrived to the last point of the path so we trigger the event that he has finished his shopping
                this.Timer.Stop(); // The human stop to move
            }
        }

        /// <summary>
        /// Moves thê human.
        /// </summary>
        public void Move()
        {
            this.Timer.Start();
        }

        /// <summary>
        /// Relocates the human.
        /// </summary>
        /// <param name="position">The position.</param>
        public void Relocate(Point position)
        {
            this.Shape = new Rectangle(position, this.Shape.Size);
        }

        /// <summary>
        /// Called when [shopping finished].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void OnShoppingFinished(object sender, EventArgs e)
        {
            this.ShoppingFinished?.Invoke(sender, e);
        }

        /// <summary>
        /// Creates an object that is a copy of the current instance.
        /// </summary>
        /// <returns>
        /// New object that is a copy of this instance.
        /// </returns>
        public object Clone()
        {
            return new Human(
                new Point(this.Shape.X, this.Shape.Y),
                new Size(this.Shape.Width, this.Shape.Height),
                this.Type, this.Path, this.Timer);
        }
        #endregion
    }
}
