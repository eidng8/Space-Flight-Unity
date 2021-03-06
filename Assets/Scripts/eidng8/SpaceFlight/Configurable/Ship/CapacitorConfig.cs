﻿// ---------------------------------------------------------------------------
// <copyright file="CapacitorConfig.cs" company="eidng8">
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
    /// Capacitors store excessive power generated by generators and store
    /// them for later use. Components that are used on-demand consume
    /// energy stored in capacitors. The recharge rate of capacitors is
    /// determined by two factors: the capacitors' <see cref="recharge" />
    /// value, and the generators' <see cref="PowerGenerator.power" />
    /// value. Whichever smaller is used as the effective recharge rate.
    /// </summary>
    [Serializable,
     CreateAssetMenu(
         fileName = "Capacitor Config",
         menuName = "Configurable/Ship/Capacitor"
     )]
    public class CapacitorConfig : ComponentConfig
    {
        /// <summary>Maximum energy it can store.</summary>
        [Header("Capacitor Attributes"),
         Tooltip("Maximum energy it can store.")]
        public float capacity;

        /// <summary>
        /// How fast the capacitor recharges itself. Shall be smaller than
        /// absolute value of <see cref="ComponentConfig.power" />.
        /// </summary>
        [Tooltip(
            "How fast the capacitor recharges itself. "
            + "Shall be smaller than absolute value of power."
        )]
        public float recharge;

        /// <inheritdoc />
        public override string InfoBoxContent =>
            "Capacitors store excessive power generated by generators and store"
            + " them for later use. Components that are used on-demand consume"
            + " energy stored in capacitors.\n"
            + "The recharge rate of capacitors is determined by two factors:"
            + " the capacitors' recharge value, and the generators' excessive"
            + " power value. Whichever smaller is used as the effective"
            + " recharge rate.";

        /// <inheritdoc />
        public override Dictionary<string, float> Dict() {
            Dictionary<string, float> dict = base.Dict();
            dict["capacitor"] = this.capacity;
            dict["recharge"] = this.recharge;
            return dict;
        }

        /// <inheritdoc />
        public override string[] Validate() =>
            new List<string>(base.Validate()) {
                    this.ValidateNegativePower(),
                    this.ValidatePositiveCapacity()
                }
                .Where(e => e.Length > 0)
                .ToArray();

        /// <summary>
        /// Validate that <see cref="capacity" /> is positive. Sets it to
        /// positive if not, besides returning an error message.
        /// </summary>
        /// <returns>
        /// An error message if the validation doesn't pass, otherwise an empty
        /// string.
        /// </returns>
        protected virtual string ValidatePositiveCapacity() =>
            this.capacity.ValidatePositiveValue(
                "Capacitor (capacity)",
                null,
                () => this.capacity = -this.capacity
            );
    }
}
