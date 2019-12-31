// ---------------------------------------------------------------------------
// <copyright file="PlayerConfig.cs" company="eidng8">
//      GPLv3
// </copyright>
// <summary>
// 
// </summary>
// ---------------------------------------------------------------------------

using System;
using UnityEngine;


namespace eidng8.SpaceFlight.Configurable
{
    [Serializable,
     CreateAssetMenu(
         fileName = "Player Config",
         menuName = "Configurable/Player"
     )]
    public class PlayerConfig : ScriptableObject
    {
        [Tooltip("Player name")]
        public string id = "Player";

        [Tooltip("Current ship")]
        public ShipConfig ship;
    }
}
