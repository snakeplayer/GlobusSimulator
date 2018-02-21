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
        private List<Human> _humans;
        private List<StoreSection> _storeSections;
        private List<Checkout> _checkouts;
        private Path _path;
        #region Consts

        #endregion

        #region Fields

        #endregion

        #region Properties
        public List<Human> Humans { get => _humans; private set => _humans = value ?? new List<Human>(); }
        public List<StoreSection> StoreSections { get => _storeSections; private set => _storeSections = value ?? new List<StoreSection>(); }
        public List<Checkout> Checkouts { get => _checkouts; private set => _checkouts = value ?? new List<Checkout>(); }
        public Path Path { get => _path; private set => _path = value ?? new Path(); }
        #endregion

        #region Constructors
        public GlobusShop(Path path)
        {
            this.Humans = new List<Human>();
            this.StoreSections = new List<StoreSection>();
            this.Checkouts = new List<Checkout>();
            this.Path = path;
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

        public void AddHuman(Point point, Color color, int timeToStayInMilliseconds)
        {
            this.Humans.Add(new Human(point, color, timeToStayInMilliseconds));
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
