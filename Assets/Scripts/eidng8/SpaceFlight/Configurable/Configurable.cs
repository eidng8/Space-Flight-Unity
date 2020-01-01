// ---------------------------------------------------------------------------
// <copyright file="Configurable.cs" company="eidng8">
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
        public string id;

        /// <inheritdoc />
        public virtual Dictionary<string, float> Dict() =>
            new Dictionary<string, float>();
    }
}
