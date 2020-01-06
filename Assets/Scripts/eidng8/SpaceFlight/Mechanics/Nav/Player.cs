// ---------------------------------------------------------------------------
// <copyright file="Player.cs" company="eidng8">
//      GPLv3
// </copyright>
// <summary>
// 
// </summary>
// ---------------------------------------------------------------------------

using eidng8.SpaceFlight.Configurable.Navigator;
using UnityEngine;


namespace eidng8.SpaceFlight.Mechanics.Nav
{
    /// <inheritdoc />
    [RequireComponent(typeof(Rigidbody))]
    public class Player : Navigator
    {
        /// <inheritdoc />
        public override void Configure(NavigatorConfig config) { }

        /// <inheritdoc />
        public override void FixedUpdate() { }
    }
}
