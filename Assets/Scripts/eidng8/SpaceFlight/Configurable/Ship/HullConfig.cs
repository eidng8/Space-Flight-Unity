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
    public class HullConfig : ComponentConfig
    {
        /// <summary>
        /// The ship explode when armor drops to 0.
        /// </summary>
        [Header("Hull Attributes"),
         Tooltip("The ship explode when armor drops to 0.")]
        public float armor;

        /// <inheritdoc />
        public override Dictionary<string, float> Dict() {
            Dictionary<string, float> dict = base.Dict();
            dict["armor"] = this.armor;
            return dict;
        }

        /// <inheritdoc />
        public override string[] Validate() {
            List<string> errors = new List<string>();

            if (this.armor <= float.Epsilon) {
                errors.Add("Armor must be greater than zero.");
                this.armor = -this.armor;
            }

            if (this.size <= float.Epsilon) {
                errors.Add("Size must be greater than zero.");
                this.size = -this.size;
            }

            return errors.ToArray();
        }
    }
}
