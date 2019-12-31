// ---------------------------------------------------------------------------
// <copyright file="HullConfig.cs" company="eidng8">
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
         fileName = "Hull Config",
         menuName = "Configurable/Ship/Hull"
     )]
    public class HullConfig : ScriptableObject { }
}
