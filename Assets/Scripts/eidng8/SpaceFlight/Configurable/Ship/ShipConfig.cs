// ---------------------------------------------------------------------------
// <copyright file="ShipConfig.cs" company="eidng8">
//      GPLv3
// </copyright>
// <summary>
// 
// </summary>
// ---------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using eidng8.SpaceFlight.Objects.Dynamic;
using UnityEngine;


namespace eidng8.SpaceFlight.Configurable.Ship
{
    [Serializable,
     CreateAssetMenu(
         fileName = "Ship Config",
         menuName = "Configurable/Ship/Ship"
     )]
    public class ShipConfig : Configurable
    {
        [Header("Ship Attributes")]
        public ComponentConfig[] components;

        /// <inheritdoc />
        public override Dictionary<string, float> Aggregate() =>
            base.Aggregate(this.components.Select(c => c.Dict()));

        public override string[] Validate() {
            List<string> errors = new List<string>();
            float v;
            Dictionary<string, float> dict = this.Aggregate();
            if (!dict.TryGetValue("power", out v)) {
                errors.Add("Too much power consumption!");
            } else if (v < 0) {
                errors.Add("Too much power consumption!");
            }

            if (!dict.TryGetValue("size", out v)) {
                errors.Add("Not vacant space!");
            } else if (v < 0) {
                errors.Add("Not enough space to install all components!");
            }

            if (!dict.TryGetValue("capacitor", out v)) {
                errors.Add("No energy capacity!");
            }

            return this.ValidateComponents(errors);
        }

        private string[] ValidateComponents(List<string> errors) {
            bool sizeOccupant = false;
            bool powerConsumer = false;
            bool energyConsumer = false;

            IEnumerable<Dictionary<string, float>> cmps =
                this.components.Select(c => c.Dict());
            foreach (Dictionary<string, float> component in cmps) {
                float v;
                if (!sizeOccupant && component.TryGetValue("size", out v)) {
                    sizeOccupant = v < 0;
                }

                if (!powerConsumer && component.TryGetValue("power", out v)) {
                    powerConsumer = v < 0;
                }

                if (!energyConsumer && component.TryGetValue("energy", out v)) {
                    energyConsumer = v < 0;
                }
            }

            if (!sizeOccupant) {
                errors.Add("Nothing occupies any size!");
            }

            if (!powerConsumer) {
                errors.Add("No power consumption!");
            }

            if (!energyConsumer) {
                errors.Add("No energy consumption!");
            }

            return errors.ToArray();
        }
    }
}
