// ---------------------------------------------------------------------------
// <copyright file="ForceMotor4XConfig.cs" company="eidng8">
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
    [Serializable]
    public struct ForceMotor4XConfig : IMotorConfig
    {
        /// <summary>
        /// The mass this motor is carrying. Any flight controller that uses
        /// this motor should set this value to the attached <c>RigidBody</c>.
        /// </summary>
        [HideInInspector]
        public float mass;

        /// <summary>Maximum forward force.</summary>
        public float maxForward;

        /// <summary>Maximum backward force.</summary>
        public float maxBackward;

        /// <summary>Maximum torque.</summary>
        public Vector3 maxTorque;

        /// <summary>Maximum panning force.</summary>
        public Vector3 maxPan;
    }
}
