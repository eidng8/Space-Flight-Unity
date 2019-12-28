// ---------------------------------------------------------------------------
// <copyright file="ExtendedEventArgs.cs" company="eidng8">
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
    public class ExtendedEventArgs : EventArgs
    {
        /// <summary>The object that triggers the event</summary>
        public GameObject source;

        /// <summary>The object to be acted on.</summary>
        public GameObject target;
    }
}
