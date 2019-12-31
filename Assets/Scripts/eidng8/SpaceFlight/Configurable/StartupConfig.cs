// ---------------------------------------------------------------------------
// <copyright file="StartupConfig.cs" company="eidng8">
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
         fileName = "Startup Config",
         menuName = "Configurable/StartupConfig"
     )]
    public class StartupConfig : ScriptableObject
    {
        [Tooltip("Default player configuration")]
        public PlayerConfig player;
    }
}
