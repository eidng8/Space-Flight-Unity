// ---------------------------------------------------------------------------
// <copyright file="MotorConfig.cs" company="eidng8">
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
         fileName = "Motor Config",
         menuName = "Configurable/Ship/Motor"
     )]
    public class MotorConfig : ShipComponentConfig, IConfigurable
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
