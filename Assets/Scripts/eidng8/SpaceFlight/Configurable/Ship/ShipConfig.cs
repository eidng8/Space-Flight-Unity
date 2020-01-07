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
using eidng8.SpaceFlight.Laws;
using UnityEngine;


namespace eidng8.SpaceFlight.Configurable.Ship
{
    /// <summary>Ships are the thing you drive around.</summary>
    [Serializable,
     CreateAssetMenu(
         fileName = "Ship Config",
         menuName = "Configurable/Ship/Ship"
     )]
    public class ShipConfig : ObjectConfigurable
    {
        /// <summary>List of all installed components.</summary>
        [Tooltip("List of all installed components.")]
        public ComponentConfig[] components;

        /// <summary>Prefab used to render the ship.</summary>
        [Tooltip("Prefab used to render the ship.")]
        public Objects.Movable.Ship prefab;

        /// <summary>Space available for component installation.</summary>
        [Header("Ship Attributes"),
         Tooltip("Space available for component installation.")]
        public float size;

        /// <inheritdoc />
        public override string InfoBoxContent =>
            "Ships are the thing you drive around.";

        /// <inheritdoc />
        public override Dictionary<string, float> Aggregate() =>
            base.Aggregate(this.components.Select(c => c.Dict()));

        /// <inheritdoc />
        public override Dictionary<string, float> Dict() {
            Dictionary<string, float> dict = base.Dict();
            dict["size"] = this.size;
            return dict;
        }

        public override string[] Validate() {
            List<string> errors = new List<string> {
                this.ValidatePositiveMass(),
                this.ValidatePrefab(),
                this.size.ValidatePositiveValue(
                    "Size",
                    null,
                    () => this.size = -this.size
                )
            };

            float v;
            Dictionary<string, float> dict = this.Aggregate();
            if (!dict.TryGetValue("power", out v)) {
                errors.Add("No power generator!");
            } else if (v < 0) {
                errors.Add("Too much power consumption!");
            }

            if (!dict.TryGetValue("size", out v)) {
                errors.Add("No hull!");
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

            IEnumerable<Dictionary<string, float>> comps =
                this.components.Select(c => c.Dict());
            foreach (Dictionary<string, float> component in comps) {
                float v;
                if (!sizeOccupant && component.TryGetValue("size", out v)) {
                    sizeOccupant = v < 0;
                }

                if (!powerConsumer && component.TryGetValue("power", out v)) {
                    powerConsumer = v < 0;
                }
            }

            if (!sizeOccupant) {
                errors.Add("Nothing occupies any size!");
            }

            if (!powerConsumer) {
                errors.Add("No power consumption!");
            }

            return errors.Where(e => e.Length > 0).ToArray();
        }

        private string ValidatePrefab() =>
            null == this.prefab ? "Prefab is not set." : "";
    }
}
