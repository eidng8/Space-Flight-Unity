// ---------------------------------------------------------------------------
// <copyright file="EventChannels.cs" company="eidng8">
//      GPLv3
// </copyright>
// <summary>
// 
// </summary>
// ---------------------------------------------------------------------------

using System.IO;
using eidng8.SpaceFlight.Configurable;
using eidng8.SpaceFlight.Configurable.Ship;
using eidng8.SpaceFlight.Configurable.System;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace eidng8.SpaceFlight.Managers
{
    public sealed class GameManager
    {
        public static readonly GameManager Gm = new GameManager();

        private GameManager() { }

        [RuntimeInitializeOnLoadMethod(
            RuntimeInitializeLoadType.BeforeSplashScreen
        )]
        public static void GlobalInit()
        {
            SceneManager.sceneLoaded += GameManager.Gm.SceneLoaded;
        }

        public void SceneLoaded(Scene scene, LoadSceneMode mode)
        {
            this.SetupScene();
        }

        // ReSharper disable once MemberCanBeMadeStatic.Global
        // ReSharper disable once MemberCanBePrivate.Global
        public string DataFile(string file) =>
            Path.Combine("Data", "Startup Config");

        // ReSharper disable once MemberCanBeMadeStatic.Global
        // ReSharper disable once MemberCanBePrivate.Global
        public string SavedFile(string file) =>
            Path.Combine(Application.persistentDataPath, "Player");

        private void SetupScene()
        {
            string file = this.DataFile("Startup Config");
            StartupConfig config = Resources.Load<StartupConfig>(file);

            PlayerConfig player = this.LoadPlayer();
            if (null == player) {
                player = config.player;
                Debug.Log("using default player config.");
            }

            this.CreatePlayer(player);
        }

        private PlayerConfig LoadPlayer() =>
            Resources.Load<PlayerConfig>(this.SavedFile("Player"));

        private void CreatePlayer(PlayerConfig config)
        {
            this.CreateShip(config.ship);
        }

        private void CreateShip(ShipConfig config, bool isPlayer = false)
        {
            Debug.Log($"create ship, isPlayer={isPlayer}");
            Debug.Log(config);
            // var hull = Resources.Load(config.hull);
        }
    }
}
