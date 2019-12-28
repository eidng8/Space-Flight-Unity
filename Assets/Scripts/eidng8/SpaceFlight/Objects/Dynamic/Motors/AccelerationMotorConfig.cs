// ---------------------------------------------------------------------------
// <copyright file="AccelerationMotorConfig.cs" company="eidng8">
//      GPLv3
// </copyright>
// <summary>
// 
// </summary>
// ---------------------------------------------------------------------------

using System;
using UnityEngine;


namespace eidng8.SpaceFlight.Objects.Dynamic.Motors
{
    /// <summary>Configuration data to <see cref="AccelerationMotor" />.</summary>
    [Serializable]
    public struct AccelerationMotorConfig : IMotorConfig
    {
        /// <summary>Maximum speed limit.</summary>
        [Tooltip("Maximum forward velocity."), Range(0, 100000)]
        public float maxSpeed;

        /// <summary>Maximum rotation speed.</summary>
        [Tooltip("Determines how quickly can the object turn."), Range(0, 180)]
        public float maxTurn;

        /// <summary>Full throttle forward acceleration value.</summary>
        [Tooltip("Maximum forward velocity."), Range(0, 100000)]
        public float maxAcceleration;

        /// <summary>Full reverse acceleration value.</summary>
        [Tooltip("Maximum forward velocity."), Range(0, 100000)]
        public float maxDeceleration;

        /// <summary>
        /// Current rotation quaternion. This is only used while configuring
        /// the motor instance. The actual rotation is not updated afterward,
        /// and has no relation to this configuration property.
        /// </summary>
        [HideInInspector]
        public Quaternion rotation;
    }
}
