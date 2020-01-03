// ---------------------------------------------------------------------------
// <copyright file="ShipFactory.cs" company="eidng8">
//      GPLv3
// </copyright>
// <summary>
// 
// </summary>
// ---------------------------------------------------------------------------

using System.Runtime.CompilerServices;
using eidng8.SpaceFlight.Configurable.Ship;
using eidng8.SpaceFlight.Managers;
using ShipScript = eidng8.SpaceFlight.Objects.Movable.Ship;
using UnityEngine;


namespace eidng8.SpaceFlight.Factories.Ship
{
    public static class ShipFactory
    {
        public static GameObject Make(
            ShipConfig cfg = null,
            Vector3 pos = default(Vector3),
            Quaternion rot = default(Quaternion)
        ) {
            string name = $"Ship {Time.time}.{Random.value}";
            GameObject go = new GameObject(name) {
                transform = {position = pos, rotation = rot},
            };
            ShipFactory.Configure(go, cfg);
            return go;
        }

        private static GameObject CreateDefaultShip() =>
            (GameObject)GameObject.Instantiate(
                Resources.Load(GameManager.Gm.PrefabFile("Small Ship"))
            );

        private static void Configure(GameObject go, ShipConfig cfg = null) {
            ShipScript ship = go.AddComponent<ShipScript>();
            if (null == cfg) {
                cfg = Resources.Load<ShipConfig>("Data/Ships/Small Ship");
            }

            ship.Configure(cfg);
        }
    }
}
