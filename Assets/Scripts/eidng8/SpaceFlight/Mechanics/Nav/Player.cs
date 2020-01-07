// ---------------------------------------------------------------------------
// <copyright file="Player.cs" company="eidng8">
//      GPLv3
// </copyright>
// <summary>
// 
// </summary>
// ---------------------------------------------------------------------------

using eidng8.SpaceFlight.Configurable.Navigator;
using eidng8.SpaceFlight.Events;
using eidng8.SpaceFlight.Managers;
using UnityEngine;


namespace eidng8.SpaceFlight.Mechanics.Nav
{
    /// <inheritdoc />
    public class Player : Navigator
    {
        public Player() => this.Init();

        /// <inheritdoc />
        public override void Configure(NavigatorConfig config) { }

        /// <inheritdoc />
        public override void FixedUpdate() { }

        protected virtual void Init() {
            this.RegisterEvents();
        }

        protected virtual void RegisterEvents() =>
            EventManager.M.OnUserEvent(UserEvents.Accelerate, this.Accelerate);

        private void Accelerate(UserEventArgs args) {
            Debug.Log($"a={args.acceleration}");
            this.mShip.PropelThrottle(args.acceleration);
        }
    }
}
