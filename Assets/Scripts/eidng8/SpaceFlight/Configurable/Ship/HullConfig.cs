// ---------------------------------------------------------------------------
// <copyright file="HullConfig.cs" company="eidng8">
//      GPLv3
// </copyright>
// <summary>
// 
// </summary>
// ---------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using UnityEngine;


namespace eidng8.SpaceFlight.Configurable.Ship
{
    [Serializable,
     CreateAssetMenu(
         fileName = "Hull Config",
         menuName = "Configurable/Ship/Hull"
     )]
    public class HullConfig : ShipComponentConfig
    {
        public float armor;

        /// <inheritdoc />
        public override Dictionary<string, float> Dict()
        {
            Dictionary<string, float> dict = base.Dict();
            dict["armor"] = this.armor;
            return dict;
        }
    }
}
