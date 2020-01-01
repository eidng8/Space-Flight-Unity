// ---------------------------------------------------------------------------
// <copyright file="ShipConfig.cs" company="eidng8">
//      GPLv3
// </copyright>
// <summary>
// 
// </summary>
// ---------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using eidng8.SpaceFlight.Objects.Dynamic;
using UnityEngine;


namespace eidng8.SpaceFlight.Configurable.Ship
{
    [Serializable,
     CreateAssetMenu(
         fileName = "Ship Config",
         menuName = "Configurable/Ship/Ship"
     )]
    public class ShipConfig : Configurable
    {
        public ShipComponentConfig[] components;

        /// <inheritdoc />
        public override Dictionary<string, float> Dict() =>
            this.Aggregate(this.components.Select(c => c.Dict()));
    }
}
