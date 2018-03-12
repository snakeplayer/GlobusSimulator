/*
 * Authors : Baptiste COUDRAY, Benoit CHAUCHE
 * Enterprise : CFPTI, T.IS-E2
 * Date : 07.03.2018
 * Project : GlobusSimulator
 * Project desc. : A simulated Globus shop
 * Class : GlobusShopEditor.cs
 * Class desc. : Used to create a GlobusShop
 */

using System.Collections.Generic;

namespace GlobusSimulator
{
    public class GlobusShopEditor : Shop
    {
        public GlobusShopEditor(List<StoreSection> storeSections, List<Checkout> checkouts, Path path) : base(storeSections, checkouts, path)
        {

        }

        public GlobusShopEditor() : this(new List<StoreSection>(), new List<Checkout>(), new Path())
        {

        }
    }
}
