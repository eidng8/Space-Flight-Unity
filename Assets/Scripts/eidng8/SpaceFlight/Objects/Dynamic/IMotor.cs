// ---------------------------------------------------------------------------
// <copyright file="EventChannels.cs" company="eidng8">
//      GPLv3
// </copyright>
// ---------------------------------------------------------------------------

namespace eidng8.SpaceFlight.Objects.Dynamic
{
    /// <summary>
    /// Motors are representation of propulsion systems. Every flight
    /// controller has to have exactly one motor.
    /// <para>
    /// It is important to remember that this an entirely different branch
    /// from the <see cref="IMotor4X" /> interface. Every implementation in
    /// this branch must work from ground up. There is no inheritance
    /// between the two branches.
    /// </para>
    /// </summary>
    public interface IMotor : IMotorBase
    {
        /// <summary>Current rotation thrust value.</summary>
        float GenerateTorque(float deltaTime);
    }
}
