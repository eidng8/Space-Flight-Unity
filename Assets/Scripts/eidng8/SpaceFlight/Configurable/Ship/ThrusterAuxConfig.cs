// ---------------------------------------------------------------------------
// <copyright file="ThrusterAuxConfig.cs" company="eidng8">
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
    /// <summary>Auxiliary thrusters used on-demand.</summary>
    [Serializable,
     CreateAssetMenu(
         fileName = "Thruster Config",
         menuName = "Configurable/Ship/Thruster, per use"
     )]
    public class ThrusterAuxConfig : ThrusterConfig, IOnDemand
    {
        /// <summary>Time duration between two consecutive uses.</summary>
        [Tooltip("Time duration between two consecutive uses.")]
        public float cooldown;

        /// <summary>Energy consumption per use.</summary>
        [Tooltip("Energy consumption per use.")]
        public float energy;

        /// <inheritdoc />
        public override string InfoBoxContent =>
            "Auxiliary thrusters used on-demand.";

        /// <inheritdoc />
        public override Dictionary<string, float> Dict() {
            var dict = base.Dict();
            dict.Remove("maxForward");
            dict.Remove("maxReverse");
            dict.Remove("maxPan");
            dict.Remove("maxTorque");
            return dict;
        }

        /// <inheritdoc />
        public override string[] Validate() =>
            new List<string> {
                    this.ValidatePositiveMass(),
                    this.ValidateNegativeSize(),
                    this.ValidateNegativeEnergy(),
                    this.ValidatePositiveCooldown(),
                    this.ValidatePositiveMaxForward(),
                    this.ValidatePositiveMaxReverse(),
                    this.ValidatePositiveMaxPan(),
                    this.ValidatePositiveMaxTorque()
                }
                .Where(e => e.Length > 0)
                .ToArray();

        /// <summary>
        /// Validate that <see cref="energy" /> is positive. Sets it to
        /// positive if not, besides returning an error message.
        /// </summary>
        /// <returns>
        /// An error message if the validation doesn't pass, otherwise an empty
        /// string.
        /// </returns>
        protected virtual string ValidateNegativeEnergy() =>
            this.energy.ValidateNegativeValue(
                "Energy",
                null,
                () => this.energy = -this.energy
            );

        /// <summary>
        /// Validate that <see cref="cooldown" /> is positive. Sets it to
        /// positive if not, besides returning an error message.
        /// </summary>
        /// <returns>
        /// An error message if the validation doesn't pass, otherwise an empty
        /// string.
        /// </returns>
        protected virtual string ValidatePositiveCooldown() =>
            this.cooldown.ValidatePositiveValue(
                "Cooldown",
                null,
                () => this.cooldown = -this.cooldown
            );
    }
}
