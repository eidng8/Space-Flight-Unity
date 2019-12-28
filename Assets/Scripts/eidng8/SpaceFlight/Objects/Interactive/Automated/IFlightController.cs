// ---------------------------------------------------------------------------
// <copyright file="FlightController.cs" company="eidng8">
//      GPLv3
// </copyright>
// <summary>
// 
// </summary>
// ---------------------------------------------------------------------------

using UnityEngine;


namespace eidng8.SpaceFlight.Objects.Interactive.Automated
{
    /// <summary>
    /// Flight controllers are main handlers of space objects that can
    /// move. Analogous to space ships. Ships can't move by their own, they
    /// have to have propulsion systems installed. Propulsion systems are
    /// represented by concrete classes of the
    /// <see cref="eidng8.SpaceFlight.Objects.Dynamic.IMotor" /> interface.
    /// Also, you'll most likely attach controllers to rigid bodies. So
    /// don't forget to add <c>[RequireComponent(typeof(Rigidbody))]</c> to
    /// final classes that will be used.
    /// </summary>
    public interface IFlightController : IObjectController
    {
        /// <summary>Returns the current velocity magnitude.</summary>
        float Speed { get; }

        /// <summary>Returns the current velocity vector.</summary>
        Vector3 Velocity { get; }

        /// <summary>Calculates distance to the given target.</summary>
        /// <param name="target"></param>
        /// <returns></returns>
        float DistanceTo(Vector3 target);

        /// <summary>
        /// Estimates the arrival time according to current velocity and
        /// acceleration.
        /// </summary>
        float EstimatedArrival(float distance);

        /// <summary>
        /// Determine if we are facing the target. Facing doesn't mean we are
        /// directly facing it, we can have around ±45º buffer by default.
        /// </summary>
        /// <param name="target"></param>
        /// <param name="tolerance"></param>
        /// <returns></returns>
        bool IsFacing(Vector3 target, float tolerance = 45);
    }
}
