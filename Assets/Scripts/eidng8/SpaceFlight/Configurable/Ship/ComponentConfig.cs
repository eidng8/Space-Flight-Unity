// ---------------------------------------------------------------------------
// <copyright file="ComponentConfig.cs" company="eidng8">
//      GPLv3
// </copyright>
// <summary>
// 
// </summary>
// ---------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using eidng8.SpaceFlight.Laws;
using UnityEngine;


namespace eidng8.SpaceFlight.Configurable.Ship
{
    public abstract class ComponentConfig : ObjectConfigurable
    {
        /// <summary>
        /// Positive value denotes how much power the component generates;
        /// negative value denotes constant power consumption of the component.
        /// </summary>
        [Header("Ship Component Attributes"),
         Tooltip(
             "Positive value denotes how much power the component generates; "
             + "negative value denotes constant power consumption of the component. "
         )]
        public float power;

        /// <summary>
        /// Positive value denotes how much space the component provides;
        /// negative value denotes how much space the component occupies.
        /// </summary>
        [Tooltip(
            "Positive value denotes how much space the component provides; "
            + "negative value denotes how much space the component occupies."
        )]
        public float size;

        /// <inheritdoc />
        public override Dictionary<string, float> Dict() {
            Dictionary<string, float> dict = base.Dict();
            dict["size"] = this.size;
            dict["power"] = this.power;
            return dict;
        }

        /// <inheritdoc />
        public override string[] Validate() =>
            new List<string>(base.Validate()) {
                    this.ValidateNegativeSize()
                }
                .Where(e => e.Length > 0)
                .ToArray();

        /// <summary>
        /// Validate that <see cref="power" /> is negative. Sets it to negative
        /// if not, besides returning an error message.
        /// </summary>
        /// <returns>
        /// An error message if the validation doesn't pass, otherwise an empty
        /// string.
        /// </returns>
        protected virtual string ValidateNegativePower() =>
            this.power.ValidateNegativeValue(
                "Power",
                null,
                () => this.power = -this.power
            );

        /// <summary>
        /// Validate that <see cref="size" /> is negative. Sets it to negative
        /// if not, besides returning an error message.
        /// </summary>
        /// <returns>
        /// An error message if the validation doesn't pass, otherwise an empty
        /// string.
        /// </returns>
        protected virtual string ValidateNegativeSize() =>
            this.size.ValidateNegativeValue(
                "Size",
                null,
                () => this.size = -this.size
            );

        /// <summary>
        /// Validate that <see cref="power" /> is positive. Sets it to positive
        /// if not, besides returning an error message.
        /// </summary>
        /// <returns>
        /// An error message if the validation doesn't pass, otherwise an empty
        /// string.
        /// </returns>
        protected virtual string ValidatePositivePower() =>
            this.power.ValidatePositiveValue(
                "Power",
                null,
                () => this.power = -this.power
            );

        /// <summary>
        /// Validate that <see cref="size" /> is positive. Sets it to positive
        /// if not, besides returning an error message.
        /// </summary>
        /// <returns>
        /// An error message if the validation doesn't pass, otherwise an empty
        /// string.
        /// </returns>
        protected virtual string ValidatePositiveSize() =>
            this.size.ValidatePositiveValue(
                "Size",
                null,
                () => this.size = -this.size
            );
    }
}
