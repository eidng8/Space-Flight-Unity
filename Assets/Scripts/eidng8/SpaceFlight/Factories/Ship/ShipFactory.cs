// ---------------------------------------------------------------------------
// <copyright file="ShipFactory.cs" company="eidng8">
//      GPLv3
// </copyright>
// <summary>
// 
// </summary>
// ---------------------------------------------------------------------------

using eidng8.SpaceFlight.Configurable.Ship;
using UnityEngine;
using ShipScript = eidng8.SpaceFlight.Objects.Movable.Ship;


namespace eidng8.SpaceFlight.Factories.Ship
{
    public static class ShipFactory
    {
        public static ShipScript Make(
            ShipConfig cfg = null,
            Vector3 pos = default,
            Quaternion rot = default
        ) {
            ShipScript ship = Object.Instantiate(cfg.prefab);
            ship.name = $"Ship {Time.time}.{Random.value}";
            Transform transform = ship.transform;
            transform.position = pos;
            transform.rotation = rot;
            ship.Configure(cfg);
            return ship;
        }
    }
}
