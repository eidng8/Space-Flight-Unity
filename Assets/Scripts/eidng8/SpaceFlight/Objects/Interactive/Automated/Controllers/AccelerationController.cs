// ---------------------------------------------------------------------------
// <copyright file="EventChannels.cs" company="eidng8">
//      GPLv3
// </copyright>
// <summary>
// 
// </summary>
// ---------------------------------------------------------------------------

using eidng8.SpaceFlight.Objects.Dynamic.Motors;
using eidng8.SpaceFlight.Objects.Interactive.Pilot;
using UnityEngine;


namespace eidng8.SpaceFlight.Objects.Interactive.Automated.Controllers
{
    /// <inheritdoc cref="FlightController{TM,TMC,TP,TPC}" />
    /// <remarks>
    /// This controller uses acceleration. So it's not fully physical.
    /// Physics used: Motion with constant acceleration.
    /// </remarks>
    [RequireComponent(typeof(Rigidbody))]
    public abstract class AccelerationController<TPilot, TPilotConfig>
        : FlightController<AccelerationMotor, AccelerationMotorConfig,
                TPilot, TPilotConfig>,
            IThrottledFlightController
        where TPilot : IPilot, new()
        where TPilotConfig : IPilotConfig
    {
        /// <inheritdoc />
        public virtual float Throttle {
            get => this.motor.Throttle;
            set => this.motor.Throttle = value;
        }

        /// <inheritdoc />
        protected override void ConfigureMotor()
        {
            this.motorConfig.rotation = this.transform.rotation;
            base.ConfigureMotor();
        }

        /// <summary>
        /// Calculate and apply velocity to game object. It should be called in
        /// <c>FixedUpdate()</c>.
        /// <para>
        /// Remember that it is doing actual physics calculation here. Though
        /// Unity reliefs us from a lot of burden. We still need to have
        /// Newton's Laws in mind to understand the outcome of such
        /// calculation.
        /// </para>
        /// </summary>
        protected virtual void ApplySpeed()
        {
            float velocity = this.motor.GetVelocity(Time.fixedDeltaTime);
            this.Body.velocity = velocity * this.transform.forward;
        }

        /// <summary>Actually makes the turn.</summary>
        protected virtual void ApplyTurn()
        {
            this.transform.rotation = this.motor.GetRoll(Time.fixedDeltaTime);
        }

        protected override void FixedUpdate()
        {
            base.FixedUpdate();
            this.ApplyTurn();
            this.ApplySpeed();
        }
    }
}
