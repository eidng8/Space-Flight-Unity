// ---------------------------------------------------------------------------
// <copyright file="ShieldGenerator.cs" company="eidng8">
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
    /// <summary>Adds extra protection on top of armor.</summary>
    [Serializable,
     CreateAssetMenu(
         fileName = "Shield Generator Config",
         menuName = "Configurable/Ship/Shield Generator"
     )]
    public class ShieldGenerator : ComponentConfig
    {
        /// <summary>Extra hit points on top of armor.</summary>
        [Header("Shield Generator Attributes"),
         Tooltip("Extra hit points on top of armor.")]
        public float shield;

        /// <inheritdoc />
        public override string InfoBoxContent =>
            "Adds extra protection on top of armor.";

        /// <inheritdoc />
        public override Dictionary<string, float> Dict() {
            Dictionary<string, float> dict = base.Dict();
            dict["shield"] = this.shield;
            return dict;
        }

        /// <inheritdoc />
        public override string[] Validate() =>
            new List<string>(base.Validate()) {
                    this.ValidatePositiveShield()
                }
                .Where(e => e.Length > 0)
                .ToArray();

        /// <summary>
        /// Validate that <see cref="shield" /> is positive. Sets it to
        /// positive if not, besides returning an error message.
        /// </summary>
        /// <returns>
        /// An error message if the validation doesn't pass, otherwise an empty
        /// string.
        /// </returns>
        protected virtual string ValidatePositiveShield() =>
            this.shield.ValidatePositiveValue(
                "Shield",
                null,
                () => this.shield = -this.shield
            );
    }
}
