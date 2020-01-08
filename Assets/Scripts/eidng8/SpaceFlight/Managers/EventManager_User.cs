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
using UO = UnityEngine.Object;


namespace eidng8.SpaceFlight.Managers
{
    public sealed partial class EventManager
    {
        /// <summary>Holds all registered user event listeners.</summary>
        private static readonly Dictionary<UserEvents, Action<UserEventArgs>>
            UserEvents
                = new Dictionary<UserEvents, Action<UserEventArgs>>(16);

        /// <summary>
        ///     Removes the specified listener from
        ///     <see cref="EventChannels.User" /> channel.
        /// </summary>
        /// <param name="eventName"></param>
        /// <param name="listener"></param>
        public static void OffUserEvent(
            UserEvents eventName,
            Action<UserEventArgs> listener
        ) {
            Action<UserEventArgs> evt;
            if (!EventManager.UserEvents.TryGetValue(eventName, out evt)) {
                return;
            }

            evt -= listener;
            EventManager.UserEvents[eventName] = evt;
        }

        /// <summary>
        ///     Listens on the specified event from
        ///     <see cref="EventChannels.User" /> channel.
        /// </summary>
        /// <param name="eventName"></param>
        /// <param name="listener"></param>
        public static void OnUserEvent(
            UserEvents eventName,
            Action<UserEventArgs> listener
        ) {
            Action<UserEventArgs> evt;
            if (EventManager.UserEvents.TryGetValue(eventName, out evt)) {
                // Add more event to the existing one
                evt += listener;
                // Update the Dictionary
                EventManager.UserEvents[eventName] = evt;
            } else {
                // Add event to the Dictionary for the first time
                evt += listener;
                EventManager.UserEvents.Add(eventName, evt);
            }
        }

        /// <summary>
        ///     Triggers the specified event on the
        ///     <see cref="EventChannels.User" /> channel.
        /// </summary>
        /// <param name="eventName"></param>
        /// <param name="args"></param>
        public static void TriggerUserEvent(
            UserEvents eventName,
            UserEventArgs args
        ) {
            Action<UserEventArgs> evt;
            if (EventManager.UserEvents.TryGetValue(eventName, out evt)) {
                evt.Invoke(args);
            }
        }
    }
}
