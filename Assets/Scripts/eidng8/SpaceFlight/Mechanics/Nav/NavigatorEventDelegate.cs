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
    public class NavigatorEventDelegate : Navigator
    {
        public NavigatorEventDelegate() {
            this.Init();
        }

        /// <inheritdoc />
        public override void Configure(NavigatorConfig config) { }

        private void Init() {
            this.RegisterEvents();
        }

        protected virtual void RegisterEvents() {
            EventManager.OnUserEvent(UserEvents.Accelerate, this.Accelerate);
            EventManager.OnUserEvent(UserEvents.Horizontal, this.Horizontal);
            EventManager.OnUserEvent(UserEvents.Vertical, this.Vertical);
            EventManager.OnUserEvent(UserEvents.Pitch, this.Pitch);
            EventManager.OnUserEvent(UserEvents.Roll, this.Roll);
            EventManager.OnUserEvent(UserEvents.Yaw, this.Yaw);
            EventManager.OnUserEvent(UserEvents.Jump, this.Jump);
            EventManager.OnUserEvent(UserEvents.Stabilize, this.Stabilize);
            EventManager.OnUserEvent(UserEvents.FullStop, this.FullStop);
        }

        private void Stabilize(UserEventArgs _) {
            this.mShip.Stabilize();
        }

        private void FullStop(UserEventArgs _) {
            this.mShip.FullStop();
        }

        private void Jump(UserEventArgs _) { }

        private void Yaw(UserEventArgs args) {
            this.mShip.RotateThrottle(Vector3.up * args.delta);
        }

        private void Roll(UserEventArgs args) {
            this.mShip.RotateThrottle(Vector3.forward * args.delta);
        }

        private void Pitch(UserEventArgs args) {
            this.mShip.RotateThrottle(Vector3.right * args.delta);
        }

        private void Vertical(UserEventArgs args) { }

        private void Horizontal(UserEventArgs args) { }

        private void Accelerate(UserEventArgs args) {
            this.mShip.PropelThrottle(args.delta);
        }
    }
}
