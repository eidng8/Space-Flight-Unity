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
using Luminosity.IO;


namespace eidng8.SpaceFlight.Managers
{
    public static class GameManager
    {
        private static bool _hasInputManager;

        private static InputManager _inputManager;

        private static InputManager Im {
            get {
                if (GameManager._hasInputManager) {
                    return GameManager._inputManager;
                }

                GameObject go = new GameObject("Input Manager");
                InputManager im = go.AddComponent<InputManager>();
                TextAsset ta =
                    Resources.Load<TextAsset>("input_manager_default_scheme");
                if (ta == null) {
                    Debug.LogWarning(
                        "Failed to load input profile. The resource"
                        + " file might have been deleted or renamed."
                    );
                    return null;
                }

                im.SetSaveData(
                    new InputLoaderXML(new StringReader(ta.text)).Load()
                );
                GameManager._inputManager = im;
                GameManager._hasInputManager = true;
                Object.DontDestroyOnLoad(go);
                return GameManager._inputManager;
            }
        }

        [RuntimeInitializeOnLoadMethod(
            RuntimeInitializeLoadType.BeforeSplashScreen
        )]
        public static void GlobalInit() {
            Debug.Log("GlobalInit");
            GameManager.SetupGameState();
        }

        private static StartupConfig StartupConfig =>
            Resources.Load<StartupConfig>(
                GameManager.DataFile("Startup Config")
            );

        /// <summary>
        /// Fetches game state from persistent storage or network server.
        /// Then perform setup accordingly. This is run once while the game
        /// is launched.
        /// </summary>
        private static void SetupGameState() { }

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
        [RuntimeInitializeOnLoadMethod(
            RuntimeInitializeLoadType.BeforeSceneLoad
        )]
        private static void SetupScene() {
            Debug.Log("SetupScene");
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
    }
}
