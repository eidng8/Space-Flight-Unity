// ---------------------------------------------------------------------------
// <copyright file="ShieldGenerator.cs" company="eidng8">
//      GPLv3
// </copyright>
// <summary>
// 
// </summary>
// ---------------------------------------------------------------------------

using System;
using UnityEngine;


namespace eidng8.SpaceFlight.Configurable.Ship
{
    [Serializable,
     CreateAssetMenu(
         fileName = "Shield Generator Config",
         menuName = "Configurable/Ship/Shield Generator"
     )]
    public class ShieldGenerator : ComponentConfig
    {
        /// <summary>
        /// Extra hit points on top of armor.
        /// </summary>
        public float shield;
    }
}
