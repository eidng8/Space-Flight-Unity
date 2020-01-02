// ---------------------------------------------------------------------------
// <copyright file="Configurable.cs" company="eidng8">
//      GPLv3
// </copyright>
// <summary>
// 
// </summary>
// ---------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace eidng8.SpaceFlight.Configurable
{
    public abstract class Configurable : ScriptableObject, IConfigurable
    {
        [Header("Basic Attributes"), TextArea]
        public string description;

        public string id;

        public float mass;

        /// <inheritdoc />
        public virtual Dictionary<string, float> Aggregate() => this.Dict();

        /// <inheritdoc />
        public virtual Dictionary<string, float> Dict() =>
            new Dictionary<string, float> {{"mass", this.mass}};

        /// <inheritdoc />
        public virtual string[] Validate() => new string[0];

        protected virtual Dictionary<string, float> Aggregate(
            IEnumerable<Dictionary<string, float>> items
        ) {
            Dictionary<string, float> dict = this.Dict();
            foreach (Dictionary<string, float> item in items) {
                item.ToList()
                    .ForEach(
                        attr => {
                            // energy is per use basis, we just need the
                            // total energy capacity here.
                            if ("energy" == attr.Key) {
                                if (attr.Value > 0) {
                                    dict[attr.Key] =
                                        dict.TryGetValue(attr.Key, out float v)
                                            ? v + attr.Value
                                            : attr.Value;
                                }
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
    }
}
