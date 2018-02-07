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

namespace GlobusSimulator
{
    public class GlobusShop
    {
        #region Consts

        #endregion

        #region Fields

        #endregion

        #region Properties

        public List<Human> Humans { get; private set; }
        public List<StoreSection> StoreSections { get; private set; }
        public List<Checkout> Checkouts { get; private set; }

        public Path Path { get; private set; }

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
                    // open a new Checkout
                }
            }
        }

        #endregion
    }
}
