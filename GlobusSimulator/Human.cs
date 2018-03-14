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
    public class Human : Object, ICloneable
    {
        #region Consts
        private const int DEFAULT_WIDTH = 15;
        private const int DEFAULT_HEIGHT = 15;
        private const bool DEFAULT_IS_MOVING = false;
        #endregion

        #region Fields
        private Timer _timer;
        private HumanType _type;
        private Path _path;
        #endregion

        #region Properties
        public Rectangle Shape { get; set; }
        private Timer Timer { get => _timer; set => _timer = value ?? throw new ArgumentNullException("Timer", "Timer cannot be null."); }
        public HumanType Type { get => _type; set => _type = value ?? MediumHumanType.CreateInstance(); }
        public Path Path { get => _path; private set => _path = value ?? new Path(); }
        public bool IsArrived { get => this.Shape.Location == this.Path.End; }
        #endregion

        #region Constructors
        public Human(Point location, Size size, HumanType humanType, Path path, Timer timer)
        {
            this.Shape = new Rectangle(location, size);
            this.Type = humanType;
            this.Path = path;
            this.Timer = timer ?? new Timer(this.Type.Speed);
            this.Timer.Elapsed += Timer_Elapsed;
             this.Move();
        }

        public Human(Point location, HumanType humanType, Path path) : this(location, new Size(Human.DEFAULT_WIDTH, Human.DEFAULT_HEIGHT), humanType, path, null)
        {
            // no code
        }
        #endregion

        #region Methods

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            int index = this.Path.Points.FindIndex(p => p == this.Shape.Location);
            Point nextPoint = ++index < this.Path.NumberOfPoints ? this.Path.Points[index] : this.Path.End;
            this.Shape = new Rectangle(nextPoint, this.Shape.Size);
        }

        public void Move()
        {
            this.Timer.Start();
        }

        public void Exit()
        {
            this.Timer.Stop();
        }

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
