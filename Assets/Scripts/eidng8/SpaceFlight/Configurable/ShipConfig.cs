// ---------------------------------------------------------------------------
// <copyright file="ShipConfig.cs" company="eidng8">
//      GPLv3
// </copyright>
// <summary>
// 
// </summary>
// ---------------------------------------------------------------------------

using System;
using eidng8.SpaceFlight.Objects.Dynamic;
using UnityEngine;


namespace eidng8.SpaceFlight.Configurable
{
    [Serializable,
     CreateAssetMenu(
         fileName = "Ship Config",
         menuName = "Configurable/Ship/Ship"
     )]
    public class ShipConfig : ScriptableObject
    {
        public HullConfig hull;
        public MotorConfig motor;
    }
}
