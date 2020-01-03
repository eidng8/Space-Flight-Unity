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
using eidng8.SpaceFlight.Factories.Ship;
using eidng8.SpaceFlight.Objects.Movable;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace eidng8.SpaceFlight.Managers
{
    public static class GameManager
    {
        [RuntimeInitializeOnLoadMethod(
            RuntimeInitializeLoadType.BeforeSplashScreen
        )]
        public static void GlobalInit() {
            SceneManager.sceneLoaded += GameManager.SceneLoaded;
            GameManager.SetupGameState();
        }

        private static StartupConfig StartupConfig =>
            Resources.Load<StartupConfig>(
                GameManager.DataFile("Startup Config")
            );

        /// <summary>
        /// Fetches game state from persistent storage or network server.
        /// Then perform setup accordingly.
        /// </summary>
        private static void SetupGameState() { }

        /// <summary>
        /// Handler to the <see cref="SceneManager.sceneLoaded"/> event.
        /// </summary>
        public static void SceneLoaded(Scene scene, LoadSceneMode mode) {
            GameManager.SetupScene();
        }

        /// <summary>
        /// Resource path to the given file.
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static string DataFile(string file) =>
            Path.Combine("Data", file);

        /// <summary>
        /// Resource path to the give prefab file.
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static string PrefabFile(string file) =>
            Path.Combine("Prefabs", file);

        /// <summary>
        /// Path to the file in the persistent storage.
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static string SavedFile(string file) =>
            Path.Combine(Application.persistentDataPath, "Player");

        /// <summary>
        /// Sets up the scene before sending player in.
        /// </summary>
        private static void SetupScene() {
            PlayerConfig player = GameManager.LoadPlayer();
            GameManager.CreatePlayer(player);
        }

        private static PlayerConfig LoadPlayer() {
            string file = GameManager.SavedFile("Player");
            PlayerConfig player = Resources.Load<PlayerConfig>(file);
            if (null != player) {
                return player;
            }

            Debug.Log("using default player config.");
            return GameManager.StartupConfig.player;
        }

        private static void CreatePlayer(PlayerConfig config) {
            GameManager.CreateShip(config.ship);
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
    }
}
