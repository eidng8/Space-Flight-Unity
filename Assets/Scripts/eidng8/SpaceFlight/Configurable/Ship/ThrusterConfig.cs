// ---------------------------------------------------------------------------
// <copyright file="ThrusterConfig.cs" company="eidng8">
//      GPLv3
// </copyright>
// <summary>
// 
// </summary>
// ---------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using UnityEngine;


namespace eidng8.SpaceFlight.Configurable.Ship
{
    [Serializable,
     CreateAssetMenu(
         fileName = "Thruster Config",
         menuName = "Configurable/Ship/Thruster"
     )]
    public class ThrusterConfig : ComponentConfig, IConfigurable
    {
        public float maxForward;
        public float maxReverse;
        public float maxPan;
        public float maxTorque;

        /// <inheritdoc />
        public override Dictionary<string, float> Dict()
        {
            Dictionary<string, float> dict = base.Dict();
            dict["maxForward"] = this.maxForward;
            dict["maxReverse"] = this.maxReverse;
            dict["maxPan"] = this.maxPan;
            dict["maxTorque"] = this.maxTorque;
            return dict;
        }
    }
}
