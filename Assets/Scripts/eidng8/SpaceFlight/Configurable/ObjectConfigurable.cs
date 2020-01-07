// ---------------------------------------------------------------------------
// <copyright file="ObjectConfigurable.cs" company="eidng8">
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


namespace eidng8.SpaceFlight.Configurable
{
    public abstract class ObjectConfigurable : Configurable
    {
        /// <summary>Mass of the component. Used by physics engine.</summary>
        [Header("Basic Attributes"),
         Tooltip("Mass of the component. Used by physics engine.")]
        public float mass;

        /// <summary>
        /// Text description of the configurable suitable for in-game display.
        /// </summary>
        /// <todo>
        /// Currently this is not used. It's supposed to be implemented while
        /// proper localization facility is utilized.
        /// </todo>
        public virtual string Description => "";

        /// <inheritdoc />
        public override Dictionary<string, float> Dict() =>
            new Dictionary<string, float> {{"mass", this.mass}};

        /// <inheritdoc />
        public override string[] Validate() =>
            this.mass > 0
                ? new string[0]
                : new[] {"Mass must be greater than zero!"};

        /// <summary>Aggregate given component configurations.</summary>
        /// <param name="components"></param>
        /// <returns></returns>
        protected virtual Dictionary<string, float> Aggregate(
            IEnumerable<Dictionary<string, float>> components
        ) {
            Dictionary<string, float> dict = this.Dict();
            foreach (Dictionary<string, float> item in components) {
                item?.ToList()
                    .ForEach(
                        attr => {
                            // energy is per use basis, we just need the
                            // total energy capacity here.
                            if ("energy" != attr.Key) {
                                dict[attr.Key] =
                                    dict.TryGetValue(attr.Key, out float v)
                                        ? v + attr.Value
                                        : attr.Value;
                            }
                        }
                    );
            }

            return dict;
        }

        /// <summary>
        /// Validate that <see cref="mass" /> is positive. Sets it to positive
        /// if not, besides returning an error message.
        /// </summary>
        /// <returns>
        /// An error message if the validation doesn't pass, otherwise an empty
        /// string.
        /// </returns>
        protected virtual string ValidatePositiveMass() =>
            this.mass.ValidatePositiveValue(
                "Mass",
                null,
                () => this.mass = -this.mass
            );
    }
}
