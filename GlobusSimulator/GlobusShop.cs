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
using System.Threading.Tasks;

namespace GlobusSimulator
{
    public class GlobusShop : Shop
    {
        private static readonly Random Random = new Random();

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
        public bool IsSimulationStarted { get => this.Timer.Enabled; }
        #endregion

        #region Constructors
        public GlobusShop(List<StoreSection> storeSections, List<Checkout> checkouts, Path path, FormGlobusView observer, List<Human> humans) : base(storeSections, checkouts, path)
        {
            this.Humans = humans;
            this.Observer = observer;
            this.Timer = new System.Timers.Timer(GlobusShop.DEFAULT_TIMER_INTERVAL);
            this.Timer.Elapsed += Timer_Elapsed;
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
        private void PlaceHumanToCheckout(Human human)
        {
            lock (this.Humans)
            {
                bool isAllCheckoutsFull = true;
                bool isHumanPlaced = false;
                do
                {
                    if (isAllCheckoutsFull) this.Checkouts.Find(c => !c.IsOpened)?.Open();
                    this.Checkouts.ForEach(c =>
                    {
                        if (c.IsOpened && !isHumanPlaced && !c.IsFull)
                        {
                            c.Enqueue(human);
                            isHumanPlaced = true;
                            isAllCheckoutsFull = false;
                        }
                    });
                } while (!isHumanPlaced);
            }
        }

        public void Simulate(int numberOfSlowHumans, int numberOfMediumHumans, int numberOfFastHumans, bool autoAddHumans, int humansPerMinute)
        {
            this.Checkouts.ForEach(c => c.HumanCashOut += C_HumanCashOut);
            this.AddHumans(numberOfSlowHumans, SlowHumanType.CreateInstance());
            this.AddHumans(numberOfMediumHumans, MediumHumanType.CreateInstance());
            this.AddHumans(numberOfFastHumans, FastHumanType.CreateInstance());
            this.Timer.Start();
            this.MoveHumans(typeof(FastHumanType));
            this.MoveHumans(typeof(MediumHumanType));
            this.MoveHumans(typeof(SlowHumanType));
            if (autoAddHumans) this.AddRandomHuman(humansPerMinute);
        }

        private void C_HumanCashOut(object sender, HumanEventArgs e)
        {
            this.Humans.Remove(e.Human);
        }

        private void Human_ShoppingFinished(object sender, EventArgs e)
        {
            this.PlaceHumanToCheckout(sender as Human);
        }

        private async void MoveHumans(Type humanType)
        {
            await Task.Run(() =>
            {
                lock (this.Humans)
                {
                    this.Humans.ForEach(h =>
                      {
                          if (h.Type.GetType() == humanType)
                          {
                              h.Move();
                              Thread.Sleep(1000); // Sleep one second
                          }
                      });
                }
            }).ConfigureAwait(false);
        }

        private async void AddRandomHuman(int humansPerMinute)
        {
            HumanType[] humanTypes = new HumanType[] { SlowHumanType.CreateInstance(), MediumHumanType.CreateInstance(), FastHumanType.CreateInstance() };

            await Task.Run(() =>
            {
                while (this.IsSimulationStarted)
                {
                    HumanType humanType = humanType = humanTypes[GlobusShop.Random.Next(humanTypes.Length)];
                    this.AddHuman(humanType);
                    Thread.Sleep(60 / humansPerMinute * 1000);
                }
            }).ConfigureAwait(false);
        }

        private void AddHuman(HumanType humanType)
        {
            lock (this.Humans)
            {
                this.Humans.Add(new Human(this.Path.Start, humanType, this.Path));
                this.Humans.Last().ShoppingFinished += Human_ShoppingFinished;
                this.Humans.Last().Move();
            }
        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            this.Observer.Notify();
        }

        private void AddHumans(int number, HumanType humanType)
        {
            for (int i = 0; i < number; i++)
            {
                this.AddHuman(humanType);
            }
        }
        #endregion
    }
}
