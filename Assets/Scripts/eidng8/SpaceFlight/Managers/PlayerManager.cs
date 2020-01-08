// ---------------------------------------------------------------------------
// <copyright file="EventChannels.cs" company="eidng8">
//      GPLv3
// </copyright>
// <summary>
// 
// </summary>
// ---------------------------------------------------------------------------

using eidng8.SpaceFlight.Configurable.System;
using eidng8.SpaceFlight.Mechanics.Nav;
using eidng8.SpaceFlight.Objects.Movable;
using UnityEngine;

namespace eidng8.SpaceFlight.Managers
{
    /// <summary>
    ///     A singleton player manager.
    /// </summary>
    public sealed class PlayerManager : MonoBehaviour
    {
        private static PlayerManager _instance;

        private NavigatorEventDelegate _navigator;

        private Ship _ship;


        public void Awake() {
            if (!PlayerManager._instance) {
                // It is the first created event manager instance.
                // Save it, and perform initialization.
                PlayerManager._instance = this;
                PlayerManager.DontDestroyOnLoad(this.gameObject);
                this.Init();
            } else {
                // No more instance allowed, destroy the instance immediately.
                PlayerManager.Destroy(this.gameObject);
            }
        }

        private void Init() {
            PlayerConfig cfg = this.LoadPlayerConfig();
            Ship ship = GameManager.CreateShip(cfg.ship);
            ship.transform.parent = this.transform;
            NavigatorEventDelegate nav = new NavigatorEventDelegate();
            // nav.Configure(nav_config);
            nav.Man(ship);
            this._ship = ship;
            this._navigator = nav;
            GameManager.PlayerShip = ship;
        }

        private PlayerConfig LoadPlayerConfig() {
            string file = GameManager.SavedFilePath("Player");
            PlayerConfig config = Resources.Load<PlayerConfig>(file);
            if (null != config) {
                return config;
            }

            Debug.Log("using default player config.");
            return GameManager.StartupConfig.player;
        }
    }
}
