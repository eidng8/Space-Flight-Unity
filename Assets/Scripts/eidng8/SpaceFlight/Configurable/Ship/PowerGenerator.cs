// ---------------------------------------------------------------------------
// <copyright file="PowerGenerator.cs" company="eidng8">
//      GPLv3
// </copyright>
// <summary>
// 
// </summary>
// ---------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace eidng8.SpaceFlight.Configurable.Ship
{
    /// <summary>
    /// Power generators are main source of energy for the ship to operate.
    /// </summary>
    [Serializable,
     CreateAssetMenu(
         fileName = "Power Generator Config",
         menuName = "Configurable/Ship/Power Generator"
     )]
    public class PowerGenerator : ComponentConfig
    {
        /// <inheritdoc />
        public override string InfoBoxContent =>
            "Power generators are main source of energy for the ship to operate.";

        /// <inheritdoc />
        public override string[] Validate() {
            List<string> errors = new List<string> {
                this.ValidatePositiveMass(),
                this.ValidatePositivePower(),
                this.ValidateNegativeSize(),
            };

            return errors.Where(e => e.Length > 0).ToArray();
        }
    }
}
