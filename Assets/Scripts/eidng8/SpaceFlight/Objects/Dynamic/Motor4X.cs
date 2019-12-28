// ---------------------------------------------------------------------------
// <copyright file="Motor4X.cs" company="eidng8">
//      GPLv3
// </copyright>
// <summary>
// 
// </summary>
// ---------------------------------------------------------------------------

using UnityEngine;


namespace eidng8.SpaceFlight.Objects.Dynamic
{
    /// <inheritdoc />
    public abstract class Motor4X<TC> : IMotor4X where TC : IMotorConfig
    {
        protected TC config;

        /// <inheritdoc />
        public abstract float Acceleration { get; }

        /// <inheritdoc />
        public virtual void Configure(IMotorConfig cfg) =>
            this.config = (TC)cfg;

        /// <inheritdoc />
        public abstract void FullReverse();

        /// <inheritdoc />
        public abstract void FullStop();

        /// <inheritdoc />
        public abstract void FullForward();

        /// <inheritdoc />
        public abstract float GenerateThrust();

        /// <inheritdoc />
        public abstract Vector3 GenerateTorque(float deltaTime);

        /// <inheritdoc />
        public abstract Vector3 GeneratePanThrust(float deltaTime);

        public TC GetConfig() => this.config;
    }
}
