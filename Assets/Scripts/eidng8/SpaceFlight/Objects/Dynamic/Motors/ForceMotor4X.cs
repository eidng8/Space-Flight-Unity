// ---------------------------------------------------------------------------
// <copyright file="EventChannels.cs" company="eidng8">
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
    /// <inheritdoc />
    /// <remarks>
    /// This is the full physics motor. It uses rigid body force from
    /// Unity.
    /// </remarks>
    // ReSharper disable once ClassWithVirtualMembersNeverInherited.Global
    public class ForceMotor4X : ThrottledMotor4X<ForceMotor4XConfig>
    {
        /// <inheritdoc />
        /// <remarks>Newton's 2nd law: <c>F=ma</c>.</remarks>
        public override float Acceleration =>
            this.GenerateThrust() / this.config.mass;

        /// <inheritdoc />
        /// <remarks>This is the force.</remarks>
        public override float GenerateThrust() =>
            (this.Throttle > 0
                ? this.config.maxForward
                : this.config.maxBackward)
            * this.Throttle;

        /// <inheritdoc />
        public override Vector3 GenerateTorque(float deltaTime) =>
            throw new NotImplementedException();

        /// <inheritdoc />
        public override Vector3 GeneratePanThrust(float deltaTime) =>
            throw new NotImplementedException();
    }
}
