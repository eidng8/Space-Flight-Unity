// ---------------------------------------------------------------------------
// <copyright file="Navigator.cs" company="eidng8">
//      GPLv3
// </copyright>
// <summary>
// 
// </summary>
// ---------------------------------------------------------------------------

using eidng8.SpaceFlight.Configurable.Navigator;
using eidng8.SpaceFlight.Objects;
using UnityEngine;


namespace eidng8.SpaceFlight.Mechanics.Nav
{
    /// <inheritdoc cref="INavigator" />
    public abstract class Navigator : MonoBehaviour, INavigator
    {
        protected Rigidbody body;
        protected IMovableObject ship;

        /// <inheritdoc />
        public abstract void Configure(NavigatorConfig config);

        /// <inheritdoc />
        public abstract void FixedUpdate();

        /// <inheritdoc />
        public void Man(IMovableObject obj, Rigidbody body) {
            this.ship = obj;
            this.body = body;
        }
    }
}
