// ---------------------------------------------------------------------------
// <copyright file="AccelerationAiConfig.cs" company="eidng8">
//      GPLv3
// </copyright>
// <summary>
// 
// </summary>
// ---------------------------------------------------------------------------

using System;
using UnityEngine;


namespace eidng8.SpaceFlight.Objects.Interactive.Pilot.Ai
{
    [Serializable]
    public struct AccelerationAiConfig : IPilotConfig
    {
        /// <summary>
        /// Whether this is the player's ship. Only the player's ship will
        /// receive user events.
        /// </summary>
        [Tooltip(
            "Whether this is the player's ship."
            + " Only the player's ship will receive user events."
        )]
        public bool playerShip;

        /// <summary>The distance to keep from target.</summary>
        [Tooltip("The distance to keep from target.")]
        public float safeDistance;
    }
}
