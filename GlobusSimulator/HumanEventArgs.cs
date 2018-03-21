/*
 * Authors : Baptiste COUDRAY, Benoit CHAUCHE
 * Enterprise : CFPTI, T.IS-E2
 * Date : 31.01.2018
 * Project : GlobusSimulator
 * Project desc. : A simulated Globus shop
 * Class : Checkout.cs
 * Class desc. : Represents a checkout
 */
using System;

namespace GlobusSimulator
{
    public class HumanEventArgs : EventArgs, IEquatable<HumanEventArgs>
    {
        public Human Human { get; }

        public HumanEventArgs(Human human)
        {
            this.Human = human;
        }

        public bool Equals(HumanEventArgs other)
        {
            return this.Human == other.Human;
        }
    }
}