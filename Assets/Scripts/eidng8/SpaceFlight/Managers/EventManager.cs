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


        /// <summary>Listen on the specified event from channel</summary>
        /// <param name="channelName"></param>
        /// <param name="eventName"></param>
        /// <param name="listener"></param>
        public void ListenOn(
            EventChannels channelName,
            Enum eventName,
            Action<ExtendedEventArgs> listener
        ) {
            Dictionary<Enum, Action<ExtendedEventArgs>> ch =
                this.GetChannel(channelName);

            Action<ExtendedEventArgs> evt;
            if (ch.TryGetValue(eventName, out evt)) {
                // Add more event to the existing one
                evt += listener;
                // Update the Dictionary
                ch[eventName] = evt;
            } else {
                // Add event to the Dictionary for the first time
                evt += listener;
                ch.Add(eventName, evt);
            }
        }


        /// <summary>Removes the given event listener</summary>
        /// <param name="channelName"></param>
        /// <param name="eventName"></param>
        /// <param name="listener"></param>
        public void StopListening(
            EventChannels channelName,
            Enum eventName,
            Action<ExtendedEventArgs> listener
        ) {
            // Don't call the `M()` property,
            // since we don't want to create an instance,
            // if it's not already instantiated.
            if (null == EventManager._instance) {
                return;
            }

            Dictionary<Enum, Action<ExtendedEventArgs>> ch =
                this.GetChannel(channelName, false);
            if (null == ch) {
                return;
            }

            Action<ExtendedEventArgs> evt;
            if (ch.TryGetValue(eventName, out evt)) {
                // Remove event from the existing one
                evt -= listener;
                // Update the Dictionary
                ch[eventName] = evt;
            }
        }


        /// <summary>Triggers the specified event on the channel.</summary>
        /// <param name="channelName"></param>
        /// <param name="eventName"></param>
        /// <param name="args"></param>
        public void TriggerEvent(
            EventChannels channelName,
            Enum eventName,
            ExtendedEventArgs args
        ) {
            Dictionary<Enum, Action<ExtendedEventArgs>> ch =
                this.GetChannel(channelName, false);
            if (null == ch) {
                return;
            }

            Action<ExtendedEventArgs> evt;
            if (ch.TryGetValue(eventName, out evt)) {
                evt.Invoke(args);
            }
        }


        private bool CameraRaycast(out RaycastHit hit) {
            Vector3 pos = Input.mousePosition;
            Ray ray = this._camera.ScreenPointToRay(pos);
            return Physics.Raycast(ray, out hit);
        }


        /// <summary>Returns the specified event channel</summary>
        /// <param name="channel"></param>
        /// <param name="autoCreate">
        /// If set to <c>true</c>, a new entry will be created and added to the
        /// dictionary if the specified <see cref="channel" /> doesn't exist.
        /// </param>
        /// <returns></returns>
        private Dictionary<Enum, Action<ExtendedEventArgs>> GetChannel(
            EventChannels channel,
            bool autoCreate = true
        ) {
            Dictionary<Enum, Action<ExtendedEventArgs>> ch;
            Dictionary<EventChannels,
                Dictionary<Enum, Action<ExtendedEventArgs>>> dict =
                EventManager.M._events;

            bool exists = dict.TryGetValue(channel, out ch);
            if (exists || !autoCreate) {
                return ch;
            }

            ch = new Dictionary<Enum, Action<ExtendedEventArgs>>();
            dict.Add(channel, ch);

            return ch;
        }


        private void Init() {
            Debug.Log("EventManager.Init");
            this._events = new Dictionary<
                EventChannels, Dictionary<Enum, Action<ExtendedEventArgs>>
            >(128);

            this.OnSystemEvent(SystemEvent.SceneChanged, this.OnSceneChanged);
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
