// ---------------------------------------------------------------------------
// <copyright file="ThrottleMotor4X.cs" company="eidng8">
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
    /// <remarks>
    /// This represents motors whose thrust is clamped to rang
    /// [-1,1].
    /// </remarks>
    public abstract class ThrottledMotor4X<TC> : Motor4X<TC>
        where TC : IMotorConfig
    {
        private float _throttle;

        /// <summary>Current throttle value. It is clamped to [-1, 1]</summary>
        public virtual float Throttle {
            get => this._throttle;
            set => this._throttle = Mathf.Clamp(value, -1, 1);
        }

        public virtual Vector3 TorqueThrottle { get; set; } = Vector3.zero;

        public virtual Vector3 PanThrottle { get; set; } = Vector3.zero;

        /// <inheritdoc />
        public override void FullReverse() => this._throttle = -1;

        /// <inheritdoc />
        public override void FullStop() => this._throttle = 0;

        /// <inheritdoc />
        public override void FullForward() => this._throttle = 1;
    }
}
