// ---------------------------------------------------------------------------
// <copyright file="EventChannels.cs" company="eidng8">
//      GPLv3
// </copyright>
// <summary>
// 
// </summary>
// ---------------------------------------------------------------------------

using System.Collections.Generic;
using System.IO;
using eidng8.SpaceFlight.Configurable.Ship;
using eidng8.SpaceFlight.Configurable.System;
using eidng8.SpaceFlight.Events;
using eidng8.SpaceFlight.Factories.Ship;
using eidng8.SpaceFlight.Mechanics.Nav;
using eidng8.SpaceFlight.Objects.Movable;
using Luminosity.IO;
using UnityEngine;

namespace eidng8.SpaceFlight.Managers
{
    /// <summary>
    ///     The game manager is global to the whole game. It doesn't need
    ///     to be
    ///     added to scene.
    /// </summary>
    public static class GameManager
    {
        private static bool _hasInputManager;

        private static InputManager _inputManager;

        private static NavigatorEventDelegate _playerNav;

        private static Ship _playerShip;

        private static readonly List<Ship> _ships = new List<Ship>();

        public static Ship PlayerShip {
            set {
                GameManager._playerShip = value;
                EventManager.AttachCamera(value.transform);
            }
        }

        public static StartupConfig StartupConfig =>
            Resources.Load<StartupConfig>(
                GameManager.DataFilePath("Startup Config")
            );

        public static Ship CreateShip(ShipConfig cfg) {
            Ship ship = ShipFactory.Make(cfg);
            GameManager._ships.Add(ship);
            return ship;
        }

        /// <summary>Resource path to the given file.</summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static string DataFilePath(string file) {
            return Path.Combine("Data", file);
        }

        [RuntimeInitializeOnLoadMethod(
            RuntimeInitializeLoadType.BeforeSplashScreen
        )]
        public static void GlobalInit() {
            Debug.Log("GlobalInit");
            GameManager.SetupGameState();
        }

        /// <summary>Resource path to the give prefab file.</summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static string PrefabFilePath(string file) {
            return Path.Combine("Prefabs", file);
        }

        /// <summary>Path to the file in the persistent storage.</summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static string SavedFilePath(string file) {
            return Path.Combine(Application.persistentDataPath, "Player");
        }

        /// <summary>Sets up the scene after the scene has been loaded.</summary>
        [RuntimeInitializeOnLoadMethod(
            RuntimeInitializeLoadType.AfterSceneLoad
        )]
        private static void LateSetupScene() {
            Debug.Log("LateSetupScene");
            GameManager.SetupCamera();
            // Although Unity provides the sceneLoaded event, I prefer providing
            // my own version too. Just to be consistent with my own flow.
            EventManager.TriggerSystemEvent(
                SystemEvents.SceneChanged,
                new SystemEventArgs()
            );
        }

        private static void SetupCamera() {
            Camera.main.transform.parent.GetComponent<Follower>()
                .Follow(
                    GameObject.FindWithTag("Player")
                        .GetComponentInChildren<Rigidbody>()
                );
        }

        /// <summary>
        ///     Fetches game state from persistent storage or network server.
        ///     Then
        ///     perform setup accordingly. This is run once while the game is
        ///     launched.
        /// </summary>
        private static void SetupGameState() { }

        /// <summary>Sets up the scene before before the scene were loaded.</summary>
        [RuntimeInitializeOnLoadMethod(
            RuntimeInitializeLoadType.BeforeSceneLoad
        )]
        private static void SetupScene() {
            Debug.Log("SetupScene");
            EventManager.TriggerSystemEvent(
                SystemEvents.SceneWillChange,
                new SystemEventArgs()
            );
        }
    }
}
