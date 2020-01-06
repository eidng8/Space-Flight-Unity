// ---------------------------------------------------------------------------
// <copyright file="UserEventArgs.cs" company="eidng8">
//      GPLv3
// </copyright>
// <summary>
// 
// </summary>
// ---------------------------------------------------------------------------

using System;
using UnityEngine;


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
        public Transform source;

        /// <summary>The object to be acted on.</summary>
        public Transform target;
    }
}
