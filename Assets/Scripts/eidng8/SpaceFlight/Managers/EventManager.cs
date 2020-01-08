// ---------------------------------------------------------------------------
// <copyright file="EventChannels.cs" company="eidng8">
//      GPLv3
// </copyright>
// <summary>
// 
// </summary>
// ---------------------------------------------------------------------------

using eidng8.SpaceFlight.Events;
using UnityEngine;

namespace eidng8.SpaceFlight.Managers
{
    /// <summary>
    ///     A singleton event manager global to the whole game. Everything
    ///     happens in the game is driven by the event manager. This
    ///     manager
    ///     also converts raw input events from
    ///     <see cref="Luminosity.IO.Events.InputEventManager" /> to
    ///     corresponding
    ///     <see cref="Events.UserEvents" />.
    /// </summary>
    /// <remarks>This manager must be added to scene and enabled.</remarks>
    public sealed partial class EventManager : MonoBehaviour
    {
        private static EventManager _instance;

        /// <summary>The main camera of current scene.</summary>
        private static Camera _camera;

        private static Transform _target;

        public static void AttachCamera(Transform target) {
            EventManager._target = target;
        }

        public void Awake() {
            if (!EventManager._instance) {
                // It is the first created event manager instance.
                // Save it, and perform initialization.
                EventManager._instance = this;
                EventManager.DontDestroyOnLoad(this.gameObject);
                this.Init();
            } else {
                // No more instance allowed, destroy the instance immediately.
                EventManager.Destroy(this.gameObject);
            }
        }


        private bool CameraRaycast(out RaycastHit hit) {
            Vector3 pos = Input.mousePosition;
            Ray ray = EventManager._camera.ScreenPointToRay(pos);
            return Physics.Raycast(ray, out hit);
        }


        private void Init() {
            Debug.Log("EventManager.Init");
            EventManager.OnSystemEvent(
                SystemEvents.SceneChanged,
                this.OnSceneChanged
            );
        }

        /// <summary>
        ///     Handles scene change. Performs the following tasks (in order):
        ///     <ol>
        ///         <li>Update camera to the main camera of the new scene.</li>
        ///     </ol>
        /// </summary>
        /// <param name="_"></param>
        private void OnSceneChanged(SystemEventArgs _) {
            Debug.Log("EventManager.OnSceneChanged");
            EventManager._camera = Camera.main;
        }
    }
}
