// ---------------------------------------------------------------------------
// <copyright file="IMotor4X.cs" company="eidng8">
//      GPLv3
// </copyright>
// <summary>
// 
// </summary>
// ---------------------------------------------------------------------------

using UnityEngine;


namespace eidng8.SpaceFlight.Objects.Dynamic
{
    /// <summary>
    /// Motors are representation of propulsion systems. Every flight
    /// controller has to have exactly one motor. Implementations of this
    /// interface provides 4 axis of movement.
    /// <para>
    /// It is important to remember that this an entirely different branch
    /// from the <see cref="IMotor" /> interface. Every implementation in
    /// this branch must work from ground up. There is no inheritance
    /// between the two branches.
    /// </para>
    /// </summary>
    public interface IMotor4X : IMotorBase
    {
        /// <summary>Current rotation thrust value.</summary>
        Vector3 GenerateTorque(float deltaTime);

        /// <summary>Current side way thrust value.</summary>
        /// <param name="deltaTime"></param>
        /// <returns></returns>
        Vector3 GeneratePanThrust(float deltaTime);
    }
}
