// ---------------------------------------------------------------------------
// <copyright file="PowerGenerator.cs" company="eidng8">
//      GPLv3
// </copyright>
// <summary>
// 
// </summary>
// ---------------------------------------------------------------------------

using System;
using UnityEngine;


namespace eidng8.SpaceFlight.Configurable.Ship
{
    [Serializable,
     CreateAssetMenu(
         fileName = "Power Generator Config",
         menuName = "Configurable/Ship/Power Generator"
     )]
    public class PowerGenerator : ComponentConfig { }
}
