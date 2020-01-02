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
using UnityEngine;


namespace eidng8.SpaceFlight.Configurable.Ship
{
    [Serializable,
     CreateAssetMenu(
         fileName = "Shield Generator Config",
         menuName = "Configurable/Ship/Shield Generator"
     )]
    public class ShieldGenerator : ComponentConfig
    {
        /// <summary>
        /// Extra hit points on top of armor.
        /// </summary>
        [Header("Shield Generator Attributes"),
         Tooltip("Extra hit points on top of armor.")]
        public float shield;

        /// <inheritdoc />
        public override Dictionary<string, float> Dict() {
            Dictionary<string, float> dict = base.Dict();
            dict["shield"] = this.shield;
            return dict;
        }

        /// <inheritdoc />
        public override string[] Validate() {
            List<string> errors = new List<string>();
            if (this.shield <= float.Epsilon) {
                errors.Add("Shield must be greater than zero!");
                this.shield = -this.shield;
            }

            return errors.ToArray();
        }
    }
}
