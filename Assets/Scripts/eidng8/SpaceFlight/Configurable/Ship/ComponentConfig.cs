// ---------------------------------------------------------------------------
// <copyright file="ComponentConfig.cs" company="eidng8">
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
    public abstract class ComponentConfig : Configurable, IConfigurable
    {
        /// <summary>
        /// Positive value denotes how much space the component provides;
        /// negative value denotes how much space the component occupies.
        /// </summary>
        public float size;

        /// <summary>
        /// Positive value denotes how much power the component generates;
        /// negative value denotes constant power consumption of the component.
        /// </summary>
        public float power;

        /// <inheritdoc />
        public override Dictionary<string, float> Dict() {
            Dictionary<string, float> dict = base.Dict();
            dict["size"] = this.size;
            dict["power"] = this.power;
            return dict;
        }
    }
}
