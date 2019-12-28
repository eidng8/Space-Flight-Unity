// ---------------------------------------------------------------------------
// <copyright file="EventChannels.cs" company="eidng8">
//      GPLv3
// </copyright>
// <summary>
// 
// </summary>
// ---------------------------------------------------------------------------

namespace eidng8.SpaceFlight.Objects.Dynamic
{
    /// <inheritdoc />
    public abstract class Motor<TC> : IMotor where TC : IMotorConfig
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
        public abstract float GenerateTorque(float deltaTime);

        public TC GetConfig() => this.config;
    }
}
