// ---------------------------------------------------------------------------
// <copyright file="ThrusterConfig.cs" company="eidng8">
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
    /// <summary>
    /// Thrusters are what drive ships around.
    /// </summary>
    [Serializable,
     CreateAssetMenu(
         fileName = "Thruster Config",
         menuName = "Configurable/Ship/Thruster"
     )]
    public class ThrusterConfig : ComponentConfig
    {
        /// <summary>
        /// Maximum forward movement momentum.
        /// </summary>
        [Header("Thruster Attributes"),
         Tooltip("Maximum forward movement momentum.")]
        public float maxForward;

        /// <summary>
        /// Maximum backward movement momentum.
        /// </summary>
        [Tooltip("Maximum backward movement momentum.")]
        public float maxReverse;

        /// <summary>
        /// Maximum side-way movement momentum.
        /// </summary>
        [Tooltip("Maximum side-way movement momentum.")]
        public float maxPan;

        /// <summary>
        /// Maximum angular momentum.
        /// </summary>
        [Tooltip("Maximum angular momentum.")]
        public float maxTorque;

        /// <inheritdoc />
        public override string InfoBoxContent =>
            "Thrusters are what drive ships around.";

        /// <inheritdoc />
        public override Dictionary<string, float> Dict() {
            Dictionary<string, float> dict = base.Dict();
            dict["maxForward"] = this.maxForward;
            dict["maxReverse"] = this.maxReverse;
            dict["maxPan"] = this.maxPan;
            dict["maxTorque"] = this.maxTorque;
            return dict;
        }

        /// <inheritdoc />
        public override string[] Validate() =>
            new List<string>(base.Validate()) {
                    this.ValidatePositiveMaxForward(),
                    this.ValidatePositiveMaxReverse(),
                    this.ValidatePositiveMaxPan(),
                    this.ValidatePositiveMaxTorque(),
                }
                .Where(e => e.Length > 0)
                .ToArray();


        /// <summary>
        /// Validate that <see cref="maxForward"/> is positive. Sets it to
        /// positive if not, besides returning an error message.
        /// </summary>
        /// <returns>
        /// An error message if the validation doesn't pass, otherwise an empty
        /// string.
        /// </returns>
        protected virtual string ValidatePositiveMaxForward() =>
            Maths.ValidatePositiveValue(
                this.maxForward,
                "Max Forward",
                null,
                () => this.maxForward = -this.maxForward
            );

        /// <summary>
        /// Validate that <see cref="maxReverse"/> is positive. Sets it to
        /// positive if not, besides returning an error message.
        /// </summary>
        /// <returns>
        /// An error message if the validation doesn't pass, otherwise an empty
        /// string.
        /// </returns>
        protected virtual string ValidatePositiveMaxReverse() =>
            Maths.ValidatePositiveValue(
                this.maxReverse,
                "Max Reverse",
                null,
                () => this.maxReverse = -this.maxReverse
            );

        /// <summary>
        /// Validate that <see cref="maxPan"/> is positive. Sets it to
        /// positive if not, besides returning an error message.
        /// </summary>
        /// <returns>
        /// An error message if the validation doesn't pass, otherwise an empty
        /// string.
        /// </returns>
        protected virtual string ValidatePositiveMaxPan() =>
            Maths.ValidatePositiveValue(
                this.maxPan,
                "Max Pan",
                null,
                () => this.maxPan = -this.maxPan
            );

        /// <summary>
        /// Validate that <see cref="maxTorque"/> is positive. Sets it to
        /// positive if not, besides returning an error message.
        /// </summary>
        /// <returns>
        /// An error message if the validation doesn't pass, otherwise an empty
        /// string.
        /// </returns>
        protected virtual string ValidatePositiveMaxTorque() =>
            Maths.ValidatePositiveValue(
                this.maxTorque,
                "Max Torque",
                null,
                () => this.maxTorque = -this.maxTorque
            );
    }
}
