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
        /// <summary>Forward acceleration value.</summary>
        float Acceleration { get; }

        /// <summary>Maximum forward movement momentum.</summary>
        float MaxForward { get; }

        /// <summary>Maximum side-way movement momentum.</summary>
        float MaxPan { get; }

        /// <summary>Maximum backward movement momentum.</summary>
        float MaxReverse { get; }

        /// <summary>Maximum angular momentum.</summary>
        float MaxTorque { get; }

        /// <summary>Forward speed value.</summary>
        float Speed { get; }

        /// <summary>Velocity in all directions.</summary>
        Vector3 Velocity { get; }

        void Pan(Vector3 throttle);

        void PanThrottle(Vector3 throttle);

        /// <summary>Perform actual movement.</summary>
        /// <param name="force"></param>
        void Propel(float force);

        /// <summary>Perform actual movement.</summary>
        /// <param name="throttle"></param>
        void PropelThrottle(float throttle);

        /// <summary>Perform actual rotation.</summary>
        /// <param name="torque"></param>
        void Rotate(Vector3 torque);

        void RotateThrottle(Vector3 throttle);
    }
}
