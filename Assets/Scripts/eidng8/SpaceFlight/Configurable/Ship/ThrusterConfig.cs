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
using UnityEngine;


namespace eidng8.SpaceFlight.Configurable.Ship
{
    [Serializable,
     CreateAssetMenu(
         fileName = "Thruster Config",
         menuName = "Configurable/Ship/Thruster"
     )]
    public class ThrusterConfig : ComponentConfig, IConfigurable
    {
        public float maxForward;
        public float maxReverse;
        public float maxPan;
        public float maxTorque;
        public float energy;

        /// <inheritdoc />
        public override Dictionary<string, float> Dict() {
            Dictionary<string, float> dict = base.Dict();
            dict["maxForward"] = this.maxForward;
            dict["maxReverse"] = this.maxReverse;
            dict["maxPan"] = this.maxPan;
            dict["maxTorque"] = this.maxTorque;
            dict["energy"] = this.energy;
            return dict;
        }

        /// <inheritdoc />
        public override string[] Validate() {
            List<string> errors = new List<string>();

            if (this.maxForward < 0) {
                errors.Add(
                    $"Max Forward must be no less than zero."
                    + $" Current value is {this.maxForward}"
                );
            }

            if (this.maxReverse < 0) {
                errors.Add(
                    "Max Reverse must be no less than zero."
                    + $" Current value is {this.maxReverse}"
                );
            }

            if (this.maxPan < 0) {
                errors.Add(
                    "Max Pan must be no less than zero."
                    + $" Current value is {this.maxPan}"
                );
            }

            if (this.maxTorque < 0) {
                errors.Add(
                    "Max Torque must be no less than zero."
                    + $" Current value is {this.maxTorque}"
                );
            }

            if (Mathf.Abs(this.power) <= float.Epsilon
                && Mathf.Abs(this.energy) <= float.Epsilon) {
                errors.Add(
                    "Must consume either power or energy."
                    + $" Current values are {this.power} and {this.energy}"
                );
            }

            return errors.ToArray();
        }
    }
}
