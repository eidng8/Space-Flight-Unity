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
using UnityEngine.Events;


namespace eidng8.SpaceFlight.Managers
{
    public sealed class EventManager
    {
        private Dictionary<EventChannels, Dictionary<Enum, ManagedEvent>>
            _events;

        private static readonly EventManager Instance = new EventManager();
        private Camera _camera;

        private EventManager()
        {
            this.Init();
        }

        /// <summary>The singleton instance of <c>EventManager</c></summary>
        public static EventManager Em => EventManager.Instance;


        private void Init()
        {
            this._camera = Camera.main;
            if (this._events == null) {
                this._events = new Dictionary<
                    EventChannels, Dictionary<Enum, ManagedEvent>
                >();
            }
        }


        /// <summary>Listen on the specified event from channel</summary>
        /// <param name="channelName"></param>
        /// <param name="eventName"></param>
        /// <param name="listener"></param>
        // ReSharper disable once MemberCanBePrivate.Global
        public void ListenOn(
            EventChannels channelName,
            Enum eventName,
            UnityAction<ExtendedEventArgs> listener
        )
        {
            Dictionary<Enum, ManagedEvent> ch = this.GetChannel(channelName);

            ManagedEvent evt;
            if (ch.TryGetValue(eventName, out evt)) {
                evt.AddListener(listener);
            } else {
                evt = new ManagedEvent();
                evt.AddListener(listener);
                ch.Add(eventName, evt);
            }
        }

        /// <summary>Removes the given event listener</summary>
        /// <param name="channelName"></param>
        /// <param name="eventName"></param>
        /// <param name="listener"></param>
        // ReSharper disable once MemberCanBePrivate.Global
        public void StopListening(
            EventChannels channelName,
            Enum eventName,
            UnityAction<ExtendedEventArgs> listener
        )
        {
            // Don't call the `Em()` property,
            // since we don't want to create an instance,
            // if it's not already instantiated.
            if (EventManager.Instance == null) {
                return;
            }

            Dictionary<Enum, ManagedEvent> ch =
                this.GetChannel(channelName, false);
            if (null == ch) {
                return;
            }

            ManagedEvent evt;
            if (ch.TryGetValue(eventName, out evt)) {
                evt.RemoveListener(listener);
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
        )
        {
            Dictionary<Enum, ManagedEvent> ch =
                this.GetChannel(channelName, false);
            if (null == ch) {
                return;
            }

            ManagedEvent evt;
            if (ch.TryGetValue(eventName, out evt)) {
                evt.Invoke(args);
            }
        }

        /// <summary>
        /// Listener on the specified event from
        /// <see cref="EventChannels.User" /> channel.
        /// </summary>
        /// <param name="eventName"></param>
        /// <param name="listener"></param>
        public void OnUserEvent(
            Enum eventName,
            UnityAction<ExtendedEventArgs> listener
        ) =>
            this.ListenOn(EventChannels.User, eventName, listener);


        /// <summary>
        /// Remove the specified listener from
        /// <see cref="EventChannels.User" /> channel.
        /// </summary>
        /// <param name="eventName"></param>
        /// <param name="listener"></param>
        // ReSharper disable once UnusedMember.Global
        public void OffUserEvent(
            Enum eventName,
            UnityAction<ExtendedEventArgs> listener
        ) =>
            this.StopListening(EventChannels.User, eventName, listener);


        /// <summary>Returns the specified event channel</summary>
        /// <param name="channel"></param>
        /// <param name="autoCreate"></param>
        /// <returns></returns>
        private Dictionary<Enum, ManagedEvent> GetChannel(
            EventChannels channel,
            bool autoCreate = true
        )
        {
            Dictionary<Enum, ManagedEvent> ch;
            Dictionary<EventChannels, Dictionary<Enum, ManagedEvent>> dict =
                EventManager.Em._events;

            bool exists = dict.TryGetValue(channel, out ch);
            if (exists || !autoCreate) {
                return ch;
            }

            ch = new Dictionary<Enum, ManagedEvent>();
            dict.Add(channel, ch);

            return ch;
        }

        private void Update()
        {
            this.HandleMouseClick();
        }

        private void HandleMouseClick()
        {
            if (Input.GetMouseButtonDown(0)) {
                if (this.CameraRaycast(out RaycastHit hit)) {
                    var args = new ExtendedEventArgs {
                        source = hit.transform.gameObject
                    };
                    this.TriggerEvent(
                        EventChannels.User,
                        UserEvents.Select,
                        args
                    );
                }
            }
        }

        private bool CameraRaycast(out RaycastHit hit)
        {
            Vector3 pos = Input.mousePosition;
            Ray ray = this._camera.ScreenPointToRay(pos);
            return Physics.Raycast(ray, out hit);
        }
    }
}
