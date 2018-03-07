/*
 * Authors : Baptiste COUDRAY, Benoit CHAUCHE
 * Enterprise : CFPTI, T.IS-E2
 * Date : 07.02.2018
 * Project : GlobusSimulator
 * Project desc. : A simulated Globus shop
 * Class : GlobusShop.cs
 * Class desc. : Reprensents a Globus shop
 */

using System.Collections.Generic;
using System.Drawing;

namespace GlobusSimulator
{
    public class GlobusShop
    {
        #region Consts
        private static readonly Path DEFAULT_PATH = new Path();
        private static readonly List<StoreSection> DEFAULT_STORE_SECTIONS = new List<StoreSection>();
        private static readonly List<Checkout> DEFAULT_CHECKOUTS = new List<Checkout>();
        private static readonly List<Human> DEFAULT_HUMANS = new List<Human>();
        #endregion

        #region Fields
        private List<Human> _humans;
        private List<StoreSection> _storeSections;
        private List<Checkout> _checkouts;
        private Path _path;
        #endregion

        #region Properties
        public List<Human> Humans { get => _humans; private set => _humans = value ?? GlobusShop.DEFAULT_HUMANS; }
        public List<StoreSection> StoreSections { get => _storeSections; private set => _storeSections = value ?? GlobusShop.DEFAULT_STORE_SECTIONS; }
        public List<Checkout> Checkouts { get => _checkouts; private set => _checkouts = value ?? GlobusShop.DEFAULT_CHECKOUTS; }
        public Path Path { get => _path; private set => _path = value ?? GlobusShop.DEFAULT_PATH; }
        #endregion

        #region Constructors
        public GlobusShop(Path path, List<StoreSection> storeSections, List<Checkout> checkouts, List<Human> humans)
        {
            this.Path = path;
            this.StoreSections = storeSections;
            this.Checkouts = checkouts;
            this.Humans = humans;
        }

        public GlobusShop(Path path, List<StoreSection> storeSections, List<Checkout> checkouts) : this(path, storeSections, checkouts, GlobusShop.DEFAULT_HUMANS)
        {
            // no code
        }

        public GlobusShop(Path path, List<StoreSection> storeSections) : this(path, storeSections, GlobusShop.DEFAULT_CHECKOUTS)
        {
            // no code
        }

        public GlobusShop(Path path) : this(path, GlobusShop.DEFAULT_STORE_SECTIONS)
        {
            // no code
        }

        public GlobusShop() : this(GlobusShop.DEFAULT_PATH)
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

        public void AddCheckout(Checkout checkout)
        {
            this.Checkouts.Add(checkout);
        }

        public void AddHuman(Human human)
        {
            this.Humans.Add(human);
        }

        public void AddStoreSection(StoreSection storeSection)
        {
            this.StoreSections.Add(storeSection);
        }

        public void AddStoreSection(Point location)
        {
            this.AddStoreSection(new StoreSection(location));
        }

        public void RemoveStoreSection(StoreSection storeSection)
        {
            this.StoreSections.Remove(storeSection);
        }

        public void RemoveStoreSections(List<StoreSection> storeSections)
        {
            storeSections.ForEach(ss => this.StoreSections.Remove(ss));
        }

        public void RemoveAllStoreSections()
        {
            this.StoreSections.Clear();
        }

        public void AddPointToPath(Point point)
        {
            this.Path.AddPoint(point);
        }

        public void ResetPath()
        {
            this.Path.RemoveAllPoints();
        }
        #endregion
    }
}
