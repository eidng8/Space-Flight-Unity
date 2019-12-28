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
    /// This controller uses full physics. Physics used: Newton's
    /// laws.
    /// </remarks>
    [RequireComponent(typeof(Rigidbody))]
    public abstract class Force4XController<TPilot, TPilotConfig>
        : FlightController<ForceMotor4X, ForceMotor4XConfig, TPilot,
                TPilotConfig>,
            IThrottledFlightController
        where TPilot : IPilot, new()
        where TPilotConfig : IPilotConfig
    {
        /// <inheritdoc />
        public float Throttle {
            get => this.Motor.Throttle;
            set => this.Motor.Throttle = value;
        }


        protected override void FixedUpdate()
        {
            base.FixedUpdate();
            this.Body.AddForce(
                this.Motor.GenerateThrust() * this.transform.forward
            );
        }
    }
}
