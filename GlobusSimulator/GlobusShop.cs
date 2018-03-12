/*
 * Authors : Baptiste COUDRAY, Benoit CHAUCHE
 * Enterprise : CFPTI, T.IS-E2
 * Date : 07.02.2018
 * Project : GlobusSimulator
 * Project desc. : A simulated Globus shop
 * Class : GlobusShop.cs
 * Class desc. : Reprensents a Globus shop
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;

namespace GlobusSimulator
{
    public class GlobusShop : Shop
    {
        #region Consts
        private const int DEFAULT_TIMER_INTERVAL = 15; // 60 FPS - PC MASTER RACE
        #endregion

        #region Fields
        private List<Human> _humans;
        private System.Timers.Timer _timer;
        private FormGlobusView _view;
        #endregion

        #region Properties
        public List<Human> Humans { get => _humans; private set => _humans = value ?? new List<Human>(); }
        private System.Timers.Timer Timer { get => _timer; set => _timer = value ?? new System.Timers.Timer(GlobusShop.DEFAULT_TIMER_INTERVAL); }
        private FormGlobusView Observer { get => _view; set => _view = value ?? throw new ArgumentNullException("Observer", "Observer cannot be null."); }
        #endregion

        #region Constructors
        public GlobusShop(List<StoreSection> storeSections, List<Checkout> checkouts, Path path, FormGlobusView observer, List<Human> humans) : base(storeSections, checkouts, path)
        {
            this.Humans = humans;
            this.Observer = observer;
            this.Timer = new System.Timers.Timer(GlobusShop.DEFAULT_TIMER_INTERVAL);
            this.Timer.Elapsed += Timer_Elapsed;
            this.Observer.Notify();
        }

        public GlobusShop(GlobusShopEditor editor, FormGlobusView observer) : this(editor.StoreSections, editor.Checkouts, editor.Path, observer, new List<Human>())
        {
            // no code
        }

        public GlobusShop(FormGlobusView observer) : this(new List<StoreSection>(), new List<Checkout>(), new Path(), observer, new List<Human>())
        {
            // no code
        }
        #endregion

        #region Methods
        public void PlaceHumanFromPathToCheckout(Human human)
        {
            if (this.Humans.Contains(human))
            {
                this.Humans.Remove(human);
                bool isAllCheckoutsFull = true;
                foreach (Checkout c in this.Checkouts)
                {
                    if (c.NumberOfHumans < c.MaxNumberOfHumans)
                    {
                        c.AddHuman(human);
                        isAllCheckoutsFull = false;
                    }
                }
                if (isAllCheckoutsFull)
                {
                    //
                }
            }
        }

        public void Simulate(int numberOfSlowHumans, int numberOfMediumHumans, int numberOfFastHumans)
        {
            this.AddHumans(numberOfSlowHumans, SlowHumanType.CreateInstance());
            this.AddHumans(numberOfMediumHumans, MediumHumanType.CreateInstance());
            this.AddHumans(numberOfFastHumans, FastHumanType.CreateInstance());
            this.Humans.ForEach(h => h.Move());
            this.Timer.Start();
        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            this.Observer.Notify();
        }

        private void AddHumans(int number, HumanType humanType)
        {
            for (int i = 0; i < number; i++)
            {
                this.Humans.Add(new Human(this.Path.Points[0], humanType, this.Path));
            }
        }
        #endregion
    }
}
