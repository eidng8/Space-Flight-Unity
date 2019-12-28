// ---------------------------------------------------------------------------
// <copyright file="FlightController.cs" company="eidng8">
//      GPLv3
// </copyright>
// <summary>
// 
// </summary>
// ---------------------------------------------------------------------------

using eidng8.SpaceFlight.Objects.Dynamic;
using eidng8.SpaceFlight.Objects.Interactive.Pilot;
using UnityEngine;


namespace eidng8.SpaceFlight.Objects.Interactive.Automated.Controllers
{
    /// <inheritdoc cref="IFlightController" />
    /// <remarks>
    /// One may see that there is no definition here that hints on how the
    /// controller interacts with motor. This is because the vast
    /// differences among different types of applied physics there. Say
    /// motions by force and acceleration need to work with completely
    /// different sets of variables applied to the object.
    /// </remarks>
    public abstract class FlightController
        <TMotor, TMotorConfig, TPilot, TPilotConfig>
        : AutomatedController, IFlightController
        where TMotor : IMotorBase, new()
        where TMotorConfig : IMotorConfig
        where TPilot : IPilot, new()
        where TPilotConfig : IPilotConfig
    {
        public TMotorConfig motorConfig;

        public TPilotConfig pilotConfig;

        /// <summary>Reference to a IMotor concrete class.</summary>
        protected TMotor Motor;

        protected TPilot Pilot;

        protected virtual void Awake()
        {
            this.Motor = new TMotor();
            this.ConfigureMotor();
            this.Pilot = new TPilot();
            this.ConfigurePilot();
        }

        protected virtual void ConfigureMotor()
        {
            this.Motor.Configure(this.motorConfig);
        }

        protected virtual void ConfigurePilot()
        {
            this.Pilot.Configure(this.pilotConfig);
            this.Pilot.TakeControlOfMotor(this.Motor);
            this.Pilot.Awake();
        }

        protected virtual void FixedUpdate()
        {
            this.Pilot.FixedUpdate();
        }

        /// <inheritdoc />
        public virtual float Speed => this.Body.velocity.magnitude;

        /// <inheritdoc />
        public virtual Vector3 Velocity => this.Body.velocity;

        /// <inheritdoc />
        public virtual float DistanceTo(Vector3 target) =>
            Vector3.Distance(this.transform.position, target);

        /// <inheritdoc />
        /// <remarks>
        /// <a
        ///     href="https://www.math10.com/en/algebra/formulas-for-short-multiplication.html">
        /// Polynomial Identities
        /// </a>
        /// and
        /// <a
        ///     href="https://opentextbc.ca/physicstestbook2/chapter/motion-equations-for-constant-acceleration-in-one-dimension/">
        /// Motion
        /// </a>
        /// . Ah! Back to physics and maths. The two links provide lectures
        /// needed for this calculation. Here we have to find out the time
        /// needed to cover the distance. We use the formula with initial speed
        /// and constant acceleration: <c>d=vt+at²</c>. The formula is then
        /// transformed as following:
        /// <code>
        /// => at² + vt = d
        /// 
        /// * Both side divide by `a`
        ///          v      d
        /// => t² + ---t = ---
        ///          a      a
        /// 
        /// * We add the same "thing" to both side of the formula, to make
        /// * it a quadratic formula, so we can use Polynomial Identities.
        /// * Which reads <c>(x + y)² = x² + 2xy + y²</c>
        /// * The tricky bit here is to find that "thing".
        /// 
        ///          v       v       d      v
        /// => t² + ───t + (───)² = ─── + (───)²
        ///          a      2a       a     2a
        /// 
        ///              ^^^^^^^^       ^^^^^^^^
        /// 
        /// * Now we also need to simplify the right side a bit too.
        /// * Multiplying same "thing" to both numerator and denominator
        /// * won't change the faction.
        /// 
        ///          v       v       4ad     v
        /// => t² + ───t + (───)²  = ─── + (───)²
        ///          a      2a       4a²    2a
        ///                          ^^^
        ///                          ×`4a`
        /// 
        /// * Polynomial Identities to the left, and simplified the right
        /// 
        ///          v      4ad + v²
        /// => (t + ───)² = ────────
        ///         2a         4a²
        /// 
        /// * Square root both sides, remember the `±` sign.
        ///                 __________
        ///         v    ± √ 4ad + v²
        /// => t + ─── = ─────────────
        ///        2a         2a
        /// 
        ///           __________
        ///        ± √ 4ad + v²     v
        /// => t = ───────────── − ───
        ///             2a         2a
        /// 
        ///           __________
        ///        ± √ 4ad + v²  − v
        /// => t = ─────────────────
        ///               2a
        /// </code>
        /// </remarks>
        /// <param name="distance">Distance to be covered.</param>
        /// <returns>
        /// The estimated time of arrival. In case of deceleration,
        /// <c>float.PositiveInfinity</c> may be returned if it couldn't reach
        /// the target. The actual unit is not crucial in most circumstances.
        /// One could think it were in seconds.
        /// </returns>
        public virtual float EstimatedArrival(float distance)
        {
            float v = this.Speed;
            float a = this.Motor.Acceleration;

            //                         __________
            // We first calculate the √ 4ad + v²  part.
            // If we're decelerating, `4ad + v²` could become negative.
            // Because `a` could be a big negative number.
            // Which means we'll never reach target if decelerate.
            float n = 4 * a * distance + Mathf.Pow(v, 2);
            if (n <= 0) {
                return float.PositiveInfinity;
            }

            n = Mathf.Sqrt(n);
            float a2 = 2 * a;

            // We first check the positive sign, if it yields a positive
            // value, there is no need to check the negative part.
            float t = (n - v) / a2;
            if (t > 0) {
                return t;
            }

            return (-n - v) / a2;
        }

        /// <inheritdoc />
        public virtual bool IsFacing(Vector3 target, float tolerance = 45)
        {
            Transform me = this.transform;
            Vector3 dir = target - me.position;
            float ang = Vector3.Angle(dir, me.forward);
            tolerance = Mathf.Clamp(tolerance, 0, 360);
            return ang >= -tolerance && ang <= tolerance
                   || ang >= 360 - tolerance;
        }
    }
}
