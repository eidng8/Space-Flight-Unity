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
        public string id;

        public string description;

        /// <inheritdoc />
        public virtual Dictionary<string, float> Dict() =>
            new Dictionary<string, float>();

        /// <inheritdoc />
        public virtual Dictionary<string, float> Aggregate() => this.Dict();

        protected virtual Dictionary<string, float> Aggregate(
            IEnumerable<Dictionary<string, float>> items
        ) {
            Dictionary<string, float> dict = this.Dict();
            foreach (Dictionary<string, float> item in items) {
                item.ToList()
                    .ForEach(
                        attr => dict[attr.Key] =
                            dict.TryGetValue(attr.Key, out float v)
                                ? v + attr.Value
                                : attr.Value
                    );
            }

            return dict;
        }
    }
}
