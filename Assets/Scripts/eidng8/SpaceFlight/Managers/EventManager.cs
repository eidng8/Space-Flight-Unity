// ---------------------------------------------------------------------------
// <copyright file="EventChannels.cs" company="eidng8">
//      GPLv3
// </copyright>
// <summary>
// 
// </summary>
// ---------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using eidng8.SpaceFlight.Events;
using UnityEngine;
using UO = UnityEngine.Object;


namespace eidng8.SpaceFlight.Managers
{
    /// <summary>
    /// A singleton event manager global to the whole game. Everything
    /// happens in the game is driven by the event manager. This manager
    /// also converts raw input events from
    /// <see cref="InputEventManager" /> to corresponding
    /// <see cref="UserEvents" />.
    /// </summary>
    /// <remarks>This manager must be added to scene and enabled.</remarks>
    public sealed partial class EventManager : MonoBehaviour
    {
        private static EventManager _instance;

        /// <summary>The main camera of current scene.</summary>
        private Camera _camera;

        /// <summary>Holds all registered event listeners.</summary>
        private Dictionary<
            EventChannels,
            Dictionary<Enum, Action<ExtendedEventArgs>>
        > _events;

        /// <summary>The singleton instance of <c>EventManager</c></summary>
        public static EventManager M => EventManager._instance;

        public void Awake() {
            if (!EventManager._instance) {
                // It is the first created event manager instance.
                // Save it, and perform initialization.
                EventManager._instance = this;
                UO.DontDestroyOnLoad(this.gameObject);
                this.Init();
            } else {
                // No more instance allowed, destroy the instance immediately.
                UO.Destroy(this.gameObject);
            }
        }


        private bool CameraRaycast(out RaycastHit hit) {
            Vector3 pos = Input.mousePosition;
            Ray ray = this._camera.ScreenPointToRay(pos);
            return Physics.Raycast(ray, out hit);
        }


        private void Init() {
            Debug.Log("EventManager.Init");
            this._sysEvents =
                new Dictionary<SystemEvents, Action<SystemEventArgs>>(128);
            this._userEvents =
                new Dictionary<UserEvents, Action<UserEventArgs>>(128);
            this.OnSystemEvent(SystemEvents.SceneChanged, this.OnSceneChanged);
        }

        /// <summary>
        /// Handles scene change. Performs the following tasks (in order):
        /// <ol>
        ///     <li>Update camera to the main camera of the new scene.</li>
        /// </ol>
        /// </summary>
        /// <param name="_"></param>
        private void OnSceneChanged(SystemEventArgs _) {
            Debug.Log("EventManager.OnSceneChanged");
            this._camera = Camera.main;
        }
    }
}
