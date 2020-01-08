// ---------------------------------------------------------------------------
// <copyright file="UserEventArgs.cs" company="eidng8">
//      GPLv3
// </copyright>
// <summary>
// 
// </summary>
// ---------------------------------------------------------------------------

using System;
using eidng8.SpaceFlight.Objects;

namespace eidng8.SpaceFlight.Events
{
    [Serializable]
    public class UserEventArgs : ExtendedEventArgs
    {
        /// <summary>Acceleration delta.</summary>
        public float acceleration;

        /// <summary>Whether the event has a source.</summary>
        public bool hasSource;

        /// <summary>Whether the event has a target.</summary>
        public bool hasTarget;

        /// <summary>The object that triggers the event</summary>
        public SpaceObject source;

        /// <summary>The object to be acted on.</summary>
        public SpaceObject target;
    }
}
