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
        protected IMovableObject mShip;
        private Transform _target;

        /// <inheritdoc />
        public bool HasTarget { get; private set; }

        public Transform Target {
            get => this.HasTarget ? this._target : null;
            set {
                this._target = value;
                this.HasTarget = true;
            }
        }

        public void ClearTarget() {
            this._target = null;
            this.HasTarget = false;
        }

        /// <inheritdoc />
        public abstract void Configure(NavigatorConfig config);

        /// <inheritdoc />
        public abstract void FixedUpdate();

        /// <inheritdoc />
        public void Man(IMovableObject obj) {
            this.mShip = obj;
        }
    }
}
