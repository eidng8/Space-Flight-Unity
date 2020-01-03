// ---------------------------------------------------------------------------
// <copyright file="StartupConfig.cs" company="eidng8">
//      GPLv3
// </copyright>
// <summary>
// 
// </summary>
// ---------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace eidng8.SpaceFlight.Configurable.System
{
    [Serializable,
     CreateAssetMenu(
         fileName = "Startup Config",
         menuName = "Configurable/Startup Config"
     )]
    public class StartupConfig : Configurable
    {
        [Tooltip("Default player configuration")]
        public PlayerConfig player;

        /// <inheritdoc />
        public override string InfoBoxContent =>
            "Configures the startup process of game. This happens only once"
            + " right before the splash screen.";

        /// <inheritdoc />
        public override Dictionary<string, float> Dict() => this.player.Dict();

        /// <inheritdoc />
        public override string[] Validate() =>
            new List<string> {this.ValidatePlayerConfig()}
                .Where(e => e.Length > 0)
                .ToArray();

        protected virtual string ValidatePlayerConfig() =>
            null == this.player ? "Must provide a player!" : "";
    }
}
