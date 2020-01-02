// ---------------------------------------------------------------------------
// <copyright file="IMovableObject.cs" company="eidng8">
//      GPLv3
// </copyright>
// <summary>
// 
// </summary>
// ---------------------------------------------------------------------------

using UnityEngine;


namespace eidng8.SpaceFlight.Objects
{
    public interface IMovableObject
    {
        /// <summary>
        /// Velocity in all directions.
        /// </summary>
        Vector3 Velocity { get; }

        /// <summary>
        /// Forward speed value.
        /// </summary>
        float Speed { get; }

        /// <summary>
        /// Forward acceleration value.
        /// </summary>
        float Acceleration { get; }

        /// <summary>
        /// Maximum forward movement momentum.
        /// </summary>
        float MaxForward { get; }

        /// <summary>
        /// Maximum backward movement momentum.
        /// </summary>
        float MaxReverse { get; }

        /// <summary>
        /// Maximum side-way movement momentum.
        /// </summary>
        float MaxPan { get; }

        /// <summary>
        /// Maximum angular momentum.
        /// </summary>
        float MaxTorque { get; }

        /// <summary>
        /// Perform actual movement.
        /// </summary>
        /// <param name="force"></param>
        /// <param name="torque"></param>
        void Move(Vector3 force, Vector3 torque);
    }
}
