// ---------------------------------------------------------------------------
// <copyright file="PilotAi.cs" company="eidng8">
//      GPLv3
// </copyright>
// <summary>
// 
// </summary>
// ---------------------------------------------------------------------------

using eidng8.SpaceFlight.Objects.Dynamic;
using eidng8.SpaceFlight.Objects.Interactive.Automated;


namespace eidng8.SpaceFlight.Objects.Interactive.Pilot.Ai
{
    /// <inheritdoc cref="IPilotAi" />
    /// <typeparam name="TConfig"></typeparam>
    /// <typeparam name="TMotor"></typeparam>
    /// <typeparam name="TControl">
    /// Unlike controllers manned by players, who interprets the game flow
    /// by human sense. AI pilots have to obtain critical data from the
    /// attached flight control. Hence, we need a reference to it.
    /// </typeparam>
    public abstract class PilotAi<TConfig, TMotor, TControl>
        : Pilot<TConfig, TMotor>
        where TConfig : IPilotConfig, new()
        where TMotor : IMotorBase
        where TControl : IFlightController
    {
        /// <summary>
        /// Reference to the attached <see cref="IFlightController" />
        /// implementation.
        /// </summary>
        public TControl Control { protected get; set; }

        /// <summary>
        /// Calculates the appropriate throttle, and applies to the attached
        /// flight controller. This method <i>must</i> directly sets the
        /// controller's <c>Throttle</c>.
        /// </summary>
        protected abstract void DetermineThrottle();

        public override void FixedUpdate()
        {
            this.TurnToTarget();
            this.DetermineThrottle();
        }

        /// <summary>
        /// Calculates the appropriate rotation, and applies to the attached
        /// flight controller. This method <i>must</i> directly calls the
        /// controller's <c>TurnTo()</c> method.
        /// </summary>
        protected abstract void TurnToTarget();
    }
}
