/*
 * Authors : Baptiste COUDRAY, Benoit CHAUCHE
 * Enterprise : CFPTI, T.IS-E2
 * Date : 07.03.2018
 * Project : GlobusSimulator
 * Project desc. : A simulated Globus shop
 * Class : Shop.cs
 * Class desc. : Abstract class for a shop creation
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobusSimulator
{
    public abstract class Shop : Object
    {
        #region Fields
        
        private List<StoreSection> _storeSections;
        private List<Checkout> _checkouts;
        private Path _path;

        #endregion

        #region Properties
        
        public List<StoreSection> StoreSections { get => _storeSections; private set => _storeSections = value ?? new List<StoreSection>(); }
        public List<Checkout> Checkouts { get => _checkouts; private set => _checkouts = value ?? new List<Checkout>(); }
        public Path Path { get => _path; private set => _path = value ?? new Path(); }

        #endregion

        #region Constructor

        public Shop(List<StoreSection> storeSections, List<Checkout> checkouts, Path path)
        {
            this.StoreSections = storeSections;
            this.Checkouts = checkouts;
            this.Path = path;
        }

        #endregion

        #region Methods (StoreSection)

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

        public void RemoveStoreSection(Point location)
        {
            int index = -1;

            for (int i = 0; i < this.StoreSections.Count; i++)
            {
                if (this.StoreSections[i].Shape.IntersectsWith(new Rectangle(location, new Size(1, 1))))
                {
                    index = i;
                }
            }

            if (index >= 0)
            {
                this.StoreSections.RemoveAt(index);
            }
        }

        public void RemoveStoreSections(List<StoreSection> storeSections)
        {
            storeSections.ForEach(ss => this.StoreSections.Remove(ss));
        }

        public void RemoveAllStoreSections()
        {
            this.StoreSections.Clear();
        }

        #endregion

        #region Methods (Checkout)

        public void AddCheckout(Checkout checkout)
        {
            this.Checkouts.Add(checkout);
        }

        public void AddCheckout(Point location)
        {
            this.Checkouts.Add(new Checkout(location));
        }

        public void RemoveCheckout(Checkout checkout)
        {
            this.Checkouts.Remove(checkout);
        }

        public void RemoveCheckout(Point location)
        {
            int index = -1;

            for (int i = 0; i < this.Checkouts.Count; i++)
            {
                if (this.Checkouts[i].Shape.IntersectsWith(new Rectangle(location, new Size(1, 1))))
                {
                    index = i;
                }
            }

            if (index >= 0)
            {
                this.Checkouts.RemoveAt(index);
            }
        }

        #endregion

        #region Methods (Path)

        public void AddPointToPath(Point point)
        {
            this.Path.AddPoint(point);
        }

        public void RemovePointFromPath(Point point)
        {
            this.Path.RemovePoint(point);
        }

        public void ResetPath()
        {
            this.Path.RemoveAllPoints();
        }

        #endregion
    }
}
