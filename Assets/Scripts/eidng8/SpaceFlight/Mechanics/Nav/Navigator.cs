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
    /// <inheritdoc />
    public abstract class Navigator : INavigator
    {
        private Transform _target;
        protected IMovableObject mShip;

        public Transform Target {
            get => this.HasTarget ? this._target : null;
            set {
                this._target = value;
                this.HasTarget = true;
            }
        }

        /// <inheritdoc />
        public bool HasTarget { get; private set; }

        /// <inheritdoc />
        public abstract void Configure(NavigatorConfig config);

        /// <inheritdoc />
        public void Man(IMovableObject obj) {
            this.mShip = obj;
        }

        public void ClearTarget() {
            this._target = null;
            this.HasTarget = false;
        }
    }
}
