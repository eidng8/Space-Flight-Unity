// ---------------------------------------------------------------------------
// <copyright file="EventChannels.cs" company="eidng8">
//      GPLv3
// </copyright>
// <summary>
// 
// </summary>
// ---------------------------------------------------------------------------

using System.IO;
using eidng8.SpaceFlight.Configurable.Ship;
using eidng8.SpaceFlight.Configurable.System;
using eidng8.SpaceFlight.Events;
using eidng8.SpaceFlight.Factories.Ship;
using eidng8.SpaceFlight.Objects.Movable;
using Luminosity.IO;
using UnityEngine;


namespace eidng8.SpaceFlight.Managers
{
    /// <summary>
    /// The game manager is global to the whole game. It doesn't need to be
    /// added to scene.
    /// </summary>
    public static class GameManager
    {
        private static bool _hasInputManager;

        private static InputManager _inputManager;

        private static StartupConfig StartupConfig =>
            Resources.Load<StartupConfig>(
                GameManager.DataFilePath("Startup Config")
            );

        /// <summary>Resource path to the given file.</summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static string DataFilePath(string file) =>
            Path.Combine("Data", file);

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
        public static string PrefabFilePath(string file) =>
            Path.Combine("Prefabs", file);

        /// <summary>Path to the file in the persistent storage.</summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static string SavedFilePath(string file) =>
            Path.Combine(Application.persistentDataPath, "Player");

        private static void CreatePlayer(PlayerConfig config) {
            GameManager.CreateShip(config.ship, true);
        }

        private static void CreateShip(
            ShipConfig config,
            bool isPlayer = false
        ) {
            Debug.Log($"create ship, isPlayer={isPlayer}");
            Ship ship = ShipFactory.Make(config);
            if (isPlayer) {
                ship.tag = "Player";
            }
        }

        /// <summary>Sets up the scene after the scene has been loaded.</summary>
        [RuntimeInitializeOnLoadMethod(
            RuntimeInitializeLoadType.AfterSceneLoad
        )]
        private static void LateSetupScene() {
            Debug.Log("LateSetupScene");
            EventManager.M.TriggerSystemEvent(
                SystemEvent.SceneChanged,
                new SystemEventArgs()
            );
        }

        private static PlayerConfig LoadPlayer() {
            string file = GameManager.SavedFilePath("Player");
            PlayerConfig player = Resources.Load<PlayerConfig>(file);
            if (null != player) {
                return player;
            }

            Debug.Log("using default player config.");
            return GameManager.StartupConfig.player;
        }

        /// <summary>
        /// Fetches game state from persistent storage or network server. Then
        /// perform setup accordingly. This is run once while the game is
        /// launched.
        /// </summary>
        private static void SetupGameState() { }

        /// <summary>Sets up the scene before before the scene were loaded.</summary>
        [RuntimeInitializeOnLoadMethod(
            RuntimeInitializeLoadType.BeforeSceneLoad
        )]
        private static void SetupScene() {
            Debug.Log("SetupScene");
            PlayerConfig player = GameManager.LoadPlayer();
            GameManager.CreatePlayer(player);
        }
    }
}
