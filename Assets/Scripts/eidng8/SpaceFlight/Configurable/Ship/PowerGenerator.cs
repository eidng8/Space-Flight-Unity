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
using UnityEngine;


namespace eidng8.SpaceFlight.Configurable.Ship
{
    [Serializable,
     CreateAssetMenu(
         fileName = "Power Generator Config",
         menuName = "Configurable/Ship/Power Generator"
     )]
    public class PowerGenerator : ComponentConfig
    {
        /// <inheritdoc />
        public override string[] Validate() {
            List<string> errors = new List<string>();
            if (this.power <= float.Epsilon) {
                errors.Add("Power must be greater than zero");
                this.power = -this.power;
            }

            return errors.ToArray();
        }
    }
}
