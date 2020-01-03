// ---------------------------------------------------------------------------
// <copyright file="ShipFactory.cs" company="eidng8">
//      GPLv3
// </copyright>
// <summary>
// 
// </summary>
// ---------------------------------------------------------------------------

using eidng8.SpaceFlight.Configurable.Ship;
using ShipScript = eidng8.SpaceFlight.Objects.Movable.Ship;
using UnityEngine;


namespace eidng8.SpaceFlight.Factories.Ship
{
    public static class ShipFactory
    {
        public static ShipScript Make(
            ShipConfig cfg = null,
            Vector3 pos = default(Vector3),
            Quaternion rot = default(Quaternion)
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
