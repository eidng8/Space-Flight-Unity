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
        }

        private void Accelerate(UserEventArgs args) {
            this.mShip.PropelThrottle(args.acceleration);
        }
    }
}
