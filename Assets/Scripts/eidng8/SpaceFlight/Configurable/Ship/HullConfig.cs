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
using System.Linq;
using eidng8.SpaceFlight.Laws;
using UnityEngine;


namespace eidng8.SpaceFlight.Configurable.Ship
{
    /// <summary>Hulls provide armor that keeps the ship survive.</summary>
    [Serializable,
     CreateAssetMenu(
         fileName = "Hull Config",
         menuName = "Configurable/Ship/Hull"
     )]
    public class HullConfig : ComponentConfig
    {
        /// <summary>The ship explode when armor drops to 0.</summary>
        [Header("Hull Attributes"),
         Tooltip("The ship explode when armor drops to 0.")]
        public float armor;

        /// <inheritdoc />
        public override string InfoBoxContent =>
            "Hulls provide armor that keeps the ship survive.";

        /// <inheritdoc />
        public override Dictionary<string, float> Dict() {
            Dictionary<string, float> dict = base.Dict();
            dict["armor"] = this.armor;
            return dict;
        }

        /// <inheritdoc />
        public override string[] Validate() =>
            new List<string> {
                    this.ValidatePositiveMass(),
                    this.ValidateNegativeSize(),
                    this.ValidatePositiveArmor()
                }
                .Where(e => e.Length > 0)
                .ToArray();

        /// <summary>
        /// Validate that <see cref="armor" /> is positive. Sets it to positive
        /// if not, besides returning an error message.
        /// </summary>
        /// <returns>
        /// An error message if the validation doesn't pass, otherwise an empty
        /// string.
        /// </returns>
        protected virtual string ValidatePositiveArmor() =>
            this.armor.ValidatePositiveValue(
                "Armor",
                null,
                () => this.armor = -this.armor
            );
    }
}
