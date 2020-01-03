// ---------------------------------------------------------------------------
// <copyright file="ObjectConfigurable.cs" company="eidng8">
//      GPLv3
// </copyright>
// <summary>
// 
// </summary>
// ---------------------------------------------------------------------------

using System.Collections.Generic;
using UnityEngine;


namespace eidng8.SpaceFlight.Configurable
{
    public abstract class Configurable : ScriptableObject, IConfigurable
    {
        /// <inheritdoc />
        public virtual Dictionary<string, float> Aggregate() => this.Dict();

        /// <inheritdoc />
        public virtual string InfoBoxContent => "";

        /// <inheritdoc />
        public abstract Dictionary<string, float> Dict();

        /// <inheritdoc />
        public abstract string[] Validate();

        protected virtual void OnValidate() {
            foreach (string error in this.Validate()) {
                Debug.LogWarning($"{this.name}: {error}");
            }
        }
    }
}
