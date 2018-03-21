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
        /// <summary>
        /// Initializes a new instance of the <see cref="GlobusShop"/> class.
        /// </summary>
        /// <param name="storeSections">The store sections.</param>
        /// <param name="checkouts">The checkouts.</param>
        /// <param name="path">The path.</param>
        /// <param name="observer">The observer.</param>
        /// <param name="humans">The humans.</param>
        public GlobusShop(List<StoreSection> storeSections, List<Checkout> checkouts, Path path, FormGlobusView observer, List<Human> humans) : base(storeSections, checkouts, path)
        {
            this.Humans = humans;
            this.Observer = observer;
            this.Timer = new System.Timers.Timer(GlobusShop.DEFAULT_TIMER_INTERVAL);
            this.Timer.Elapsed += Timer_Elapsed;
            this.Observer.Notify();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GlobusShop"/> class.
        /// </summary>
        /// <param name="editor">The editor.</param>
        /// <param name="observer">The observer.</param>
        public GlobusShop(GlobusShopEditor editor, FormGlobusView observer) : this(editor.StoreSections, editor.Checkouts, editor.Path, observer, new List<Human>())
        {
            // no code
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GlobusShop"/> class.
        /// </summary>
        /// <param name="observer">The observer.</param>
        public GlobusShop(FormGlobusView observer) : this(new List<StoreSection>(), new List<Checkout>(), new Path(), observer, new List<Human>())
        {
            // no code
        }
        #endregion

        #region Methods
        /// <summary>
        /// Places the human to a checkout.
        /// </summary>
        /// <param name="human">The human.</param>
        private async void PlaceHumanToCheckout(Human human)
        {
            await Task.Run(() =>
            {
                bool isHumanPlaced = false;
                do
                {
                    bool isAllCheckoutsClosed = this.Checkouts.FindAll(c => !c.IsOpened).Count == this.Checkouts.Count;
                    bool isCheckoutsOpenFull = this.Checkouts.FindAll(c => c.IsOpened && c.IsFull).Count != 0;

                    if (isAllCheckoutsClosed || isCheckoutsOpenFull) this.Checkouts.Find(c => !c.IsOpened)?.Open(); // We open a checkout if no checkout is open, or all checkouts open are full

                    this.Checkouts.ForEach(c =>
                    {
                        // We enqueue the human is the checkout is open and if the checkout is not full
                        if (c.IsOpened && !isHumanPlaced)
                        {
                            isHumanPlaced = c.Enqueue(human); // Add the human to the queue
                        }
                    });
                } while (!isHumanPlaced);
            }).ConfigureAwait(false);
        }

        /// <summary>
        /// Simulates the globus shop
        /// </summary>
        /// <param name="numberOfSlowHumans">The number of slow humans.</param>
        /// <param name="numberOfMediumHumans">The number of medium humans.</param>
        /// <param name="numberOfFastHumans">The number of fast humans.</param>
        /// <param name="autoAddHumans">if set to <c>true</c> [automatic add humans].</param>
        /// <param name="humansPerMinute">The humans per minute.</param>
        public void Simulate(int numberOfSlowHumans, int numberOfMediumHumans, int numberOfFastHumans, bool autoAddHumans, int humansPerMinute)
        {
            if (!this.IsSimulationStarted)
            {
                this.Checkouts.ForEach(c => { c.HumanCashOut += Checkout_HumanCashOut; c.HumanEnqueue += Checkout_HumanEnqueue; }); // We bind the event so that we can be notify that a human has been cash out or enqueue
                this.AddHumans(numberOfSlowHumans, SlowHumanType.CreateInstance());
                this.AddHumans(numberOfMediumHumans, MediumHumanType.CreateInstance());
                this.AddHumans(numberOfFastHumans, FastHumanType.CreateInstance());
                this.Timer.Start(); // Start the simulation
                this.MoveHumans(typeof(FastHumanType));
                this.MoveHumans(typeof(MediumHumanType));
                this.MoveHumans(typeof(SlowHumanType));
                if (autoAddHumans) this.AddRandomHuman(humansPerMinute);
            }
            else
            {
                this.Timer.Stop();
                this.Observer.Notify();
            }
        }

        /// <summary>
        /// Handles the HumanEnqueue event of the Checkout control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="HumanEventArgs"/> instance containing the event data.</param>
        private void Checkout_HumanEnqueue(object sender, HumanEventArgs e)
        {
            if (sender is Checkout checkout) e.Human.Relocate(checkout.Shape.Location); // We put the human at the top left position
        }

        /// <summary>
        /// Handles the HumanCashOut event of the Checkout control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="HumanEventArgs"/> instance containing the event data.</param>
        private void Checkout_HumanCashOut(object sender, HumanEventArgs e)
        {
            lock (this.Humans)
            {
                this.Humans.Remove(e.Human);
            }
        }

        /// <summary>
        /// Handles the ShoppingFinished event of the Human control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Human_ShoppingFinished(object sender, EventArgs e)
        {
            this.PlaceHumanToCheckout(sender as Human);
        }

        /// <summary>
        /// Moves the humans.
        /// </summary>
        /// <param name="humanType">Type of the human.</param>
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
                              Thread.Sleep(2500); // Sleep one second
                          }
                      });
                }
            }).ConfigureAwait(false);
        }

        /// <summary>
        /// Adds a random number human.
        /// </summary>
        /// <param name="humansPerMinute">The humans per minute.</param>
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

        /// <summary>
        /// Adds a human.
        /// </summary>
        /// <param name="humanType">Type of the human.</param>
        private void AddHuman(HumanType humanType)
        {
            Human human = new Human(this.Path.Start, humanType, this.Path);
            human.ShoppingFinished += Human_ShoppingFinished; // We bind the event so that we can be notify that the human has finished his shoppingth
            lock (this.Humans)
            {
                this.Humans.Add(human);
            }
            human.Move();
        }

        /// <summary>
        /// Handles the Elapsed event of the Timer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Timers.ElapsedEventArgs"/> instance containing the event data.</param>
        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            this.Observer.Notify(); // Notify the view that a change has been made
        }

        /// <summary>
        /// Adds a specific number of humans.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <param name="humanType">Type of the human.</param>
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
