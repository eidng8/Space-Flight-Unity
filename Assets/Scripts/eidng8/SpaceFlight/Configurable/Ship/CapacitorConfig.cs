// ---------------------------------------------------------------------------
// <copyright file="CapacitorConfig.cs" company="eidng8">
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
         fileName = "Capacitor Config",
         menuName = "Configurable/Ship/Capacitor"
     )]
    public class CapacitorConfig : ComponentConfig
    {
        public float capacitor;

        /// <inheritdoc />
        public override Dictionary<string, float> Dict() {
            Dictionary<string, float> dict = base.Dict();
            dict["capacitor"] = this.capacitor;
            return dict;
        }

        /// <inheritdoc />
        public override string[] Validate() {
            List<string> errors = new List<string>();

            if (this.capacitor <= float.Epsilon) {
                errors.Add("Capacitor must be greater than zero!");
                this.capacitor = -this.capacitor;
            }

            if (this.power <= float.Epsilon) {
                errors.Add("Power must be greater than zero!");
                this.capacitor = -this.power;
            }

            return errors.ToArray();
        }
    }
}
