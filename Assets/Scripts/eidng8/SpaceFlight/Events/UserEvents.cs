// ---------------------------------------------------------------------------
// <copyright file="UserEvents.cs" company="eidng8">
//      GPLv3
// </copyright>
// <summary>
// 
// </summary>
// ---------------------------------------------------------------------------

namespace eidng8.SpaceFlight.Events
{
    public enum UserEvents
    {
        /// <summary>
        ///     An acceleration event triggered by pressing the accelerate or
        ///     decelerate key.
        /// </summary>
        Accelerate,

        /// <summary>An selection event triggered by mouse left button click.</summary>
        Select,

        /// <summary>An contextual event triggered by mouse right button click.</summary>
        Context,

        /// <summary>An extension event triggered by mouse middle button click.</summary>
        Extension,

        Destroyed
    }
}
