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
        /// <summary>
        /// Initializes a new instance of the <see cref="Shop"/> class.
        /// </summary>
        /// <param name="storeSections">The store sections.</param>
        /// <param name="checkouts">The checkouts.</param>
        /// <param name="path">The path.</param>
        protected Shop(List<StoreSection> storeSections, List<Checkout> checkouts, Path path)
        {
            this.StoreSections = storeSections;
            this.Checkouts = checkouts;
            this.Path = path;
        }
        #endregion

        #region Methods (StoreSection)
        /// <summary>
        /// Adds the store section.
        /// </summary>
        /// <param name="storeSection">The store section.</param>
        public void AddStoreSection(StoreSection storeSection)
        {
            this.StoreSections.Add(storeSection);
        }

        /// <summary>
        /// Adds the store section.
        /// </summary>
        /// <param name="location">The location.</param>
        public void AddStoreSection(Point location)
        {
            this.AddStoreSection(new StoreSection(location));
        }

        /// <summary>
        /// Adds the store section.
        /// </summary>
        /// <param name="location">The location.</param>
        /// <param name="size">The size.</param>
        public void AddStoreSection(Point location, Size size)
        {
            this.AddStoreSection(new StoreSection(location, size));
        }

        /// <summary>
        /// Removes the store section.
        /// </summary>
        /// <param name="storeSection">The store section.</param>
        public void RemoveStoreSection(StoreSection storeSection)
        {
            this.StoreSections.Remove(storeSection);
        }

        /// <summary>
        /// Removes the store section.
        /// </summary>
        /// <param name="location">The location.</param>
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

        /// <summary>
        /// Removes the store sections.
        /// </summary>
        /// <param name="storeSections">The store sections.</param>
        public void RemoveStoreSections(List<StoreSection> storeSections)
        {
            storeSections.ForEach(ss => this.StoreSections.Remove(ss));
        }

        /// <summary>
        /// Removes the store sections.
        /// </summary>
        public void RemoveStoreSections()
        {
            this.StoreSections.Clear();
        }
        #endregion

        #region Methods (Checkout)
        /// <summary>
        /// Adds the checkout.
        /// </summary>
        /// <param name="checkout">The checkout.</param>
        public void AddCheckout(Checkout checkout)
        {
            this.Checkouts.Add(checkout);
        }

        /// <summary>
        /// Adds the checkout.
        /// </summary>
        /// <param name="location">The location.</param>
        public void AddCheckout(Point location)
        {
            this.Checkouts.Add(new Checkout(location));
        }

        /// <summary>
        /// Adds the checkout.
        /// </summary>
        /// <param name="location">The location.</param>
        /// <param name="size">The size.</param>
        public void AddCheckout(Point location, Size size)
        {
            this.AddCheckout(new Checkout(location, size));
        }

        /// <summary>
        /// Removes the checkout.
        /// </summary>
        /// <param name="checkout">The checkout.</param>
        public void RemoveCheckout(Checkout checkout)
        {
            this.Checkouts.Remove(checkout);
        }

        /// <summary>
        /// Removes the checkout.
        /// </summary>
        /// <param name="location">The location.</param>
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

        /// <summary>
        /// Removes the checkouts.
        /// </summary>
        /// <param name="checkouts">The checkouts.</param>
        public void RemoveCheckouts(List<Checkout> checkouts)
        {
            checkouts.ForEach(c => this.Checkouts.Remove(c));
        }

        /// <summary>
        /// Removes the checkouts.
        /// </summary>
        public void RemoveCheckouts()
        {
            this.Checkouts.Clear();
        }
        #endregion

        #region Methods (Path)
        /// <summary>
        /// Adds the point to path.
        /// </summary>
        /// <param name="point">The point.</param>
        public void AddPointToPath(Point point)
        {
            this.Path.AddPoint(point);
        }

        /// <summary>
        /// Adds the points to path.
        /// </summary>
        /// <param name="points">The points.</param>
        public void AddPointsToPath(List<Point> points)
        {
            this.Path.AddPoints(points);
        }

        /// <summary>
        /// Removes the point from path.
        /// </summary>
        /// <param name="point">The point.</param>
        public void RemovePointFromPath(Point point)
        {
            this.Path.RemovePoint(point);
        }

        /// <summary>
        /// Removes the path.
        /// </summary>
        public void RemovePath()
        {
            this.Path.RemoveAllPoints();
        }
        #endregion
    }
}
