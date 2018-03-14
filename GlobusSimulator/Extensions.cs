/*
 * Authors : Baptiste COUDRAY, Benoit CHAUCHE
 * Enterprise : CFPT-I, Geneva
 * Date : 14.3.2018
 * Project : GlobusSimulator
 * Project desc. : A simulated Globus shop
 * Class : Extensions.cs
 * Class desc. : Add a clone method the list
 */
using System;
using System.Collections.Generic;
using System.Linq;

namespace GlobusSimulator
{
    public static class Extensions
    {
        public static List<T> Clone<T>(this List<T> listToClone) where T : ICloneable
        {
            return listToClone.Select(item => (T)item.Clone()).ToList();
        }
    }
}
