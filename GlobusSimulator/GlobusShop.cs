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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        #endregion

        #region Constructors

        public GlobusShop()
        {
            this.Humans = new List<Human>();
        }

        #endregion

        #region Methods

        #endregion
    }
}
