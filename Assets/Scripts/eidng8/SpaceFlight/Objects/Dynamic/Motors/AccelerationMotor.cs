// ---------------------------------------------------------------------------
// <copyright file="EventChannels.cs" company="eidng8">
//      GPLv3
// </copyright>
// <summary>
// 
// </summary>
// ---------------------------------------------------------------------------

using UnityEngine;


namespace eidng8.SpaceFlight.Objects.Dynamic.Motors
{
    /// <inheritdoc />
    /// <remarks>A motor that works on constant acceleration.</remarks>
    // ReSharper disable once ClassWithVirtualMembersNeverInherited.Global
    public class AccelerationMotor : ThrottledMotor<AccelerationMotorConfig>
    {
        // ReSharper disable once MemberCanBePrivate.Global
        protected Vector3 turnTarget;

        // ReSharper disable once MemberCanBePrivate.Global
        protected Quaternion roll;

        // ReSharper disable once MemberCanBePrivate.Global
        protected float velocity;

        /// <inheritdoc />
        public override float Acceleration =>
            (this.Throttle < 0
                ? this.config.maxDeceleration
                : this.config.maxAcceleration)
            * this.Throttle;

        /// <inheritdoc />
        public override void Configure(IMotorConfig cfg)
        {
            base.Configure(cfg);
            this.roll = this.config.rotation;
        }

        /// <inheritdoc />
        /// <returns>The acceleration value.</returns>
        public override float GenerateThrust() => this.Acceleration;

        /// <inheritdoc />
        /// <returns>The rotation delta.</returns>
        public override float GenerateTorque(float deltaTime) =>
            this.config.maxTurn * deltaTime;

        /// <summary>Returns the next rotation quaternion in <c>deltaTime</c>.</summary>
        /// <param name="deltaTime"></param>
        /// <returns></returns>
        public virtual Quaternion GetRoll(float deltaTime)
        {
            if (this.turnTarget == Vector3.zero) {
                return Quaternion.identity;
            }

            Quaternion look = Quaternion.LookRotation(this.turnTarget);
            float thrust = this.GenerateTorque(deltaTime);
            this.roll = Quaternion.Lerp(this.roll, look, thrust);

            return this.roll;
        }

        /// <summary>Calculates the velocity value in <c>deltaTime</c>.</summary>
        /// <param name="deltaTime"></param>
        /// <returns></returns>
        public virtual float GetVelocity(float deltaTime)
        {
            this.velocity = Mathf.Clamp(
                this.velocity + this.Acceleration * deltaTime,
                0,
                this.config.maxSpeed
            );
            return this.velocity;
        }

        /// <summary>Turn to face the <c>target</c>.</summary>
        /// <param name="target"></param>
        public virtual void TurnTo(Vector3 target)
        {
            this.turnTarget = target;
        }
    }
}
