// ---------------------------------------------------------------------------
// <copyright file="PlayerConfig.cs" company="eidng8">
//      GPLv3
// </copyright>
// <summary>
// 
// </summary>
// ---------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using eidng8.SpaceFlight.Configurable.Ship;
using UnityEngine;


namespace eidng8.SpaceFlight.Configurable.System
{
    [Serializable,
     CreateAssetMenu(
         fileName = "Player Config",
         menuName = "Configurable/Player"
     )]
    public class PlayerConfig : Configurable
    {
        [Tooltip("Current ship")]
        public ShipConfig ship;

        /// <inheritdoc />
        public override string InfoBoxContent => "";

        /// <inheritdoc />
        public override Dictionary<string, float> Aggregate() => throw new NotImplementedException();
    }
}
