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
        /// <summary>
        /// Maximum energy it can store.
        /// </summary>
        [Header("Capacitor Attributes"),
         Tooltip("Maximum energy it can store.")]
        public float capacity;

        /// <inheritdoc />
        public override Dictionary<string, float> Dict() {
            Dictionary<string, float> dict = base.Dict();
            dict["capacitor"] = this.capacity;
            return dict;
        }

        /// <inheritdoc />
        public override string[] Validate() {
            List<string> errors = new List<string>();

            if (this.capacity <= float.Epsilon) {
                errors.Add("Capacitor must be greater than zero!");
                this.capacity = -this.capacity;
            }

            if (this.power > 0) {
                errors.Add("Power must be negative!");
                this.power = -this.power;
            }

            return errors.ToArray();
        }
    }
}
