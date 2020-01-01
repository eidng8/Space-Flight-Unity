// ---------------------------------------------------------------------------
// <copyright file="ShipComponentConfig.cs" company="eidng8">
//      GPLv3
// </copyright>
// <summary>
// 
// </summary>
// ---------------------------------------------------------------------------

using System.Collections.Generic;
using UnityEngine;


namespace eidng8.SpaceFlight.Configurable.Ship
{
    public abstract class ShipComponentConfig : Configurable, IConfigurable
    {
        public float size;

        /// <inheritdoc />
        public override Dictionary<string, float> Dict()
        {
            Dictionary<string, float> dict = base.Dict();
            dict["size"] = this.size;
            return dict;
        }
    }
}
