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
        protected Vector3 TurnTarget;

        // ReSharper disable once MemberCanBePrivate.Global
        protected Quaternion Roll;

        // ReSharper disable once MemberCanBePrivate.Global
        protected float Velocity;

        /// <inheritdoc />
        public override float Acceleration =>
            (this.Throttle < 0
                ? this.Config.maxDeceleration
                : this.Config.maxAcceleration)
            * this.Throttle;

        /// <inheritdoc />
        public override void Configure(IMotorConfig config)
        {
            base.Configure(config);
            this.Roll = this.Config.rotation;
        }

        /// <inheritdoc />
        /// <returns>The acceleration value.</returns>
        public override float GenerateThrust() => this.Acceleration;

        /// <inheritdoc />
        /// <returns>The rotation delta.</returns>
        public override float GenerateTorque(float deltaTime) =>
            this.Config.maxTurn * deltaTime;

        /// <summary>Returns the next rotation quaternion in <c>deltaTime</c>.</summary>
        /// <param name="deltaTime"></param>
        /// <returns></returns>
        public virtual Quaternion GetRoll(float deltaTime)
        {
            if (this.TurnTarget == Vector3.zero) {
                return Quaternion.identity;
            }

            Quaternion look = Quaternion.LookRotation(this.TurnTarget);
            float thrust = this.GenerateTorque(deltaTime);
            this.Roll = Quaternion.Lerp(this.Roll, look, thrust);

            return this.Roll;
        }

        /// <summary>Calculates the velocity value in <c>deltaTime</c>.</summary>
        /// <param name="deltaTime"></param>
        /// <returns></returns>
        public virtual float GetVelocity(float deltaTime)
        {
            this.Velocity = Mathf.Clamp(
                this.Velocity + this.Acceleration * deltaTime,
                0,
                this.Config.maxSpeed
            );
            return this.Velocity;
        }

        /// <summary>Turn to face the <c>target</c>.</summary>
        /// <param name="target"></param>
        public virtual void TurnTo(Vector3 target)
        {
            this.TurnTarget = target;
        }
    }
}
