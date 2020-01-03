// ---------------------------------------------------------------------------
// <copyright file="Configurable.cs" company="eidng8">
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


namespace eidng8.SpaceFlight.Configurable
{
    public class Configurable : ScriptableObject, IConfigurable
    {
        [Header("Basic Attributes"),
         TextArea,
         Tooltip("Brief description of the component.")]
        public string description;

        [Tooltip("Mass of the component. Used by physics engine.")]
        public float mass;

        /// <inheritdoc />
        public virtual Dictionary<string, float> Aggregate() => this.Dict();

        /// <inheritdoc />
        public virtual string InfoBoxContent => "";

        /// <inheritdoc />
        public virtual Dictionary<string, float> Dict() =>
            new Dictionary<string, float> {{"mass", this.mass}};

        /// <inheritdoc />
        public virtual string[] Validate() =>
            this.mass > 0
                ? new string[0]
                : new[] {"Mass must be greater than zero!"};


        protected virtual Dictionary<string, float> Aggregate(
            IEnumerable<Dictionary<string, float>> items
        ) {
            Dictionary<string, float> dict = this.Dict();
            foreach (Dictionary<string, float> item in items) {
                item?.ToList()
                    .ForEach(
                        attr => {
                            // energy is per use basis, we just need the
                            // total energy capacity here.
                            if ("energy" == attr.Key) {
                                // if (attr.Value > 0) {
                                //     dict[attr.Key] =
                                //         dict.TryGetValue(attr.Key, out float v)
                                //             ? v + attr.Value
                                //             : attr.Value;
                                // }
                            } else {
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

        protected virtual void OnValidate() {
            foreach (string error in this.Validate()) {
                Debug.LogWarning($"{this.name}: {error}");
            }
        }

        /// <summary>
        /// Validate that <see cref="mass"/> is positive. Sets it to
        /// positive if not, besides returning an error message.
        /// </summary>
        /// <returns>
        /// An error message if the validation doesn't pass, otherwise an empty
        /// string.
        /// </returns>
        protected virtual string ValidatePositiveMass() =>
            Maths.ValidatePositiveValue(
                this.mass,
                "Mass",
                null,
                () => this.mass = -this.mass
            );
    }
}
